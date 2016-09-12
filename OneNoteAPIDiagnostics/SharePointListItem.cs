using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public class SharePointListItem
    {
        private SharePointListItem()
        { }

        public string Title { get; private set; }


        public string Path { get; private set; }

        public string ParentPath { get; private set; }

        public SharePointListItemType ItemType { get; private set; }

        public int Depth { get; private set;  }

        public ListItem Item { get; private set; }

        public static SharePointListItem TransformToSharePointLisitem(ListItem listItem)
        {            
            SharePointListItem sharePointListItem = new SharePointListItem();
            sharePointListItem.Item = listItem;
            sharePointListItem.ItemType = SharePointListItemType.None;
            object returnValue;
            if (listItem.FieldValues.TryGetValue("File_x0020_Type", out returnValue) && returnValue != null && returnValue.ToString().Equals("one", StringComparison.OrdinalIgnoreCase))
            {
                sharePointListItem.ItemType = sharePointListItem.ItemType | SharePointListItemType.Section;
            }

            if (listItem.FieldValues.TryGetValue("ContentTypeId", out returnValue) && returnValue != null && returnValue.ToString().StartsWith("0x0120", StringComparison.OrdinalIgnoreCase))
            {
                sharePointListItem.ItemType = sharePointListItem.ItemType | SharePointListItemType.Folder;
            }

            if (listItem.FieldValues.TryGetValue("HTML_x0020_File_x0020_Type", out returnValue) && returnValue != null && returnValue.ToString().Equals("OneNote.Notebook", StringComparison.OrdinalIgnoreCase))
            {
                sharePointListItem.ItemType = sharePointListItem.ItemType | SharePointListItemType.Notebook;
            }

            if (listItem.FieldValues.TryGetValue("FileLeafRef", out returnValue) && returnValue != null)
            {
                sharePointListItem.Title = returnValue.ToString();
            }

            sharePointListItem.Path = string.Empty;
            if (listItem.FieldValues.TryGetValue("FileRef", out returnValue) && returnValue != null)
            {
                sharePointListItem.Path = returnValue.ToString();
            }

            sharePointListItem.ParentPath = sharePointListItem.Path.Substring(0, sharePointListItem.Path.LastIndexOf("/"));
            sharePointListItem.Depth = sharePointListItem.Path.Split('/').Length;
            return sharePointListItem;
        }
    }
}
