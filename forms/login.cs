using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using questions.classes;


namespace questions
{
    public partial class login : Form
    {
        Form1 f1 = new Form1();
        public login(Form1 f1)
        {
            this.f1 = f1;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reg rst = new reg(f1);
            rst.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<user> users = new List<user>();
            string path = "data\\login.csv";

            try
            {
                users = functions.get_users(path);
            }
            catch
            {
                MessageBox.Show("Создаите себе пользователя");

                return;
            }


            if (users.Exists(it => it.login == textBox1.Text && it.pass == functions.MD5Hash(textBox2.Text)))
            {
                user usr = users.First(it => it.login == textBox1.Text && it.pass == functions.MD5Hash(textBox2.Text));
                f1.Show();
                functions.load_tests(f1, usr);
                if (f1.reg != null)
                    f1.reg.Hide();
                Hide();
            }
            else
                MessageBox.Show("Проверьте логин и пароль");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            functions.show_stat(f1.form_stats);
        }
    }
}
