using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    public partial class HierarchyViewForm : System.Windows.Forms.Form
    {
        Dictionary<Guid, SharePointList> listDict;
        public HierarchyViewForm(Dictionary<Guid, SharePointList> dict)
        {
            listDict = dict;
            InitializeComponent();
        }

        private void HierarchyView_Load(object sender, EventArgs e)
        {
            IList<SharePointList> lists = new List<SharePointList>();
            listDict.Values.ForEach(l => lists.Add(l));
            selectListbox.ValueMember = "Id";
            selectListbox.DisplayMember = "Title";
            selectListbox.DataSource = lists;
            if (selectListbox.SelectedItem != null)
            {
                CreateHierarchy(selectListbox.SelectedItem as SharePointList);
            }      
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

        private string CreateNodeText(SharePointFolder folder)
        {
            return folder.Title; // + "- Items: " + folder.ItemCount + ", Notebooks: " + folder.NotebookCount + ", Folders: " + folder.FolderCount + ", Sections:" + folder.SectionCount;
        }

        private void  AddStatsNode(TreeNode node, SharePointFolder folder)
        {
            var statNode = node.Nodes.Add("Stats");
            statNode.Nodes.Add("Items: " + folder.ItemCount);
            statNode.Nodes.Add("Notebooks: " + folder.NotebookCount);
            statNode.Nodes.Add("Folders: " + folder.FolderCount);
            statNode.Nodes.Add("Sections:" + folder.SectionCount);
            statNode.Nodes.Add(folder.Url);
            statNode.Expand();
         }

        public void AddNode(TreeNode node, SharePointFolderCollection folders)
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

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Clipboard.SetText(e.Node.Text);
        }

        private void selectListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectListbox.SelectedItem != null)
            {
                CreateHierarchy(selectListbox.SelectedItem as SharePointList);
            }
        }
    }
}
