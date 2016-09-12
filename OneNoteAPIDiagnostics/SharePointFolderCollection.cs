using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public class SharePointFolderCollection : List<SharePointFolder>
    {
        public int Depth;

        public SharePointFolderCollection(int depth)
        {
            Depth = depth;
        }
    }
}
