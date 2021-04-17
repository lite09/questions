using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using questions.classes;

namespace questions
{
    public partial class reg : Form
    {
        Form1 f1;
        public reg(Form1 f1)
        {
            this.f1 = f1;

            InitializeComponent();
        }

        private void reg_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint
            | ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            f1.reg = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "data\\login.csv";
            textBox1.Text = textBox1.Text.Replace(" ", "");
            textBox2.Text = textBox2.Text.Replace(" ", "");
            textBox4.Text = textBox4.Text.Replace(" ", "");
            textBox3.Text = textBox3.Text.Replace(" ", "");
            textBox6.Text = textBox6.Text.Replace(" ", "");
            textBox5.Text = textBox5.Text.Replace(" ", "");

            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены");

                return;
            }
            else
            {
                string user = textBox1.Text + ';' + textBox2.Text + ';' + textBox3.Text + ';' + textBox4.Text + ';' + textBox5.Text + ';' + functions.MD5Hash(textBox6.Text) + "\r\n";

                DirectoryInfo di = new DirectoryInfo("data");
                if (!di.Exists)
                    Directory.CreateDirectory("data");

                if (!File.Exists(path))
                {
                    FileStream login = File.Create(path);
                    login.Close();
                    File.AppendAllText(path, "last_name;first_name;par;group;login;pass\r\n");
                }

                List<user> users = functions.get_users(path);
                if (users.Exists(it => it.login == textBox5.Text))
                {
                    MessageBox.Show("Такои пользователь уже создан");

                    return;
                }

                File.AppendAllText(path, user, Encoding.Default);
                MessageBox.Show("Пользователь " + textBox5.Text + " создан");

                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
            }
        }
    } 
}
