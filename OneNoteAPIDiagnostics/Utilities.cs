using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace Microsoft.Office.OneNote.OneNoteAPIDiagnostics
{
	public static class Utilities
    {
        public static Dictionary<string, object> Items
        {
            get;
            private set;
        }
        private static ResourceManager resources;

        static Utilities()
        {            
            resources = new ResourceManager("Resources", Assembly.GetExecutingAssembly());
            Items = new Dictionary<string, object>();
        }

        public static SiteCollectionForm SiteCollectionForm
        {
            get {
                if (Items.ContainsKey(Constants.SiteCollectionFormItemKey))
                {
                    return Items[Constants.SiteCollectionFormItemKey] as SiteCollectionForm;
                }

                return null;
            }

            set
            {
                Items[Constants.SiteCollectionFormItemKey] = value;
            }
        }

        public static HierarchyViewForm HierarchyViewForm
        {
            get
            {
                if (Items.ContainsKey(Constants.HierarchyViewFormItemKey))
                {
                    return Items[Constants.HierarchyViewFormItemKey] as HierarchyViewForm;
                }

                return null;
            }

            set
            {
                Items[Constants.HierarchyViewFormItemKey] = value;
            }
        }

        public static MoveNotebooksForm MoveNotebooksForm
        {
            get
            {
                if (Items.ContainsKey(Constants.MoveNotebooksFormItemKey))
                {
                    return Items[Constants.MoveNotebooksFormItemKey] as MoveNotebooksForm;
                }

                return null;
            }

            set
            {
                Items[Constants.MoveNotebooksFormItemKey]  = value;
            }
        }

        public static Dictionary<Guid, SharePointList> SharePointInfo
        {
            get
            {
                return Items[Constants.SharePointInfoItemKey] as Dictionary<Guid, SharePointList>;
            }

            set {
                Items[Constants.SharePointInfoItemKey] = value;

                if (value != null)
                {
                    List<SharePointList> throttledLists = new List<SharePointList>();
                    foreach (var itemDict in value)
                    {
#if DEBUG
                       throttledLists.Add(itemDict.Value);                       
#else
                        if (itemDict.Value.RootFolder.NotebookCount > Constants.SPO_LIST_VIEW_THRESHOLD
                            || itemDict.Value.RootFolder.FolderCount > Constants.SPO_LIST_VIEW_THRESHOLD
                            || itemDict.Value.RootFolder.SectionCount > Constants.SPO_LIST_VIEW_THRESHOLD
                            || (itemDict.Value.ListItemCount > Constants.INDEXABLE_SPO_LIST_SIZE_MAX
                                && (!itemDict.Value.HtmlFileTypeIndexed
                                    || !itemDict.Value.FileTypeIndexed
                                    || !itemDict.Value.ContentTypeIdIndexed)))
                        {
                            throttledLists.Add(itemDict.Value);
                        }
#endif
                    }

                    Items[Constants.SharePointThrottledListsItemKey] = throttledLists;
                }
            }
        }

        public static List<SharePointList> ThrottledLists
        {
            get
            {
                if (!Items.ContainsKey(Constants.SharePointThrottledListsItemKey))
                {
                    Items[Constants.SharePointThrottledListsItemKey] = new List<SharePointList>();
                }

                return Items[Constants.SharePointThrottledListsItemKey] as List<SharePointList>;
            }
        }

        public static SharePointList SeletedThrottledList
        {
            get
            {
                if (Items.ContainsKey(Constants.SelectedThrottledListItemKey))
                {
                    return Items[Constants.SelectedThrottledListItemKey] as SharePointList;
                }

                return null;
            }

            set
            {
                Items[Constants.SelectedThrottledListItemKey] = value;
            }
        }

        public static string GetLocalizedString(string key)
        {
            return resources.GetString(key, new CultureInfo("en-US"));
        }

        public static async Task<Dictionary<Guid, SharePointList>> RetrieveSharePointLists(string url, string user, string password)
        {
            Dictionary<Guid, SharePointList> listDict = new Dictionary<Guid, SharePointList>();
            using (CsomProxy csomProxy = new CsomProxy(url, user, password))
            {                
                List<SharePointList> lists = await csomProxy.GetListsAsyc();
                foreach (var list in lists)
                {
                    listDict.Add(list.Id, list);
                }              
            }

            return listDict;
        }

        /// <summary>
        /// Processing SharePoint list to add Logs to collection
        /// </summary>
        /// <param name="lists"> SharePoint list collection</param>
        /// <returns> task object</returns>
        public static string CreateLogText(List<SharePointList> lists)
		{
            StringBuilder sb = new StringBuilder();
            bool isMultiple = lists.Count > 1;
            foreach (var list in lists)
            {
                if (isMultiple)
                {
                    sb.Append("Title: ");
                    sb.Append(list.Title);
                    sb.Append("\r\n");
                }

                sb.Append("Url: ");
                sb.Append(list.HostUrl + list.RootFolder.Path);
                sb.Append("\r\n");

                sb.Append("Item Count: ");
                sb.Append(list.ListItemCount);
                sb.Append("\r\n");

                sb.Append("Notebook Count: ");
                sb.Append(list.NotebookCount);
                sb.Append("\r\n");

                sb.Append("Folder Count: ");
                sb.Append(list.FolderCount);
                sb.Append("\r\n");

                sb.Append("Section Count: ");
                sb.Append(list.SectionCount);
                sb.Append("\r\n");

                sb.Append("Html File Type: ");
                sb.Append(list.HtmlFileTypeIndexed);
                sb.Append("\r\n");

                sb.Append("Content Type Id: ");
                sb.Append(list.ContentTypeIdIndexed);
                sb.Append("\r\n");

                sb.Append("File Type: ");
                sb.Append(list.FileTypeIndexed);
                sb.Append("\r\n");

                if (isMultiple)
                {
                    sb.Append("-------------------------------------------\r\n");
                }                
            }

            return sb.ToString();
		}

		/// <summary>
		/// Adding Logs to file system. It suppresses the exception
		/// </summary>
		/// <param name="logInfo"> Log info text</param>
		public static void AddToLogFile(string logInfo)
		{
			try
			{
				var path = System.Environment.CurrentDirectory + "\\Logs";
				if (!System.IO.Directory.Exists(path))
				{
					System.IO.Directory.CreateDirectory(path);
				}

				using (var stream = System.IO.File.CreateText(path + "\\log.txt"))
				{
					stream.Write(logInfo);
				}
			}
			catch
			{
				// Supressing I/O exceptions
			}
		}

        public static string UserPrompt(string diaLogHeader, string dialogText)
        {
            Form userPrompt = new Form()
            {
                Width = 400,
                Height = 150,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.Fixed3D,               
                Text = diaLogHeader,
            
            };

            Label label = new Label() { Left = 23, Top = 20, Width=200, Text = dialogText };
            userPrompt.Controls.Add(label);
            
            TextBox userInputTextBox = new TextBox() { Left = 25, Top = 45, Width = 350 };
            userPrompt.Controls.Add(userInputTextBox);

            Button okButton = new Button() { Text = "Ok", Left = 25, Width = 50, Top = 75, DialogResult = DialogResult.OK };
            okButton.Click += (sender, e) => 
            {
                if (!string.IsNullOrWhiteSpace(userInputTextBox.Text))
                {
                    userPrompt.Close();
                }
            };  
                      
            userPrompt.Controls.Add(okButton);            
            userPrompt.AcceptButton = okButton;
            return userPrompt.ShowDialog() == DialogResult.OK ? userInputTextBox.Text : "";
        }

        public static Form CreateProcessingDialog()
        {
            Form processingDialog = new Form()
            {
                Width = 100,
                Height = 100,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog      
            };

            Label label = new Label() { Left = 30, Top = 15, Text = "Processing..." };
            processingDialog.Controls.Add(label);

            return processingDialog;
        }

        public static Form ProcessingDialog
        {
            get
            {
                if (!Utilities.Items.ContainsKey(Constants.ProcessingDialogFormItemKey))
                {
                    Utilities.Items[Constants.ProcessingDialogFormItemKey] = Utilities.CreateProcessingDialog();
                }

                return Utilities.Items[Constants.ProcessingDialogFormItemKey] as Form;
            }            
            set
            {
                Utilities.Items[Constants.ProcessingDialogFormItemKey] = value;
            }
        }
    }
}
