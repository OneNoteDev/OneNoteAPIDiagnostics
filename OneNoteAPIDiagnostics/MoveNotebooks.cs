using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    
    public partial class MoveNotebooksForm : Form
    {        
        string siteUrl;
        string user;
        string password;

        public MoveNotebooksForm()
        {   
            InitializeComponent();
            Utilities.Items[Constants.MoveNotebooksFormItemKey] = this;

            if (Utilities.Items.ContainsKey(Constants.SiteUrlItemKey))
            {
                siteUrl = Utilities.Items[Constants.SiteUrlItemKey].ToString();
            }

            if (Utilities.Items.ContainsKey(Constants.UserItemKey))
            {
                user = Utilities.Items[Constants.UserItemKey].ToString();
            }

            if (Utilities.Items.ContainsKey(Constants.PasswordItemKey))
            {
                password = Utilities.Items[Constants.PasswordItemKey].ToString();
            }
        }

        #region Events
        private void MoveNotebooks_Load(object sender, EventArgs e)
        {
            selectListBox.ValueMember = "Id";
            selectListBox.DisplayMember = "Title";
            var selectedItem = Utilities.SeletedThrottledList;
            selectListBox.DataSource = Utilities.ThrottledLists;
            if (Utilities.SeletedThrottledList == null && Utilities.ThrottledLists.Count > 0)
            {
                Utilities.SeletedThrottledList = Utilities.ThrottledLists[0];
            }

            selectListBox.SelectedItem = selectedItem;
            InitializeControls();
        }

        private async void MoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var moveToList = moveToListbox.SelectedItem as SharePointList;
                DisabledControls();
                await MoveFolder(moveToList.List);
            }
            finally
            {
                EnabledControls();
            }
        }

        private async void MoveToNewDocumentLibraryButton_Click(object sender, EventArgs e)
        {
            try
            {
                var libTitle = Utilities.UserPrompt("New Document Library", "Enter title for new document library");
                if (string.IsNullOrWhiteSpace(libTitle))
                {
                    MessageBox.Show("Title for new document library can't be empty.");
                    return;
                }

                DisabledControls();

                using (CsomProxy csomProxy = new CsomProxy(siteUrl, user, password))
                {
                    var docLib = await csomProxy.CreateDocumentLibraryAsyc(libTitle);
                    await MoveFolder(docLib);
                }
            }
            finally
            {

                EnabledControls();
            }
        }
        private void NotebookCheckedList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string messageFormat = "Notebooks-{0}, Section Groups-{1}, Sections-{2}";
            int notebookCount = 0;
            int sectionGroupCount = 0;
            int sectionCount = 0; ;
            var list = selectListBox.SelectedItem as SharePointList;
            foreach (int selecedIndex in notebookCheckedList.CheckedIndices)
            {
                var notebook = list.Notebooks[selecedIndex];
                notebookCount += notebook.NotebookCount;
                sectionGroupCount += notebook.FolderCount;
                sectionCount += notebook.SectionCount;
            }

            var currentNotebook = list.Notebooks[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                notebookCount += currentNotebook.NotebookCount;
                sectionGroupCount += currentNotebook.FolderCount;
                sectionCount += currentNotebook.SectionCount;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                notebookCount -= currentNotebook.NotebookCount;
                sectionGroupCount -= currentNotebook.FolderCount;
                sectionCount -= currentNotebook.SectionCount;
            }

            selectedOneNoteItemsLabel.Text = string.Format(messageFormat, notebookCount, sectionGroupCount, sectionCount);
        }

        private void SelectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.SeletedThrottledList = selectListBox.SelectedItem as SharePointList;
            InitializeControls();
        }      
        #endregion
               
        #region Helper Methods
        private void BindMoveToListBox()
        {
            if (Utilities.SeletedThrottledList != null)
            {
                moveToListbox.Enabled = true;
                var lists = new List<SharePointList>();
                Utilities.SharePointInfo.Values.ForEach(l => lists.Add(l));
                var filteredList = lists.FindAll(l => !l.Id.Equals(Utilities.SeletedThrottledList.Id)
                    && l.RootFolder.NotebookCount < Constants.SPO_LIST_VIEW_THRESHOLD
                    && l.RootFolder.SectionCount < Constants.SPO_LIST_VIEW_THRESHOLD
                    && l.FolderCount < Constants.SPO_LIST_VIEW_THRESHOLD
                    && (l.ListItemCount < Constants.INDEXABLE_SPO_LIST_SIZE_MAX
                        || (l.HtmlFileTypeIndexed && l.FileTypeIndexed && l.ContentTypeIdIndexed)));

                moveToListbox.ValueMember = "Id";
                moveToListbox.DisplayMember = "Title";
                moveToListbox.DataSource = filteredList;
            }
            else {
                moveToListbox.Enabled = false;
            }
        }

        private void CreateNotebookList(SharePointList list)
        {
            list.Notebooks.ForEach(notebook => notebookCheckedList.Items.Add(notebook.Title + string.Format(" (OneNote Items: {0})", notebook.NotebookCount + notebook.FolderCount + notebook.SectionCount)));
        }

        private void DisabledControls()
        {
            Utilities.ProcessingDialog.Show();
            selectListBox.Enabled = false;
            notebookCheckedList.Enabled = false;
            moveToListbox.Enabled = false;
            MoveButton.Enabled = false;
            moveToNewDocumentLibraryButton.Enabled = false;
            lblMsg.Text = string.Empty;
            lblMsg.Visible = false;
        }

        private void EnabledControls()
        {
            Utilities.ProcessingDialog.Hide();
            
            selectListBox.Enabled = true;
            notebookCheckedList.Enabled = true;
            moveToListbox.Enabled = true;
            MoveButton.Enabled = true;
            moveToNewDocumentLibraryButton.Enabled = true;
            lblMsg.Visible = true;
            MoveNotebooks_Load(null, null);
        }

        private void InitializeControls()
        {
            moveToNewDocumentLibraryButton.Enabled = Utilities.ThrottledLists.Count > 0;
            MoveButton.Enabled = Utilities.ThrottledLists.Count > 0;
            
            BindMoveToListBox();
            notebookCheckedList.Items.Clear();
            if (selectListBox.SelectedItem != null)
            {
                CreateNotebookList(selectListBox.SelectedItem as SharePointList);
            }

            selectListBox.Enabled = Utilities.ThrottledLists.Count > 0;
        }

        private async Task MoveFolder(SharePoint.Client.List targetList)
        {            
            SharePointFolder notebook = null;
            try
            {
                foreach (int selecedIndex in notebookCheckedList.CheckedIndices)
                {
                    notebook = Utilities.SeletedThrottledList.Notebooks[selecedIndex];
                    using (CsomProxy csomProxy = new CsomProxy(siteUrl, user, password))
                    {
                        await csomProxy.MoveAsync(notebook.Path, targetList.Title);
                    }
                }
            }
            catch
            {
                if (notebook != null)
                {
                    MessageBox.Show(string.Format("Error while moving \"{0}\" notebook.", notebook.Title));
                }
            }

            Utilities.SharePointInfo = await Utilities.RetrieveSharePointLists(siteUrl, user, password);
            if (Utilities.SiteCollectionForm != null)
            {
                Utilities.SiteCollectionForm.RefreshForm();
            }

            if (Utilities.HierarchyViewForm != null)
            {
                Utilities.HierarchyViewForm.RefreshForm();
            }

            Clipboard.SetText(notebook.SharePointList.HostUrl + targetList.RootFolder.ServerRelativeUrl);
            lblMsg.Text = string.Format("Note: Notebooks moved to - {0}", notebook.SharePointList.HostUrl + targetList.RootFolder.ServerRelativeUrl);
        }
        #endregion
    }
}
