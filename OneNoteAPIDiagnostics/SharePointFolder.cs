using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public class SharePointFolder : SharePointStatObject
    {
        public int Depth { get; private set; }
        public string Path { get; private set; }
     
        public SharePointFolder ParentFolder;

        public SharePointList SharePointList { get; private set; }

        public bool IsNotebook { get; private set; }

        public ListItem Item { get; private set; }

        public List<ListItem> Files { get; private set; }

        public string Url
        {
            get {
                return SharePointList.HostUrl + Path;
            }
        }

        public SharePointFolder(SharePointList sharePointList, string path, int depth)
        {
            Path = path;
            Depth = depth;
            SharePointList = sharePointList;
            Folders = new SharePointFolderCollection(depth + 1);
            Files = new List<ListItem>();
        }

        public void AddItem(SharePointListItem listItem)
        {
            if ((listItem.ItemType & SharePointListItemType.Folder) > 0)
            {
                SharePointFolder childFolder = Folders.FirstOrDefault(f => f.Path.Equals(listItem.Path));
                var isNotebook = (listItem.ItemType & SharePointListItemType.Notebook) > 0;
                if (childFolder == null)
                {
                    childFolder = new SharePointFolder(SharePointList, listItem.Path, Depth + 1);
                    childFolder.ParentFolder = this;
                    childFolder.IsNotebook = IsNotebook;
                    Folders.Add(childFolder);
                }

                childFolder.Title = listItem.Title;
                childFolder.Item = listItem.Item;
                childFolder.IsNotebook = isNotebook;
                if (isNotebook)
                {                    
                    SharePointList.Notebooks.Add(childFolder);
                }

                childFolder.UpdateProperties(listItem);
            }
            else
            {
                Files.Add(listItem.Item);
                UpdateProperties(listItem);
            }
        }
        
        public override void UpdateProperties(SharePointListItem listItem)
        {
            base.UpdateProperties(listItem);

            if (ParentFolder != null)
            {
                ParentFolder.UpdateProperties(listItem);
            }
        }


        public SharePointFolderCollection Folders;        
    }
}
