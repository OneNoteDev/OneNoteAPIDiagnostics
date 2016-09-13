using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public static class Constants
    {
        public const string SelectListLabelText = "SelectList";
        


        public const string SiteUrlItemKey = "SiteUrl";
        public const string UserItemKey = "User";
        public const string PasswordItemKey = "Password";
        public const string SharePointInfoItemKey = "SharePointInfo";
        public const string SharePointThrottledListsItemKey = "SharePointThrottledLists";
        public const string SelectedThrottledListItemKey = "SelectedThrottledList";

        public const string MoveNotebooksFormItemKey = "MoveNotebooksForm";
        public const string HierarchyViewFormItemKey = "HierarchyViewForm";
        public const string SiteCollectionFormItemKey = "SiteCollectionForm";
        public const string ProcessingDialogFormItemKey = "ProcessingDialog";

        /// <summary>
		/// This is the list threshold value i.e. if SPO list size exceeds 5000 items then the CAML queries start throttling
		/// </summary>
		public const int SPO_LIST_VIEW_THRESHOLD = 5000;

        /// <summary>
        /// This is the max. value for SPO list size upto which the list is indexable
        /// </summary>
        public const int INDEXABLE_SPO_LIST_SIZE_MAX = 20000;

    }
}
