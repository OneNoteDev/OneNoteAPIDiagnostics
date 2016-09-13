namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    partial class HierarchyViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HierarchyViewForm));
            this.treeView = new System.Windows.Forms.TreeView();
            this.selectListLabel = new System.Windows.Forms.Label();
            this.SelectListbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MoveNotebookButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(12, 77);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(529, 422);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // selectListLabel
            // 
            this.selectListLabel.AutoSize = true;
            this.selectListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectListLabel.Location = new System.Drawing.Point(13, 17);
            this.selectListLabel.Name = "selectListLabel";
            this.selectListLabel.Size = new System.Drawing.Size(67, 13);
            this.selectListLabel.TabIndex = 1;
            this.selectListLabel.Text = "Select List";
            // 
            // SelectListbox
            // 
            this.SelectListbox.FormattingEnabled = true;
            this.SelectListbox.Location = new System.Drawing.Point(87, 14);
            this.SelectListbox.Name = "SelectListbox";
            this.SelectListbox.Size = new System.Drawing.Size(314, 21);
            this.SelectListbox.TabIndex = 2;
            this.SelectListbox.SelectedIndexChanged += new System.EventHandler(this.SelectListbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Note: \"Stat\" sub node shows data about the node. Selected node text will automati" +
    "cally be copied to Clipboard";
            // 
            // MoveNotebookButton
            // 
            this.MoveNotebookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveNotebookButton.Location = new System.Drawing.Point(424, 13);
            this.MoveNotebookButton.Name = "MoveNotebookButton";
            this.MoveNotebookButton.Size = new System.Drawing.Size(117, 23);
            this.MoveNotebookButton.TabIndex = 4;
            this.MoveNotebookButton.Text = "Move Notebooks";
            this.MoveNotebookButton.UseVisualStyleBackColor = true;
            this.MoveNotebookButton.Click += new System.EventHandler(this.MoveNotebookButton_Click);
            // 
            // HierarchyViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.MoveNotebookButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectListbox);
            this.Controls.Add(this.selectListLabel);
            this.Controls.Add(this.treeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HierarchyViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Hierarchy";
            this.Load += new System.EventHandler(this.HierarchyView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label selectListLabel;
        private System.Windows.Forms.ComboBox SelectListbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MoveNotebookButton;
    }
}