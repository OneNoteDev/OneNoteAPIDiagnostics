namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
    partial class MoveNotebooksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveNotebooksForm));
            this.notebookCheckedList = new System.Windows.Forms.CheckedListBox();
            this.moveToNewDocumentLibraryButton = new System.Windows.Forms.Button();
            this.moveToListbox = new System.Windows.Forms.ComboBox();
            this.selectListLabel = new System.Windows.Forms.Label();
            this.selectListBox = new System.Windows.Forms.ComboBox();
            this.selectList = new System.Windows.Forms.Label();
            this.MoveButton = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.selectedOneNoteItemsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notebookCheckedList
            // 
            this.notebookCheckedList.FormattingEnabled = true;
            this.notebookCheckedList.Location = new System.Drawing.Point(25, 50);
            this.notebookCheckedList.Name = "notebookCheckedList";
            this.notebookCheckedList.Size = new System.Drawing.Size(505, 364);
            this.notebookCheckedList.TabIndex = 0;
            this.notebookCheckedList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.NotebookCheckedList_ItemCheck);
            // 
            // moveToNewDocumentLibraryButton
            // 
            this.moveToNewDocumentLibraryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToNewDocumentLibraryButton.Location = new System.Drawing.Point(23, 481);
            this.moveToNewDocumentLibraryButton.Name = "moveToNewDocumentLibraryButton";
            this.moveToNewDocumentLibraryButton.Size = new System.Drawing.Size(214, 23);
            this.moveToNewDocumentLibraryButton.TabIndex = 1;
            this.moveToNewDocumentLibraryButton.Text = "Move To New Document Library";
            this.moveToNewDocumentLibraryButton.UseVisualStyleBackColor = true;
            this.moveToNewDocumentLibraryButton.Click += new System.EventHandler(this.MoveToNewDocumentLibraryButton_Click);
            // 
            // moveToListbox
            // 
            this.moveToListbox.FormattingEnabled = true;
            this.moveToListbox.Location = new System.Drawing.Point(87, 449);
            this.moveToListbox.Name = "moveToListbox";
            this.moveToListbox.Size = new System.Drawing.Size(270, 21);
            this.moveToListbox.TabIndex = 4;
            // 
            // selectListLabel
            // 
            this.selectListLabel.AutoSize = true;
            this.selectListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectListLabel.Location = new System.Drawing.Point(23, 453);
            this.selectListLabel.Name = "selectListLabel";
            this.selectListLabel.Size = new System.Drawing.Size(57, 13);
            this.selectListLabel.TabIndex = 3;
            this.selectListLabel.Text = "Move To";
            // 
            // selectListBox
            // 
            this.selectListBox.FormattingEnabled = true;
            this.selectListBox.Location = new System.Drawing.Point(101, 14);
            this.selectListBox.Name = "selectListBox";
            this.selectListBox.Size = new System.Drawing.Size(341, 21);
            this.selectListBox.TabIndex = 6;
            this.selectListBox.SelectedIndexChanged += new System.EventHandler(this.SelectListBox_SelectedIndexChanged);
            // 
            // selectList
            // 
            this.selectList.AutoSize = true;
            this.selectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectList.Location = new System.Drawing.Point(29, 18);
            this.selectList.Name = "selectList";
            this.selectList.Size = new System.Drawing.Size(67, 13);
            this.selectList.TabIndex = 5;
            this.selectList.Text = "Select List";
            // 
            // MoveButton
            // 
            this.MoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveButton.Location = new System.Drawing.Point(371, 448);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(130, 23);
            this.MoveButton.TabIndex = 7;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(22, 510);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 13);
            this.lblMsg.TabIndex = 8;
            this.lblMsg.Visible = false;
            // 
            // selectedOneNoteItemsLabel
            // 
            this.selectedOneNoteItemsLabel.AutoSize = true;
            this.selectedOneNoteItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedOneNoteItemsLabel.Location = new System.Drawing.Point(23, 421);
            this.selectedOneNoteItemsLabel.Name = "selectedOneNoteItemsLabel";
            this.selectedOneNoteItemsLabel.Size = new System.Drawing.Size(253, 13);
            this.selectedOneNoteItemsLabel.TabIndex = 9;
            this.selectedOneNoteItemsLabel.Text = "Notebooks-0, Section Groups-0, Sections-0";
            // 
            // MoveNotebooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 531);
            this.Controls.Add(this.selectedOneNoteItemsLabel);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.selectListBox);
            this.Controls.Add(this.selectList);
            this.Controls.Add(this.moveToListbox);
            this.Controls.Add(this.selectListLabel);
            this.Controls.Add(this.moveToNewDocumentLibraryButton);
            this.Controls.Add(this.notebookCheckedList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveNotebooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move Notebooks";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MoveNotebooksForm_FormClosed);
            this.Load += new System.EventHandler(this.MoveNotebooks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox notebookCheckedList;
        private System.Windows.Forms.Button moveToNewDocumentLibraryButton;
        private System.Windows.Forms.ComboBox moveToListbox;
        private System.Windows.Forms.Label selectListLabel;
        private System.Windows.Forms.ComboBox selectListBox;
        private System.Windows.Forms.Label selectList;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label selectedOneNoteItemsLabel;
    }
}