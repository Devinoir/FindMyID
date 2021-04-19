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

namespace FindMyID
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        DocumentHandler documentHandler = new DocumentHandler();
        public string Path { get { return tbPath.Text; } }

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbPath.Text = dialog.FileName;
                }
            }
        }

        private void tbPath_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tbPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                tbPath.Text = files.First(); //select the first one 
        }

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
            List<string> processedData = documentHandler.ProcessData(tbPath.Text, tbRegex.Text);
            if (processedData.Count == 0)
            {
                MessageBox.Show("Es konnten keine passenden IDs gefunden werden.");
            }
            if (processedData != null)
            {
                foreach (var item in documentHandler.ProcessData(tbPath.Text, tbRegex.Text))
                {
                    MessageBox.Show(item);
                }
            }
        }

        private void btnCreateTrainingData_Click(object sender, EventArgs e)
        {
            documentHandler.CreateTrainingData(documentHandler.ProcessData(tbPath.Text, tbRegex.Text));
        }
    }
}
