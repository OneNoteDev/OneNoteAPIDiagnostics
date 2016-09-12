using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public partial class SiteCollectionForm : System.Windows.Forms.Form
	{
        internal Dictionary<Guid, SharePointList> listDict;
        bool isProcessed = false;
        
		public SiteCollectionForm()
		{
			InitializeComponent();
		}

		private async void GetInfoButton_Click(object sender, EventArgs e)
		{            
            await RetrieveSharePointInfo();
            var logText = Utilities.CreateLogText(listDict);
            ResultText.Text = Utilities.CreateLogText(listDict);
            Utilities.AddToLogFile(ResultText.Text);
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
					lib = await csomProxy.GetListByTitleAsyc(listBox.SelectedItem.ToString());
                    listDict[lib.Id] = lib;                    
					ResultText.Text = Utilities.CreateLogText(listDict);
					Utilities.AddToLogFile(ResultText.Text);
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

        Form processingDialog = null;

        private void DisabledControls()
		{
            processingDialog = Utilities.ProcessingDialog();
            processingDialog.Show();
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
            processingDialog.Hide();
			UrlText.Enabled = true;
			UserText.Enabled = true;
			PasswordText.Enabled = true;
			viewButton.Enabled = true;
			BuildIndexButton.Enabled = true;
			listBox.Enabled = true;
            viewHierarchy.Enabled = true;
            moveNotebooks.Enabled = true;
		}

		/// <summary>
		/// Validating user inputs
		/// </summary>
		private bool ValidateParameters()
		{
			if (string.IsNullOrWhiteSpace(UrlText.Text))
			{
				MessageBox.Show("Please enter SharePoint Url value.");
				UrlText.Focus();
				return false;
			}

			if (string.IsNullOrWhiteSpace(UserText.Text))
			{
				MessageBox.Show("Please enter User value.");
				UserText.Focus();
				return false;
			}

			if (string.IsNullOrWhiteSpace(PasswordText.Text))
			{
				MessageBox.Show("Please enter Password.");
				PasswordText.Focus();
				return false;
			}

			return true;
		}

        private async Task RetrieveSharePointInfo()
        {

            UrlText.Text = "https://one-my.spoppe.com/personal/admin_one_ccsctp_net";
            PasswordText.Text = "June2016";
            //PasswordText.Text = "Microsoft~1";
            UserText.Text = "admin@one.ccsctp.net";

            try
            {
                if (!isProcessed)
                {
                    if (!ValidateParameters())
                    {
                        return;
                    }

                    DisabledControls();
                    listDict = await Utilities.RetrieveSharePointLists(UrlText.Text, UserText.Text, PasswordText.Text, rdoAllList.Checked);
                    listBox.Items.Clear();
                    foreach (var listDictItem in listDict)
                    {
                        listBox.Items.Add(listDictItem.Value.Title);
                    }
                    
                    isProcessed = true;
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

        private void PasswordText_TextChanged(object sender, EventArgs e)
		{

		}

        private async void viewHierarchy_Click(object sender, EventArgs e)
        {
            await RetrieveSharePointInfo();
            HierarchyViewForm form = new HierarchyViewForm(listDict);
            form.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            isProcessed = false;
        }

        private void rdoAllList_CheckedChanged(object sender, EventArgs e)
        {
            isProcessed = false;
        }

        private async void moveNotebooks_Click(object sender, EventArgs e)
        {
            if (!rdoAllList.Checked)
            {
                rdoAllList.Checked = true;
                isProcessed = false;
            }

            await RetrieveSharePointInfo();
            MoveNotebooksForm form = new MoveNotebooksForm(listDict, this, UrlText.Text, UserText.Text, PasswordText.Text);
            form.Show();
        }
    }
}
