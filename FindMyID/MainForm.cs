using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using static System.IO.Path;
using FindMyIDML.Core;

namespace FindMyID
{
    public partial class MainForm : Form
    {
        private readonly DocumentHandler documentHandler;
        public MainForm()
        {
            InitializeComponent();
            documentHandler = new DocumentHandler();
            documentHandler.OnProgressChange += DocumentHandler_OnProgressChange;

        }

        private void DocumentHandler_OnProgressChange(object sender, int val)
        {
            progressBar.Value = val;
        }

        public string Path { get { return tbPath.Text; } }

        //open file dialog and insert path into text box
        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = dialog.FileName;
            }
        }

        //change cursor
        private void tbPath_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        //inset path on drop
        private void tbPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                tbPath.Text = files.First(); //select the first one 
        }

        //Drag & Drop for Main Form, not just text box
        private void MainForm_DragOver(object sender, DragEventArgs e)
        {
            tbPath_DragOver(sender, e);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            tbPath_DragDrop(sender, e);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Check if Path is Valid
            if (!string.IsNullOrWhiteSpace(tbPath.Text) || !Uri.IsWellFormedUriString(tbPath.Text, UriKind.Absolute))
            {
                //Check if the extension is correct
                if (GetExtension(tbPath.Text) == ".txt")
                {
                    progressBar.Value = 10;
                    Dictionary<string, string> processedData = documentHandler.ProcessData(tbPath.Text, tbRegex.Text);
                    if (processedData != null)
                    {
                        //Output all AI predicted IDs 
                        foreach (var item in processedData)
                        {
                            FindMyIDML.Model.ModelOutput result = documentHandler.PredictSubjectID(item.Value);
                            if (documentHandler.PredictSubjectID(item.Value).Prediction == "1")
                            {
                                MessageBox.Show($"Es geht mit einer Wahrscheinlichkeit von {result.Score[0] * 100}% um {item.Key}.");
                            };
                        }

                        if (processedData.Count == 0)
                        {
                            MessageBox.Show("Es konnten keine passenden IDs gefunden werden.");
                        }
                    }
                    progressBar.Value = 100;
                }
                else
                {
                    MessageBox.Show("Dateien vom Typen \"" + GetExtension(tbPath.Text) + "\" werden nicht unterstützt");
                }
            }
            else
            {
                MessageBox.Show("Die Datei konnte nicht gefunden werden.");
            }
        }

        private void btnCreateTrainingData_Click(object sender, EventArgs e)
        {
            documentHandler.CreateTrainingData(documentHandler.ProcessData(tbPath.Text, tbRegex.Text));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Workaround for current .net Core issue
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "https://regexr.com/",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create a MenuStrip control with a new window.
            MenuStrip ms = new MenuStrip();
            ToolStripMenuItem windowMenu = new ToolStripMenuItem("Admin");
            ToolStripMenuItem windowNewMenu = new ToolStripMenuItem("Testdaten hinzufügen", null, new EventHandler(Admin_Click));
            windowMenu.DropDownItems.Add(windowNewMenu);
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(windowMenu.DropDown)).ShowCheckMargin = true;
            ms.MdiWindowListItem = windowMenu;
            ms.Items.Add(windowMenu);
            ms.Dock = DockStyle.Top;
            this.MainMenuStrip = ms;
            this.Controls.Add(ms);
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
