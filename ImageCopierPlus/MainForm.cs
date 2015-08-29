using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageCopierPlus
{
    public partial class MainForm : Form
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (string name in GlobalSettings.Instance.CameraNames)
                _comboBoxNames.Items.Add(name);

            DatePicker picker = new DatePicker();
            picker.ShowDialog(this, out _startDate, out _endDate);
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(GlobalSettings.Instance.CardSourceDirectory))
            {
                MessageBox.Show("No image directory found at " + GlobalSettings.Instance.CardSourceDirectory);
                return;
            }

            if (_comboBoxNames.Text.Length == 0)
            {
                MessageBox.Show("Must select a camera name");
                return;
            }

            string title = _startDate.ToShortDateString() + " to " + _endDate.ToShortDateString();
            title = title.Replace("/" + _startDate.Year, string.Empty);
            title = title.Replace("/", "-");

            string photoSetDirectory = System.IO.Path.Combine(GlobalSettings.Instance.OutputDirectory, title);

            if (!System.IO.Directory.Exists(photoSetDirectory))
                System.IO.Directory.CreateDirectory(photoSetDirectory);

            string cameraOuptutDirectory = System.IO.Path.Combine(photoSetDirectory, _comboBoxNames.Text);

            if (System.IO.Directory.Exists(cameraOuptutDirectory))
            {
                if (MessageBox.Show("Camera output directory already exists.  Continue anyway?", "Warning", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                    return;
            }

            if (System.IO.File.Exists(GlobalSettings.Instance.FastCopyLogFilePath))
                System.IO.File.Delete(GlobalSettings.Instance.FastCopyLogFilePath);

            this.Enabled = false;

            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = GlobalSettings.Instance.FastCopyExecutablePath;
                proc.StartInfo.Arguments = "/cmd=diff /error_stop /force_start /verify /force_close /log /logfile=\"" + GlobalSettings.Instance.FastCopyLogFilePath + "\" \"" + GlobalSettings.Instance.CardSourceDirectory + "\" /to=\"" + cameraOuptutDirectory + "\"";
                proc.Start();

                proc.WaitForExit();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error running FastCopy" + System.Environment.NewLine + err.ToString());
                return;
            }

            this.Enabled = true;

            bool hadErrors = true;
            int totalFiles = 0;

            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(GlobalSettings.Instance.FastCopyLogFilePath))
                {
                    int lineIndex = 0;

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        if (lineIndex == 7)
                        {
                            if (line.Trim() == "No Errors")
                                hadErrors = false;
                        }
                        else if (lineIndex == 11)
                        {
                            System.Text.RegularExpressions.Match numFilesMatch = System.Text.RegularExpressions.Regex.Match(line, @"TotalFiles = (.*) \(.*\)", System.Text.RegularExpressions.RegexOptions.Singleline);

                            if (numFilesMatch.Success && numFilesMatch.Groups.Count > 1)
                                totalFiles = int.Parse(numFilesMatch.Groups[1].Value);

                            //Ex. TotalFiles = 38 (0)
                        }
                        //else if (lineIndex == 18)
                        //{
                        //    //Result : (ErrFiles : 0 / ErrDirs : 0)
                        //}

                        lineIndex++;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error reading log" + System.Environment.NewLine + err.ToString());
                return;
            }

            if (hadErrors)
            {
                MessageBox.Show("FastCopy error occured click 'OK' to see logfile");
                System.Diagnostics.Process.Start("\"" + GlobalSettings.Instance.FastCopyLogFilePath + "\"");
                return;
            }

            System.Diagnostics.Process.Start("\"" + cameraOuptutDirectory + "\"");

            if (MessageBox.Show(totalFiles + " files copied successfully.  Open in ImageViewerPlus?", "Success", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process imgViewerProc = new System.Diagnostics.Process();
                    imgViewerProc.StartInfo.FileName = GlobalSettings.Instance.ImageViewerPlusExecutablePath;
                    imgViewerProc.StartInfo.Arguments = "\"" + cameraOuptutDirectory + "\"";
                    imgViewerProc.StartInfo.UseShellExecute = true;
                    imgViewerProc.Start();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error starting ImageViewerPlus" + System.Environment.NewLine + err.ToString());
                }
            }

            if (MessageBox.Show("Erase images from card?", "Success", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.IO.Directory.Delete(GlobalSettings.Instance.CardParentDirectory, true);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error deleting images from card" + Environment.NewLine + err.ToString());
                    return;
                }

                MessageBox.Show("Images deleted from card successfully.");
            }
        }
    }
}
