using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public abstract class SharePointStatObject : SharePointBase
    {
        public int NotebookCount { get; private set; }
        public int FolderCount { get; private set; }
        public int ItemCount { get; private set; }
        public int SectionCount { get; private set; }

        public override void UpdateProperties(SharePointListItem listItem)
        {
            ItemCount++;
            if ((listItem.ItemType & SharePointListItemType.Notebook) > 0)
            {
                NotebookCount++;
            }

            if ((listItem.ItemType & SharePointListItemType.Folder) > 0)
            {
                FolderCount++;
            }

            if ((listItem.ItemType & SharePointListItemType.Section) > 0)
            {
                SectionCount++;
            }
        }
    }
}
