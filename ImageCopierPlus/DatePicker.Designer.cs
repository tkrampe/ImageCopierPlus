namespace ImageCopierPlus
{
    partial class DatePicker
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
            this._btnOk = new System.Windows.Forms.Button();
            this._dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this._lblStartDate = new System.Windows.Forms.Label();
            this._dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this._lblEndDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.Location = new System.Drawing.Point(373, 73);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            // 
            // _dateTimePickerStart
            // 
            this._dateTimePickerStart.Location = new System.Drawing.Point(11, 34);
            this._dateTimePickerStart.Name = "_dateTimePickerStart";
            this._dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
            this._dateTimePickerStart.TabIndex = 1;
            // 
            // _lblStartDate
            // 
            this._lblStartDate.AutoSize = true;
            this._lblStartDate.Location = new System.Drawing.Point(9, 11);
            this._lblStartDate.Name = "_lblStartDate";
            this._lblStartDate.Size = new System.Drawing.Size(58, 13);
            this._lblStartDate.TabIndex = 2;
            this._lblStartDate.Text = "Start Date:";
            // 
            // _dateTimePickerEnd
            // 
            this._dateTimePickerEnd.Location = new System.Drawing.Point(248, 34);
            this._dateTimePickerEnd.Name = "_dateTimePickerEnd";
            this._dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
            this._dateTimePickerEnd.TabIndex = 1;
            // 
            // _lblEndDate
            // 
            this._lblEndDate.AutoSize = true;
            this._lblEndDate.Location = new System.Drawing.Point(246, 11);
            this._lblEndDate.Name = "_lblEndDate";
            this._lblEndDate.Size = new System.Drawing.Size(55, 13);
            this._lblEndDate.TabIndex = 2;
            this._lblEndDate.Text = "End Date:";
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 112);
            this.Controls.Add(this._lblEndDate);
            this.Controls.Add(this._lblStartDate);
            this.Controls.Add(this._dateTimePickerEnd);
            this.Controls.Add(this._dateTimePickerStart);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pick Start and End Dates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.DateTimePicker _dateTimePickerStart;
        private System.Windows.Forms.Label _lblStartDate;
        private System.Windows.Forms.DateTimePicker _dateTimePickerEnd;
        private System.Windows.Forms.Label _lblEndDate;

    }
}

