﻿using System;
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

            rct.res_cur_test.ForeColor = Color.FromArgb(255, 200, 255, 255);
            rct.Show(); rct.Hide();

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
