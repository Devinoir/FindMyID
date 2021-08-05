
namespace FindMyID
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbRegex = new System.Windows.Forms.TextBox();
            this.btnCreateTrainingData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.AllowDrop = true;
            this.tbPath.Location = new System.Drawing.Point(12, 106);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(667, 23);
            this.tbPath.TabIndex = 0;
            this.tbPath.Text = "C:\\Users\\devin\\Desktop\\TestDaten.txt";
            this.tbPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbPath_DragDrop);
            this.tbPath.DragOver += new System.Windows.Forms.DragEventHandler(this.tbPath_DragOver);
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Location = new System.Drawing.Point(685, 106);
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(87, 23);
            this.btnOpenDoc.TabIndex = 1;
            this.btnOpenDoc.Text = "Öffnen...";
            this.btnOpenDoc.UseVisualStyleBackColor = true;
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(662, 269);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbRegex
            // 
            this.tbRegex.Location = new System.Drawing.Point(12, 203);
            this.tbRegex.Name = "tbRegex";
            this.tbRegex.Size = new System.Drawing.Size(473, 23);
            this.tbRegex.TabIndex = 3;
            this.tbRegex.Text = "[A-Z]0[0-9]{6}";
            // 
            // btnCreateTrainingData
            // 
            this.btnCreateTrainingData.Location = new System.Drawing.Point(571, 170);
            this.btnCreateTrainingData.Name = "btnCreateTrainingData";
            this.btnCreateTrainingData.Size = new System.Drawing.Size(75, 23);
            this.btnCreateTrainingData.TabIndex = 4;
            this.btnCreateTrainingData.Text = "Testdaten erstellen";
            this.btnCreateTrainingData.UseVisualStyleBackColor = true;
            this.btnCreateTrainingData.Visible = false;
            this.btnCreateTrainingData.Click += new System.EventHandler(this.btnCreateTrainingData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "FindMyID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(401, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Schritt 1: Bitte geben Sie den Pfad zu dem zu überprüfenden Dokument an.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(482, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Schritt 2: Bitte geben Sie das Format der Identifikationsnummer als regulären Aus" +
    "druck an.\r\n";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(219, 185);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(30, 15);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "hier.";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hilfe für reguläre Ausdrücke finden Sie";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 269);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(644, 23);
            this.progressBar.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 314);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateTrainingData);
            this.Controls.Add(this.tbRegex);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOpenDoc);
            this.Controls.Add(this.tbPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "FindMyID";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbRegex;
        private System.Windows.Forms.Button btnCreateTrainingData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

