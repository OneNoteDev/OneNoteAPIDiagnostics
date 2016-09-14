using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public partial class HierarchyViewForm : System.Windows.Forms.Form
    {        
        public HierarchyViewForm()
        {
            InitializeComponent();
        }

        #region Events        
        private void HierarchyView_Load(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = Utilities.SeletedThrottledList;
                SelectListbox.ValueMember = "Id";
                SelectListbox.DisplayMember = "Title";
                SelectListbox.DataSource = Utilities.ThrottledLists;
                SelectListbox.SelectedItem = selectedItem;
                if (SelectListbox.SelectedItem != null)
                {
                    CreateHierarchy(SelectListbox.SelectedItem as SharePointList);
                }

                SelectListbox.Enabled = Utilities.ThrottledLists.Count > 0;
            }
            finally
            {
                Utilities.ProcessingDialog.Hide();
            }
        }

        private void HierarchyViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Utilities.HierarchyViewForm = null;
        }

        private void MoveNotebookButton_Click(object sender, EventArgs e)
        {
            if (Utilities.MoveNotebooksForm == null)
            {
                Utilities.MoveNotebooksForm = new MoveNotebooksForm();
            }

            Utilities.MoveNotebooksForm.Show();
        }

        private void SelectListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.SeletedThrottledList = SelectListbox.SelectedItem as SharePointList;
            if (SelectListbox.SelectedItem != null)
            {                
                CreateHierarchy(SelectListbox.SelectedItem as SharePointList);
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Clipboard.SetText(e.Node.Text);
        }
        #endregion

        #region Helper Methods
        public void RefreshForm()
        {
            HierarchyView_Load(null, null);
        }

        private void CreateHierarchy(SharePointList list)
        {    
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            TreeNode root = treeView.Nodes.Add(CreateNodeText(list.RootFolder));
            AddStatsNode(root, list.RootFolder);
            AddNode(root, list.RootFolder.Folders);
            treeView.EndUpdate();
            root.Expand();
        }

        private static string CreateNodeText(SharePointFolder folder)
        {
            return folder.Title + " (Items: " + folder.ItemCount + ")";
        }

        private static void  AddStatsNode(TreeNode node, SharePointFolder folder)
        {
            var statNode = node.Nodes.Add("Stats");
            statNode.Nodes.Add("Items: " + folder.ItemCount);
            statNode.Nodes.Add("Notebooks: " + folder.NotebookCount);
            statNode.Nodes.Add("Folders: " + folder.FolderCount);
            statNode.Nodes.Add("Sections:" + folder.SectionCount);
            statNode.Nodes.Add(folder.Url);
            statNode.Expand();
         }

        private static void AddNode(TreeNode node, SharePointFolderCollection folders)
        {
            foreach (SharePointFolder folder in folders)
            {
                TreeNode childNode = node.Nodes.Add(CreateNodeText(folder));
                AddStatsNode(childNode, folder);
                if (folder.Folders.Count > 0)
                {
                    AddNode(childNode, folder.Folders);
                }
            }
        }
        #endregion
    }
}
