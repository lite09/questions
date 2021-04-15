using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace questions.classes
{
    static class functions
    {
        public static List<user> get_users(string path)
        {
            List<user> users = new List<user>();
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    HeaderValidated = null,
                    MissingFieldFound = null,
                    Encoding = Encoding.GetEncoding(1251),
                };

                using (var reader = new StreamReader(path, Encoding.GetEncoding(1251)))
                using (var csv = new CsvReader(reader, config))
                {
                    var l = csv.GetRecords<user>();
                    users = l.ToList();
                }

                return users;
            }
            catch (BadDataException i)
            {
                MessageBox.Show("Ошибка загрузки данных из фаила\r\n" + path);
                return null;
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static List<List<test>> get_tests()
        {
            string path = "data\\tests";
            string[] str_paths_tests = Directory.GetFiles(path);

            List<List<test>> tests = new List<List<test>>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HeaderValidated = null,
                MissingFieldFound = null,
                Encoding = Encoding.GetEncoding(1251),
            };

            for (int i = 0; i < str_paths_tests.Length; i++)
            {

                try
                {
                    using (var reader = new StreamReader(str_paths_tests[i], Encoding.GetEncoding(1251)))
                    using (var csv = new CsvReader(reader, config))
                    {
                        var l = csv.GetRecords<test>();
                        var test = new List<test>();
                        test = l.ToList();
                        tests.Add(test);
                    }

                }
                    catch (BadDataException ki)
                {
                    MessageBox.Show("Ошибка загрузки данных из фаила\r\n" + str_paths_tests[i]);
                    return null;
                }
            }

            return tests;
        }

        public static void Live_test(object ob) {
            object[] inf = ob as object[];
            List<test> live = (List<test>)inf[0];
            Form1 f1 = (Form1)inf[1];
            f1.tLP_q.Invoke((MethodInvoker)(() => f1.tLP_q.Show()));
            //for (int ki = 0; ki < live.Count; ki++)
            //{
            foreach (var q in live) {
                string[] s_q = { q.q_0, q.q_1, q.q_2, q.q_3, q.q_4 };
                int q_n = s_q.Length;
                f1.wait = true;
                f1.tLP.Invoke((MethodInvoker)(() => f1.tLP.Controls.Clear()));
                f1.tLP_q.Invoke((MethodInvoker)(() => f1.tLP_q.Controls.Clear()));

                Label lb_q = new Label();
                lb_q.Dock = DockStyle.Fill;
                lb_q.TextAlign = ContentAlignment.MiddleCenter;
                lb_q.ForeColor = Color.FromArgb(255, 0, 255, 150);
                lb_q.Font = new Font("Times New Roman", 20, FontStyle.Bold);
                lb_q.Text = q.question;
                f1.tLP_q.Invoke((MethodInvoker)(() => f1.tLP_q.Controls.Add(lb_q)));

                for (int i = 0; i < s_q.Length; i++)
                    if (s_q[i] == "")
                    {
                        q_n = i;
                        break;
                    }

                for (int i = 0; i < q_n; i++)
                {

                    f1.rb[i] = new RadioButton();
                    f1.rb[i].Dock = DockStyle.Fill;
                    f1.tLP.Invoke((MethodInvoker)(() => f1.tLP.Controls.Add(f1.rb[i], 0, i)));

                    f1.lb[i] = new Label();
                    f1.lb[i].Dock = DockStyle.Fill;
                    f1.lb[i].TextAlign = ContentAlignment.MiddleCenter;
                    f1.lb[i].ForeColor = Color.FromArgb(255, 0, 255, 255);
                    f1.lb[i].Font = new Font("Times New Roman", 15, FontStyle.Bold);
                    f1.lb[i].Text = s_q[i];
                    f1.tLP.Invoke((MethodInvoker)(() => f1.tLP.Controls.Add(f1.lb[i], 1, i)));
                }
                //f1.tLP.PerformLayout();
                //return;
                while (f1.wait)
                    Thread.Sleep(90);

            }
    }

        public static void load_tests(Form1 f1)
        {
            string path = "data\\tests";
            string []str_paths_tests = Directory.GetFiles(path);
            List<List<test>> tests = get_tests();

            LinkLabel[] lbs = new LinkLabel[str_paths_tests.Length];
            int x = f1.Width, y = f1.Height;

            Label h2 = new Label(); h2.Text = "Выберите тест"; h2.ForeColor = Color.FromArgb(255, 255, 255, 255);
                h2.Font = new Font("Times New Roman", 25, FontStyle.Bold); h2.AutoSize = true; h2.BackColor = Color.Transparent;
                f1.Controls.Add(h2);
                h2.Location = new Point(Convert.ToInt32(x / 2 - h2.Width / 2), Convert.ToInt32(y / 7));

            //  сетка для вопросов
            f1.tLP_q.Width = x;
            f1.tLP_q.Height = Convert.ToInt32(y / 5);
            f1.tLP_q.Location = new Point(0, Convert.ToInt32(0 + (y * 0.25)));
            f1.tLP_q.Hide();

            //  сетка для вариантов ответов
            f1.tLP.Width = Convert.ToInt32(x / 1.13);
            f1.tLP.Height = Convert.ToInt32(y / 2.52);
            f1.tLP.Location = new Point(Convert.ToInt32(0 + (x * 0.05)), Convert.ToInt32(0 + (y * 0.45)));
            //f1.tLP.

            f1.bt.Location = new Point(x / 2 - f1.bt.Width / 2, y - 70);

            for (int i = 0; i < str_paths_tests.Length; i++)
            {
                LinkLabel lb = new LinkLabel();
                lb.AutoSize = true;
                lb.Dock = DockStyle.Fill;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = Path.GetFileNameWithoutExtension(str_paths_tests[i]);
                lb.Font = new Font("Times New Roman", 15, FontStyle.Bold);
                //lb.ForeColor = Color.FromArgb(255, 255, 255, 255);
                lb.LinkColor = Color.FromArgb(255, 0, 255, 255);
                lb.ActiveLinkColor = Color.FromArgb(255, 255, 255, 255);
                f1.tLP_fn.Controls.Add(lb);

                lb.Click += (s, il) =>
                {
                    f1.tLP_fn.Hide();
                    h2.Text = s.ToString().Split(new[] { "Text:" }, StringSplitOptions.None)[1].Trim(' '); ;
                    h2.Location = new Point(Convert.ToInt32(x / 2 - (h2.Width / 2)), Convert.ToInt32(y / 7));

                    for (i = 0; i < str_paths_tests.Length; i++)
                        if (Path.GetFileNameWithoutExtension(str_paths_tests[i]) == h2.Text)
                        {
                            object []ob = { tests[i], f1 };
                            ThreadPool.QueueUserWorkItem(Live_test, ob);
                            //Live_test(ob);
                        }
                };
            }
        }
    }
}


