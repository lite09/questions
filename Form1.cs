using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using questions.classes;

namespace questions
{
    public partial class Form1 : Form
    {
        public RadioButton[] rb = new RadioButton[5];
        public Label[] lb = new Label[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);

            //login log = new login(this);
            //log.Show();
            //Hide();

            if (!Directory.Exists("data\\tests"))
            {
                MessageBox.Show("Создаите тесты для тестирования в папке data\\tests");

                Close();
            }

            functions.load_tests(this);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Hide();
        }
    }
}
