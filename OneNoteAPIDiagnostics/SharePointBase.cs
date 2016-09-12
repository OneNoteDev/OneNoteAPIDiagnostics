using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public abstract class SharePointBase
    {
        public string Title { get; internal protected set; }

        public abstract void UpdateProperties(SharePointListItem listItem);
    }
}
