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
            this.notebookList = new System.Windows.Forms.CheckedListBox();
            this.newDocumentLibrary = new System.Windows.Forms.Button();
            this.moveToListbox = new System.Windows.Forms.ComboBox();
            this.selectListLabel = new System.Windows.Forms.Label();
            this.selectListBox = new System.Windows.Forms.ComboBox();
            this.selectList = new System.Windows.Forms.Label();
            this.btnMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notebookList
            // 
            this.notebookList.FormattingEnabled = true;
            this.notebookList.Location = new System.Drawing.Point(25, 50);
            this.notebookList.Name = "notebookList";
            this.notebookList.Size = new System.Drawing.Size(505, 379);
            this.notebookList.TabIndex = 0;
            // 
            // newDocumentLibrary
            // 
            this.newDocumentLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newDocumentLibrary.Location = new System.Drawing.Point(20, 478);
            this.newDocumentLibrary.Name = "newDocumentLibrary";
            this.newDocumentLibrary.Size = new System.Drawing.Size(214, 23);
            this.newDocumentLibrary.TabIndex = 1;
            this.newDocumentLibrary.Text = "Move To New Document Library";
            this.newDocumentLibrary.UseVisualStyleBackColor = true;
            this.newDocumentLibrary.Click += new System.EventHandler(this.newDocumentLibrary_Click);
            // 
            // moveToListbox
            // 
            this.moveToListbox.FormattingEnabled = true;
            this.moveToListbox.Location = new System.Drawing.Point(87, 441);
            this.moveToListbox.Name = "moveToListbox";
            this.moveToListbox.Size = new System.Drawing.Size(270, 21);
            this.moveToListbox.TabIndex = 4;
            // 
            // selectListLabel
            // 
            this.selectListLabel.AutoSize = true;
            this.selectListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectListLabel.Location = new System.Drawing.Point(23, 445);
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
            this.selectListBox.SelectedIndexChanged += new System.EventHandler(this.selectListBox_SelectedIndexChanged);
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
            // btnMove
            // 
            this.btnMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMove.Location = new System.Drawing.Point(371, 440);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(130, 23);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // MoveNotebooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.selectListBox);
            this.Controls.Add(this.selectList);
            this.Controls.Add(this.moveToListbox);
            this.Controls.Add(this.selectListLabel);
            this.Controls.Add(this.newDocumentLibrary);
            this.Controls.Add(this.notebookList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MoveNotebooksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move Notebooks";
            this.Load += new System.EventHandler(this.MoveNotebooks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox notebookList;
        private System.Windows.Forms.Button newDocumentLibrary;
        private System.Windows.Forms.ComboBox moveToListbox;
        private System.Windows.Forms.Label selectListLabel;
        private System.Windows.Forms.ComboBox selectListBox;
        private System.Windows.Forms.Label selectList;
        private System.Windows.Forms.Button btnMove;
    }
}