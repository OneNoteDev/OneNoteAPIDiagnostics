using Microsoft.SharePoint.Client;
using System;
using Generic = System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Linq.Expressions;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public class CsomProxy : IDisposable
    {
        private const string Query = "<View Scope='RecursiveAll'><RowLimit>4999</RowLimit><ViewFields><FieldRef Name='HTML_x0020_File_x0020_Type' /><FieldRef Name='File_x0020_Type' /><FieldRef Name='ContentTypeId' /><FieldRef Name='Title' /></ViewFields></View>";
        private ClientContext context;

        public CsomProxy(string url, string userName, string password)
        {
            context = new ClientContext(url);
            SecureString securePassword = new SecureString();
            Array.ForEach(password.ToArray(), securePassword.AppendChar);
            context.Credentials = new SharePointOnlineCredentials(userName, securePassword);
            
            //for (int i = 1; i < 11; i++)
            //{
            //    var li = context.Web.Lists.GetByTitle("TestLib" + i.ToString());
            //    li.DeleteObject();
            //    context.ExecuteQuery();
            //}
        }

        /// <summary>
		/// Retrieving SharePoint document library
		/// </summary>
		/// <returns> SharePoint document library</returns>
        public async Task<SharePointList> GetDefaultDocumentLibraryAsyc()
        {
            var list = context.Web.DefaultDocumentLibrary();
            return await GetSharePointListAsyc(list);
        }

        /// <summary>
		/// Retrieving SharePoint document library
		/// </summary>
		/// <returns> SharePoint document library</returns>
        public async Task<SharePointList> GetListByTitleAsyc(string title)
        {
            var list = context.Web.Lists.GetByTitle(title);
            return await GetSharePointListAsyc(list);
        }

        /// <summary>
		/// Retrieving SharePoint document library
		/// </summary>
		/// <returns> SharePoint document library</returns>
        public async Task<List> CreateDocumentLibraryAsyc(string title)
        {
            ListCreationInformation listCreationInformation = new ListCreationInformation();
            listCreationInformation.Title = title;
            listCreationInformation.TemplateType = 101;
            List documentLibrary = context.Web.Lists.Add(listCreationInformation);
            documentLibrary.EnableFolderCreation = true;
            context.Load(documentLibrary);
            await ExecuteQueryAsyc();
            return documentLibrary;
        }

        public async Task<Generic.List<SharePointList>> GetListsAsyc()
        {
            Generic.List<SharePointList> resultLists = new Generic.List<SharePointList>();
            IQueryable<List> listsWithIncludedProperty = ClientObjectQueryableExtension.Include(context.Web.Lists,
                list => list.Id,
                list => list.ParentWebUrl,
                list => list.Title,
                list => list.ItemCount,
                list => list.RootFolder.ServerRelativeUrl,
                list => list.Fields.Include(f => f.Title, f => f.Indexed, f => f.InternalName));

            IQueryable<List> listCollection =
                listsWithIncludedProperty.Where(list => list.BaseType == BaseType.DocumentLibrary &&
                    (list.BaseTemplate == (int)ListTemplateType.DocumentLibrary ||
                    list.BaseTemplate == (int)ListTemplateType.MySiteDocumentLibrary) &&
                    list.Hidden == false);

            Generic.IEnumerable<List> lists = context.LoadQuery(listCollection);
            await ExecuteQueryAsyc();
            foreach (List list in lists)
            {
                resultLists.Add(await TransformToSharePointListAsyc(list));
            }

            return resultLists;
        }

        public async Task AddIndexOnListFieldsAsyc(SharePointList list)
        {
            foreach (Field field in list.List.Fields)
            {
                if (field.Title.Contains("File Type") || field.Title.Contains("HTML File Type") || field.Title.Contains("Content Type ID"))
                {
                    if (!field.Indexed)
                    {
                        field.Indexed = true;
                        field.Update();
                    }
                }
            }

            await ExecuteQueryAsyc();
        }

        public void Load<T>(T clientObject, params Expression<Func<T, object>>[] retrievals) where T : ClientObject
        {
            context.Load(clientObject, retrievals);
        }

        private async Task<SharePointList> GetSharePointListAsyc(List list)
        {
            context.Load(list, 
                l => l.Id,
                l => l.ParentWebUrl,
                l => l.Title, 
                l => l.ItemCount, 
                l => l.RootFolder.ServerRelativeUrl,
                l => l.Fields.Include(f => f.Title, 
                    f => f.Indexed, 
                    f => f.InternalName));

            await ExecuteQueryAsyc();
            return await TransformToSharePointListAsyc(list);
        }

        /// <summary>
        /// Adding OneNote items (Notebooks, SectionGroups and Sections) Logs to the collection
        /// </summary>
        /// <param name="list"> SharePoint list object</param>
        /// <returns> task object</returns>
        private async Task<SharePointList> TransformToSharePointListAsyc(List list)
        {
            SharePointList sharePointList = new SharePointList(list, context.Url);
            ListItemCollectionPosition pagePosition = null;

            do
            {
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ListItemCollectionPosition = pagePosition;
                camlQuery.ViewXml = Query;
                ListItemCollection items = list.GetItems(camlQuery);
                context.Load(items);
                await ExecuteQueryAsyc();
                pagePosition = items.ListItemCollectionPosition;
                foreach (var item in items)
                {
                    sharePointList.AddSharePointListItem(item);                    
                }

            } while (pagePosition != null);

            return sharePointList;
        }

        /// <summary> 
		/// Executing CSOM request asynchronously 
 		/// </summary> 
 		/// <returns> task object</returns> 
        public async Task ExecuteQueryAsyc()
		{ 
 			await Task.Run(() => { context.ExecuteQuery(); }); 
 		}

        private async Task LoadFolder(Folder folder)
        {
            context.Load(folder, sf => sf.Files, sf => sf.Files.Include(f => f.ListItemAllFields["FileLeafRef"]));
            context.Load(folder, sf => sf.ListItemAllFields["FileLeafRef"], sf=>sf.ServerRelativeUrl);
            context.Load(folder, sf => sf.Folders.Include(f => f.ServerRelativeUrl, f => f.ListItemAllFields["Title"]));
            await ExecuteQueryAsyc();
        }

        public async Task MoveAsync(string sourceFolderRelativeUrl, string targetLibrary)
        {
            var sourceFolder = context.Web.GetFolderByServerRelativeUrl(sourceFolderRelativeUrl);
            var targetList = context.Web.Lists.GetByTitle(targetLibrary);
            var targetFolder = targetList.RootFolder;
            await LoadFolder(targetFolder);
            await MoveAsync(sourceFolder, targetFolder, true);
        }

        private async Task MoveAsync(Folder sourceSource, Folder targetFolder, bool isNotebook)
        {
            await LoadFolder(sourceSource);
            var targetChildFolder = targetFolder.Folders.Add(sourceSource.ListItemAllFields["FileLeafRef"].ToString());
            targetChildFolder.Update();
            context.Load(targetChildFolder, tf => tf.ServerRelativeUrl);
            await ExecuteQueryAsyc();
            foreach (var file in sourceSource.Files)
            {
                var leafUrl = file.ListItemAllFields["FileLeafRef"].ToString();
                file.MoveTo(targetChildFolder.ServerRelativeUrl + "/" + leafUrl, MoveOperations.Overwrite);
            }

            await ExecuteQueryAsyc();
            foreach (var sourceChildFolder in sourceSource.Folders)
            {
                await MoveAsync(sourceChildFolder, targetChildFolder, false);
            }

            if (isNotebook)
            {
                targetChildFolder.ListItemAllFields["HTML_x0020_File_x0020_Type"] = "OneNote.Notebook";
                targetChildFolder.ListItemAllFields.Update();
                await ExecuteQueryAsyc();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

                protected virtual void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                            context.Dispose();
                        }

                        disposedValue = true;
                    }
                }

                // This code added to correctly implement the disposable pattern.
                public void Dispose()
                {
                    Dispose(true);
                }
                #endregion
    }
}
