namespace CustomCardView_CSharp
{
    partial class Model
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
            this.VaultsLabel = new System.Windows.Forms.Label();
            this.VaultsComboBox = new System.Windows.Forms.ComboBox();
            this.SelectFile = new System.Windows.Forms.Button();
            this.File1List = new System.Windows.Forms.ListBox();
            this.SaveCard = new System.Windows.Forms.Button();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            //
            //VaultsLabel
            //
            this.VaultsLabel.AutoSize = true;
            this.VaultsLabel.Location = new System.Drawing.Point(36, 24);
            this.VaultsLabel.Name = "VaultsLabel";
            this.VaultsLabel.Size = new System.Drawing.Size(91, 13);
            this.VaultsLabel.TabIndex = 0;
            this.VaultsLabel.Text = "Select vault view:";
            //
            //VaultsComboBox
            //
            this.VaultsComboBox.FormattingEnabled = true;
            this.VaultsComboBox.Location = new System.Drawing.Point(39, 40);
            this.VaultsComboBox.Name = "VaultsComboBox";
            this.VaultsComboBox.Size = new System.Drawing.Size(121, 21);
            this.VaultsComboBox.TabIndex = 1;
            //
            //SelectFile
            //
            this.SelectFile.Location = new System.Drawing.Point(39, 85);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(157, 23);
            this.SelectFile.TabIndex = 2;
            this.SelectFile.Text = "Select file...";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(SelectFile_Click);
            //
            //File1List
            //
            this.File1List.FormattingEnabled = true;
            this.File1List.HorizontalScrollbar = true;
            this.File1List.Location = new System.Drawing.Point(40, 114);
            this.File1List.Name = "File1List";
            this.File1List.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.File1List.Size = new System.Drawing.Size(220, 43);
            this.File1List.TabIndex = 4;
            //
            //SaveCard
            //
            this.SaveCard.Location = new System.Drawing.Point(40, 176);
            this.SaveCard.Name = "SaveCard";
            this.SaveCard.Size = new System.Drawing.Size(107, 23);
            this.SaveCard.TabIndex = 6;
            this.SaveCard.Text = "Save data card";
            this.SaveCard.UseVisualStyleBackColor = true;
            this.SaveCard.Click += new System.EventHandler(SaveCard_Click);
            //
            //OpenFileDialog1
            //
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.Title = "Select File";
            //
            //Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 227);
            this.Controls.Add(this.SaveCard);
            this.Controls.Add(this.File1List);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.VaultsComboBox);
            this.Controls.Add(this.VaultsLabel);
            this.Name = "Form1";
            this.Text = "Custom Card View";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.Label VaultsLabel;
        internal System.Windows.Forms.ComboBox VaultsComboBox;
        internal System.Windows.Forms.Button SelectFile;
        internal System.Windows.Forms.ListBox File1List;
        internal System.Windows.Forms.Button SaveCard;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;

        #endregion
    }
}

