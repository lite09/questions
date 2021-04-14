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

        public static void Live_test(List<test> live, Form1 f1) {
            //for (int ki = 0; ki < live.Count; ki++)
            //{
            foreach (var q in live) {
                int q_n;
                //if(){ }

                f1.rb[ki] = new RadioButton();
                f1.rb[ki].Dock = DockStyle.Fill;
                f1.tLP.Controls.Add(f1.rb[ki], 0, ki);

                f1.lb[ki] = new Label();
                f1.lb[ki].Dock = DockStyle.Fill;
                f1.lb[ki].TextAlign = ContentAlignment.MiddleCenter;
                f1.lb[ki].ForeColor = Color.FromArgb(255, 0, 255, 255);
                f1.lb[ki].Font = new Font("Times New Roman", 15, FontStyle.Bold);
                f1.lb[ki].Text = "sssssssssssssssssssssssssssssssssss";
                f1.tLP.Controls.Add(f1.lb[ki], 1, ki);

                Thread.Sleep(900);
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

            f1.tLP.Width = Convert.ToInt32(x / 1.13);
            f1.tLP.Height = y / 2;
            f1.tLP.Location = new Point(Convert.ToInt32(0 + (x * 0.05)), Convert.ToInt32(0 + (y * 0.36)));
            //f1.tLP.

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
                        if (str_paths_tests[i] == h2.Text)
                            Live_test(tests[i], f1);
                };
            }
        }
    }
}



























/*label3.Size = new Size(btn_lang, btn_h);
label3.Location = new Point(width - label1.Size.Width - btn_lang, 0);
label3.ForeColor = Color.FromArgb(255, 107, 107, 107);
            label3.BackColor = Color.FromArgb(255, colr_i, colr_i, colr_i);
            label3.AutoSize = false;
            label3.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
label3.TextAlign = ContentAlignment.MiddleRight;
            label3.Text = "RU";
            label3.Click += (s, i) =>
            {
                if (label3.Text == "EN")
                {
                    //   CultureInfo.CurrentCulture = new CultureInfo("ru-RU", false);
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
                    label3.Text = "RU";
                }
                else
                {
                    //  CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
                    label3.Text = "EN";
                }
            };*/