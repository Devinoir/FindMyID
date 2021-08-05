using FindMyIDML.Core;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace FindMyID
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public string Path { get { return tbPath.Text; } }

        //open file dialog and insert path into text box
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

        //change cursor
        private void tbPath_DragOver(object sender, DragEventArgs e)
        {

        }

        //inset path on drop
        private void tbPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                tbPath.Text = files.First(); //select the first one 
        }

        //Drag & Drop for Main Form, not just text box
        private void AdminForm_DragOver(object sender, DragEventArgs e)
        {
            tbPath_DragOver(sender, e);
        }

        private void AdminForm_DragDrop(object sender, DragEventArgs e)
        {
            tbPath_DragDrop(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TrainDataHandling.TrainData(tbPath.Text, Assembly.GetExecutingAssembly().Location);
        }
    }
}
