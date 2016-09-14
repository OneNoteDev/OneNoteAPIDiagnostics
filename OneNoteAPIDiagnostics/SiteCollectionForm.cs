using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public partial class SiteCollectionForm : System.Windows.Forms.Form
	{        
        bool isProcessed = false;
        
		public SiteCollectionForm()
		{
			InitializeComponent();
            Utilities.SiteCollectionForm = this;
        }

        #region Events
        private void AllListRadio_CheckedChanged(object sender, EventArgs e)
        {
            isProcessed = false;
        }

        private async void BuildIndexButton_Click(object sender, EventArgs e)
        {
            if (!ValidateParameters())
            {
                return;
            }

            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Select List");
                listBox.Focus();
                return;
            }

            try
            {
                DisabledControls();
                using (CsomProxy csomProxy = new CsomProxy(UrlText.Text, UserText.Text, PasswordText.Text))
                {
                    var lib = await csomProxy.GetListByTitleAsyc(listBox.SelectedItem.ToString());
                    await csomProxy.AddIndexOnListFieldsAsyc(lib);
                    isProcessed = false;
                    ViewButton_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.ToString();
            }
            finally
            {
                EnabledControls();
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Utilities.SeletedThrottledList = listBox.SelectedItem as SharePointList;
        }

        private async void ViewButton_Click(object sender, EventArgs e)
		{
            if (await RetrieveSharePointInfo())
            {
                if (Utilities.ThrottledLists.Count > 0)
                {
                    var logText = Utilities.CreateLogText(Utilities.ThrottledLists);
                    ResultText.Text = logText;
                    Utilities.AddToLogFile(ResultText.Text);
                }
                else
                {
                    ResultText.Text = "All Ok. Site doesn't contain any list which has throttling issue";
                }
            }
		}

        private async void ViewHierarchy_Click(object sender, EventArgs e)
        {
            Utilities.ProcessingDialog.Show();
            if (await RetrieveSharePointInfo())
            {
                if (Utilities.HierarchyViewForm == null)
                {
                    Utilities.HierarchyViewForm = new HierarchyViewForm();
                }

                Utilities.HierarchyViewForm.Show();
                ViewButton_Click(sender, e);
            }
        }

        private async void MoveNotebooks_Click(object sender, EventArgs e)
        {          
            if (await RetrieveSharePointInfo())
            {
                if (Utilities.MoveNotebooksForm == null)
                {
                    Utilities.MoveNotebooksForm = new MoveNotebooksForm();
                }

                Utilities.MoveNotebooksForm.Show();
                ViewButton_Click(sender, e);
            }
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            isProcessed = false;
        }
       
        private void UrlText_TextChanged(object sender, EventArgs e)
        {
            isProcessed = false;
        }
        private void UserText_TextChanged(object sender, EventArgs e)
        {
            isProcessed = false;
        }
        #endregion

        #region Helper Methods
        public void RefreshForm()
        {
            ViewButton_Click(null, null);
        }

        private void DisabledControls()
		{
            Utilities.ProcessingDialog.Show();
            ResultText.Text = string.Empty;
			UrlText.Enabled = false;
			UserText.Enabled = false;
			PasswordText.Enabled = false;
			viewButton.Enabled = false;
			BuildIndexButton.Enabled = false;
			listBox.Enabled = false;
            viewHierarchy.Enabled = false;
            moveNotebooks.Enabled = false;
        }

		private void EnabledControls()
		{
            Utilities.ProcessingDialog.Hide();
            
			UrlText.Enabled = true;
			UserText.Enabled = true;
			PasswordText.Enabled = true;
			viewButton.Enabled = true;
			BuildIndexButton.Enabled = true;
			listBox.Enabled = true;
            viewHierarchy.Enabled = true;
            moveNotebooks.Enabled = true;
		}

        private async Task<bool> RetrieveSharePointInfo()
        {
            if (!ValidateParameters())
            {
                return false;
            }

            try
            {
                if (!isProcessed)
                {
                    DisabledControls();
                    Utilities.SharePointInfo = await Utilities.RetrieveSharePointLists(UrlText.Text, UserText.Text, PasswordText.Text);
                    var selectedItem = Utilities.SeletedThrottledList;
                    listBox.ValueMember = "Id";
                    listBox.DisplayMember = "Title";
                    listBox.DataSource = Utilities.ThrottledLists;
                    listBox.SelectedItem = selectedItem;
                    isProcessed = true;
                }
            }
            catch (Exception ex)
            {
                ResultText.Text = ex.ToString();
                return false;
            }
            finally
            {
                EnabledControls();
                BuildIndexButton.Enabled = Utilities.ThrottledLists.Count > 0;
                listBox.Enabled = Utilities.ThrottledLists.Count > 0;
            }

            return true;
        }

        /// <summary>
        /// Validating user inputs
        /// </summary>
        private bool ValidateParameters()
		{
#if DEBUG
            UrlText.Text = "https://one-my.spoppe.com/personal/testuser1_one_ccsctp_net";
            UserText.Text = "testuser1@one.ccsctp.net";
            PasswordText.Text = "Microsoft~1";
#endif
            if (string.IsNullOrWhiteSpace(UrlText.Text))
			{
				MessageBox.Show("Please enter SharePoint Url value.");
				UrlText.Focus();
				return false;
			}

            Utilities.Items[Constants.SiteUrlItemKey] = UrlText.Text;

            if (string.IsNullOrWhiteSpace(UserText.Text))
			{
				MessageBox.Show("Please enter User value.");
				UserText.Focus();
				return false;
			}

            Utilities.Items[Constants.UserItemKey] = UserText.Text;

            if (string.IsNullOrWhiteSpace(PasswordText.Text))
			{
				MessageBox.Show("Please enter Password.");
				PasswordText.Focus();
				return false;
			}

            Utilities.Items[Constants.PasswordItemKey] = PasswordText.Text;

            return true;
		}
        #endregion

        private void SiteCollectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
