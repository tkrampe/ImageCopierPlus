﻿namespace ImageCopierPlus
{
    partial class MainForm
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
            this._lblCameraName = new System.Windows.Forms.Label();
            this._comboBoxNames = new System.Windows.Forms.ComboBox();
            this._btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblCameraName
            // 
            this._lblCameraName.AutoSize = true;
            this._lblCameraName.Location = new System.Drawing.Point(21, 14);
            this._lblCameraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._lblCameraName.Name = "_lblCameraName";
            this._lblCameraName.Size = new System.Drawing.Size(115, 20);
            this._lblCameraName.TabIndex = 0;
            this._lblCameraName.Text = "Camera Name:";
            // 
            // _comboBoxNames
            // 
            this._comboBoxNames.FormattingEnabled = true;
            this._comboBoxNames.Location = new System.Drawing.Point(21, 38);
            this._comboBoxNames.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._comboBoxNames.Name = "_comboBoxNames";
            this._comboBoxNames.Size = new System.Drawing.Size(352, 28);
            this._comboBoxNames.TabIndex = 1;
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(398, 37);
            this._btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(112, 35);
            this._btnOk.TabIndex = 2;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 97);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._comboBoxNames);
            this.Controls.Add(this._lblCameraName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(2695, 529);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblCameraName;
        private System.Windows.Forms.ComboBox _comboBoxNames;
        private System.Windows.Forms.Button _btnOk;
    }
}