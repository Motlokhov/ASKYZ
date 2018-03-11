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
    public partial class UserData : Form
    {

        public UserData(ulong id,string _password)
        {
            InitializeComponent();
            textBoxId.Text = Convert.ToString(id);
            textBoxPassword.Text = _password;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
