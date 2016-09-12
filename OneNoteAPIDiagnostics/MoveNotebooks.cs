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
        Dictionary<Guid, SharePointList> listDict;
        SiteCollectionForm form;
        List<SharePointList> lists;
        string _url;
        string _user;
        string _password;
        public MoveNotebooksForm(Dictionary<Guid, SharePointList> dict, SiteCollectionForm siteCollectionForm, string url,string user, string password)
        {
            form = siteCollectionForm;
            _url = url;
            _user = user;
            _password = password;
            listDict = dict;
            InitializeComponent();
        }
        
        private void MoveNotebooks_Load(object sender, EventArgs e)
        {
            lists = new List<SharePointList>();
            listDict.Values.ForEach(l => lists.Add(l));
            selectListBox.ValueMember = "Id";
            selectListBox.DisplayMember = "Title";
            selectListBox.DataSource = lists;
            InitializeControls();
        }

        private void InitializeControls()
        {
            BindMoveToListBox();
            notebookList.Items.Clear();
            if (selectListBox.SelectedItem != null)
            {
                CreateNotebookList(selectListBox.SelectedItem as SharePointList);
            }
        }

        private void BindMoveToListBox()
        {
            var sharePointList = selectListBox.SelectedItem as SharePointList;
            var filteredList = lists.FindAll(f => !f.Id.Equals(sharePointList.Id));
            
            moveToListbox.ValueMember = "Id";
            moveToListbox.DisplayMember = "Title";
            moveToListbox.DataSource = filteredList;            
        }

        private void CreateNotebookList(SharePointList list)
        {
            list.Notebooks.ForEach(notebook => notebookList.Items.Add(notebook.Title));
        }

        private async void newDocumentLibrary_Click(object sender, EventArgs e)
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

                using (CsomProxy csomProxy = new CsomProxy(_url, _user, _password))
                {
                    var docLib = await csomProxy.CreateDocumentLibraryAsyc(libTitle);
                    await MoveFolder(docLib);
                }
            }
            finally {

                EnabledControls();
            }
        }

        private async void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                DisabledControls();
                var moveToList = moveToListbox.SelectedItem as SharePointList;
                await MoveFolder(moveToList.List);
            }
            finally
            {
                EnabledControls();
            }
        }

        Form processingDialog = null;

        private void DisabledControls()
        {
            processingDialog = Utilities.ProcessingDialog();
            processingDialog.Show();
            selectListBox.Enabled = false;
            notebookList.Enabled = false;
            moveToListbox.Enabled = false;
            btnMove.Enabled = false;
            newDocumentLibrary.Enabled = false;
        }

        private void EnabledControls()
        {
            if (processingDialog != null)
            {
                processingDialog.Hide();
            }

            selectListBox.Enabled = true;
            notebookList.Enabled = true;
            moveToListbox.Enabled = true;
            btnMove.Enabled = true;
            newDocumentLibrary.Enabled = true;
        }

        private async Task MoveFolder(SharePoint.Client.List TargetList)
        {
            var list = selectListBox.SelectedItem as SharePointList;
            SharePointFolder notebook = null;
            try
            {
                foreach (int selecedIndex in notebookList.CheckedIndices)
                {
                    notebook = list.Notebooks[selecedIndex];
                    await MoveFolder(notebook, TargetList);
                }
            }
            catch
            {
                if (notebook != null)
                {
                    MessageBox.Show("Error while moving \"{0}\" notebook." + notebook.Title);
                }
            }

            listDict = await Utilities.RetrieveSharePointLists(_url, _user, _password, true);
            form.listDict = listDict;
            lists.Clear();
            listDict.Values.ForEach(l => lists.Add(l));
            var selectedItem = moveToListbox.SelectedItem;
            selectListBox.DataSource = lists;
            InitializeControls();
        }

        private async Task MoveFolder(SharePointFolder sourceFolder, SharePoint.Client.List targetList)
        {
            using (CsomProxy csomProxy = new CsomProxy(_url, _user, _password))
            {
                await csomProxy.MoveAsync(sourceFolder.Path, targetList.Title);
            }
       }

        private void selectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            notebookList.Items.Clear();
            CreateNotebookList(selectListBox.SelectedItem as SharePointList);
            BindMoveToListBox();
        }
    }
}
