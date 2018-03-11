using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing_a_person
{
    public partial class LicenseForm : AbstractForm
    {
        public LicenseForm()
        {
            InitializeComponent();
            buttonYes.Focus();
        }
    }
}
