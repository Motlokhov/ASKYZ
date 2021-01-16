using System.Windows.Forms;

namespace Testing_a_person.Windows
{
    public partial class InfoNoModalForm : Form
    {
        public InfoNoModalForm(string message)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            textBox.Text = message;
            Show();
            
        }
    }
}
