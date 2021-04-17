using System;
using System.Drawing;
using System.Windows.Forms;

namespace questions.forms
{
    public partial class stats : Form
    {
        public stats()
        {
            InitializeComponent();
        }

        private void stats_Load(object sender, EventArgs e)
        {
            lb.Location = new Point(Width / 2 - lb.Width / 2, 27);
            bt.Location = new Point(Width / 2 - bt.Width / 2, 628);
        }

        private void bt_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}