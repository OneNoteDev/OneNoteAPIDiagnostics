using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{    
    public class SharePointList : SharePointStatObject
    {
        public Guid Id { get; private set; }
        
        public bool FileTypeIndexed { get; private set; }

        public bool HtmlFileTypeIndexed { get; private set; }

        public bool ContentTypeIdIndexed { get; private set; }

        public int ListItemCount
        {
            get
            {
                return List.ItemCount;
            }
        }

        public SharePointFolder RootFolder;

        public List<SharePointFolder> Notebooks;

        public List List { get; internal set; }

        public string HostUrl { get; set; }

        public SharePointList(List list, string siteUrl)
        {
            Uri webUri = new Uri(siteUrl);
            HostUrl = webUri.Scheme + "://" + webUri.Host;
            List = list;
            UpdateListProperties();
            RootFolder = new SharePointFolder(this, list.RootFolder.ServerRelativeUrl, list.RootFolder.ServerRelativeUrl.Split('/').Length);
            RootFolder.Title = list.Title;
            Notebooks = new List<SharePointFolder>();            
        }

        public void AddSharePointListItem(ListItem item)
        {
            SharePointListItem listItem = SharePointListItem.TransformToSharePointLisitem(item);
            UpdateProperties(listItem);
            SharePointFolder parentFolder = FindParentFolder(RootFolder, listItem.Depth, listItem.Path);
            if (parentFolder == null)
            {
                FindNearestParent(RootFolder, ref parentFolder, listItem.Depth, listItem.Path);
                if (parentFolder != null)
                {
                    string pathDiff = listItem.ParentPath.Replace(parentFolder.Path, string.Empty);
                    string[] diffPaths = pathDiff.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string diffPath in diffPaths)
                    {
                        SharePointFolder childFolder = new SharePointFolder(this, parentFolder.Path + "/" + diffPath, parentFolder.Folders.Depth + 1);
                        parentFolder.Folders.Add(childFolder);
                        parentFolder = childFolder;
                    }
                }
            }

            if (parentFolder != null)
            {
                parentFolder.AddItem(listItem);
            }
        }

        public static SharePointFolder FindParentFolder(SharePointFolder folder, int depth, string path)
        {
            if (folder.Depth + 1 == depth && path.StartsWith(folder.Path))
            {
                return folder;
            }

            if (folder.Folders.Count > 0)
            {
                foreach (SharePointFolder childFolder in folder.Folders)
                {
                    var tempFolder = FindParentFolder(childFolder, depth, path);
                    if (tempFolder != null)
                    {
                        return tempFolder;
                    }
                }
            }

            return null;
        }

        public static void FindNearestParent(SharePointFolder root, ref SharePointFolder folder, int depth, string path)
        {
            if (root.Depth < depth && path.StartsWith(root.Path))
            {
                if (folder == null)
                {
                    folder = root;
                }
                else if (folder.Depth < root.Depth)
                {
                    folder = root;
                }
            }

            if (root.Folders.Count > 0)
            {
                foreach (SharePointFolder childFolder in root.Folders)
                {
                    FindNearestParent(childFolder, ref folder, depth, path);
                }
            }
        }

        /// <summary> 
 		/// Updating list specific properites
 		/// </summary> 
 		/// <param name="list"> SharePoint list object</param> 
 		private void UpdateListProperties()
        {
            Id = List.Id;
            Title = List.Title;            
            
            foreach (Field f in List.Fields)
            {
                if (!string.IsNullOrWhiteSpace(f.Title))
                {
                    if (f.Title.Contains("File Type"))
                    {
                        FileTypeIndexed = f.Indexed;
                    }

                    if (f.Title.Contains("HTML File Type"))
                    {
                        HtmlFileTypeIndexed = f.Indexed;
                    }

                    if (f.Title.Contains("Content Type ID"))
                    {
                        ContentTypeIdIndexed = f.Indexed;
                    }
                }
            }
        }
    }   
}
