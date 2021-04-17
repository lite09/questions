using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using questions.classes;
using questions.forms;

namespace questions
{
    public partial class Form1 : Form
    {
        public RadioButton[] rb = new RadioButton[5];
        public Label[] lb = new Label[5];
        public bool wait = true;

        public Label h2, stat;
        public result_current_test rct = new result_current_test();
        int x = Convert.ToInt32(SystemInformation.VirtualScreen.Width.ToString());
        int y = Convert.ToInt32(SystemInformation.VirtualScreen.Height.ToString());

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

            List<stat> stat = functions.load_stat("data\\results\\results.csv");

            rct.res_cur_test.ForeColor = Color.FromArgb(255, 200, 255, 255);
            rct.Show(); rct.Hide();
            rct.Location = new Point(x / 2 - rct.Width / 2, y / 2 - rct.Height / 2);

            Location = new Point(x / 2 - Width / 2, y / 2 - Height / 2);

            if (!Directory.Exists("data\\tests"))
            {
                MessageBox.Show("Создаите тесты для тестирования в папке data\\tests");

                Close();
            }
            user usr = new user();
            usr.last_name = "Исмагилов"; usr.first_name = "Кирилл"; usr.par = "Флуньевич"; usr.login = "lite";
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
