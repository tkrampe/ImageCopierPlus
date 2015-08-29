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
    public partial class DatePicker : Form
    {
        public DatePicker()
        {
            InitializeComponent();

            _dateTimePickerEnd.Value = System.DateTime.Now;
            _dateTimePickerStart.Value = System.DateTime.Now.AddDays(-7d);
        }

        public void ShowDialog(Form parent, out DateTime startDate, out DateTime endDate)
        {
            startDate = DateTime.MinValue;
            endDate = DateTime.MaxValue;
                        
            if (this.ShowDialog(parent) != System.Windows.Forms.DialogResult.OK)
                Application.Exit();

            startDate = _dateTimePickerStart.Value;
            endDate = _dateTimePickerEnd.Value;
        }
    }
}
