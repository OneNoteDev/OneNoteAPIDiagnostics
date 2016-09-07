using System;
using Generic = System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.SharePoint.Client;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public class Utilities : IDisposable
	{
		private const string Query = "<View Scope='RecursiveAll'><RowLimit>4999</RowLimit><ViewFields><FieldRef Name='HTML_x0020_File_x0020_Type' /><FieldRef Name='File_x0020_Type' /><FieldRef Name='ContentTypeId' /></ViewFields></View>";
		private ClientContext context;

		public Generic.IList<string> Logs
		{
			get;
			private set;
		}

		public Utilities(string url, string userName, string password)
		{
			context = new ClientContext(url);
			SecureString securePassword = new SecureString();
			Array.ForEach(password.ToArray(), securePassword.AppendChar);
			context.Credentials = new SharePointOnlineCredentials(userName, securePassword);
			Logs = new Generic.List<string>();
		}

		/// <summary>
		/// Processing SharePoint list to add Logs to collection
		/// </summary>
		/// <param name="lists"> SharePoint list collection</param>
		/// <returns> task object</returns>
		public async Task AddListsInfo(Generic.List<List> lists)
		{
			bool skipListSeparationLine = true;
			bool addListTitle = lists.Count > 1;
			foreach (var list in lists)
			{
				if (list.Fields.Any(field => field.Title == "File Type") &&
					list.Fields.Any(field => field.Title == "HTML File Type"))
				{
					if (!skipListSeparationLine)
					{
						Logs.Add("------------------------------------");
					}

					if (addListTitle)
					{
						Logs.Add("List: " + list.Title);
					}

					Logs.Add("Items Count: " + list.ItemCount);
					await AddOneNoteItemsInfo(list);
					AddIndexingInfo(list);
					skipListSeparationLine = false;
				}
			}
		}

		/// <summary>
		/// Retrieving SharePoint list collection
		/// </summary>
		/// <returns> SharePoint list collection</returns>
		public async Task<Generic.List<List>> GetLists()
		{
			Generic.List<List> resultLists = new Generic.List<List>();
			IQueryable<List> listsWithIncludedProperty = ClientObjectQueryableExtension.Include(context.Web.Lists, 
				list => list.Id, 
				list => list.Title,
				list => list.ItemCount, 
				list => list.Fields.Include(f => f.Title, f => f.Indexed, f => f.InternalName));

			IQueryable<List> listCollection =
				listsWithIncludedProperty.Where(list => list.BaseType == BaseType.DocumentLibrary &&
					(list.BaseTemplate == (int)ListTemplateType.DocumentLibrary ||
					list.BaseTemplate == (int)ListTemplateType.MySiteDocumentLibrary) &&
					list.Hidden == false);

			Generic.IEnumerable<List> lists = context.LoadQuery(listCollection);
			await ExecuteQuery();

			lists.ForEach(list => resultLists.Add(list));
			return resultLists;
		}

		/// <summary>
		/// Retrieving SharePoint document library
		/// </summary>
		/// <returns> SharePoint document library</returns>
		public async Task<List> GetDocumentLibrary()
		{
			return await GetListByTitle("documents");
		}

		/// <summary>
		/// Retrieving SharePoint list by title
		/// </summary>
		/// <param name="title"> SharePoint list title</param>
		/// <returns> SharePoint document library</returns>
		public async Task<List> GetListByTitle(string title)
		{
			var docLib = context.Web.Lists.GetByTitle(title);
			context.Load(docLib, l => l.Title, l => l.ItemCount, l => l.Fields.Include(f => f.Title, f => f.Indexed, f => f.InternalName));
			await ExecuteQuery();
			return docLib;
		}

		public async Task AddIndexOnListFields(List list)
		{
			foreach (Field field in list.Fields)
			{
				if (field.Title.Contains("File Type") || field.Title.Contains("HTML File Type"))
				{
					if (!field.Indexed)
					{
						field.Indexed = true;
						field.Update();
					}
				}
			}

			await ExecuteQuery();
		}
		/// <summary>
		/// Adding Logs to file system. It suppresses the exception
		/// </summary>
		/// <param name="logInfo"> Log info text</param>
		public void AddToLogFile(string logInfo)
		{
			try
			{
				var path = System.Environment.CurrentDirectory + "\\Logs";
				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(path);
				}

				using (var stream = System.IO.File.CreateText(path + "\\log.txt"))
				{
					stream.Write(logInfo);
				}
			}
			catch
			{
				// Supressing I/O exceptions
			}
		}

		/// <summary>
		/// Adding OneNote items (Notebooks, SectionGroups and Sections) Logs to the collection
		/// </summary>
		/// <param name="list"> SharePoint list object</param>
		/// <returns> task object</returns>
		private async Task AddOneNoteItemsInfo(List list)
		{
			ListItemCollectionPosition pagePosition = null;
			int notebooksCount = 0;
			int foldersCount = 0;
			int sectionsCount = 0;

			do
			{
				CamlQuery camlQuery = new CamlQuery();
				camlQuery.ListItemCollectionPosition = pagePosition;
				camlQuery.ViewXml = Query;
				ListItemCollection items = list.GetItems(camlQuery);
				context.Load(items);
				await ExecuteQuery();
				pagePosition = items.ListItemCollectionPosition;
				foreach (var item in items)
				{
					object returnValue;
					if (item.FieldValues.TryGetValue("File_x0020_Type", out returnValue) && returnValue != null && returnValue.ToString().Equals("one", StringComparison.OrdinalIgnoreCase))
					{
						sectionsCount++;
					}

					if (item.FieldValues.TryGetValue("ContentTypeId", out returnValue) && returnValue != null && returnValue.ToString().StartsWith("0x0120", StringComparison.OrdinalIgnoreCase))
					{
						foldersCount++;
					}

					if (item.FieldValues.TryGetValue("HTML_x0020_File_x0020_Type", out returnValue) && returnValue != null && returnValue.ToString().Equals("OneNote.Notebook", StringComparison.OrdinalIgnoreCase))
					{
						notebooksCount++;
					}
				}

			} while (pagePosition != null);

			Logs.Add("Notebooks Count:" + notebooksCount);
			Logs.Add("Folders Count:" + foldersCount);
			Logs.Add("Sections Count:" + sectionsCount);
		}

		/// <summary>
		/// Adding index details Logs to the collection
		/// </summary>
		/// <param name="list"> SharePoint list object</param>
		private void AddIndexingInfo(List list)
		{
			foreach (Field f in list.Fields)
			{
				if (!string.IsNullOrWhiteSpace(f.Title) && (f.Title.Contains("File Type") || f.Title.Contains("HTML File Type")))
				{
					Logs.Add(f.Title + ":" + f.Indexed);
				}
			}
		}

		/// <summary>
		/// Executing CSOM request asynchronously
		/// </summary>
		/// <returns> task object</returns>
		private async Task ExecuteQuery()
		{
			await Task.Run(() => { context.ExecuteQuery(); });
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
