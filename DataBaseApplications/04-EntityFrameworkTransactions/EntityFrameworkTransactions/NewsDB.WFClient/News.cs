namespace NewsDB.WFClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class News : Form
    {
        public News()
        {
            InitializeComponent();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Program.editNews. = "OPA";
            Program.editNews.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}
