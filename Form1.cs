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
        public bool wait = true;
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
            user usr = new user();
            usr.last_name = "Исмагилов"; usr.first_name = "Кирилл"; usr.par = "Флуньевич";
            functions.load_tests(this, usr);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wait = false;
        }
    }
}
