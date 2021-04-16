using CsvHelper;
using CsvHelper.Configuration;
using questions.forms;
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
			double proc = 0, good = 0, num_q = 0;
			List<test> live = (List<test>)inf[0];
			Form1 f1 = (Form1)inf[1];
			f1.tLP_q.Invoke((MethodInvoker)(() => f1.tLP_q.Show()));

			//  статистика
			int x = f1.Width, y = f1.Height;

			f1.Invoke((MethodInvoker)(() => f1.Controls.Remove(f1.stat)));
			f1.stat = new Label();
			f1.stat.Text = "0 - " + live.Count; f1.stat.ForeColor = Color.FromArgb(255, 200, 255, 255);
			f1.stat.Font = new Font("Times New Roman", 15, FontStyle.Bold); f1.stat.AutoSize = true; f1.stat.BackColor = Color.Transparent;
			f1.Invoke((MethodInvoker)(() => f1.Controls.Add(f1.stat)));
			f1.stat.Invoke((MethodInvoker)(() => f1.stat.Location = new Point(Convert.ToInt32(x - f1.stat.Width - x / 36), Convert.ToInt32(y / 9))));

			foreach (var q in live) {
				num_q++;
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
					f1.rb[i].Dock = DockStyle.Right;
					//f1.rb[i].Anchor = AnchorStyles.None;
					//f1.rb[i].TextAlign = ContentAlignment.MiddleRight;
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

				//  был ли ответ правильныи
				for (int i = 0; i < q_n; i++)
				{
					if (f1.rb[i].Checked)
						if (q.answer == i.ToString())
							good++;
				}

				//  обновляем статистику
				proc = Math.Round (good / num_q * 100, 0);
				f1.stat.Invoke((MethodInvoker)(() => f1.stat.Text = num_q + " - " + live.Count + " : " + proc + "%"));
				f1.stat.Invoke((MethodInvoker)(() => f1.stat.Location = new Point(Convert.ToInt32(x - f1.stat.Width - x / 36), Convert.ToInt32(y / 9))));
			}

			//  сохраняем  результаты теста
			string s_res = "data\\results";
			DirectoryInfo di = new DirectoryInfo(s_res);
			if (!di.Exists)
				Directory.CreateDirectory(s_res);

			if (!File.Exists(s_res + "\\results.csv"))
			{
				FileStream reslts = File.Create(s_res + "\\results.csv");
				reslts.Close();
				File.AppendAllText(s_res + "\\results.csv", "name_test;login;fio;percent\r\n");
			}

			user usr = (user)inf[3];
			string name_test = (string)inf[2];
			string login = usr.login;
			string fio = usr.last_name + " " + usr.first_name + " " + usr.par;
			string result = name_test + ";" + login + ";" + fio  + ";" + proc + "\r\n";
			File.AppendAllText(s_res + "\\results.csv", result, Encoding.Default);

			//  отчиска элементов управления
			//f1.Invoke((MethodInvoker)(() => f1.tLP_q.Controls.Clear()));
			//f1.Invoke((MethodInvoker)(() => f1.tLP.Controls.Clear()));
			f1.Invoke((MethodInvoker)(() => f1.Controls.Remove(f1.h2)));		//	удаляем заголовок
			f1.Invoke((MethodInvoker)(() => f1.tLP.Hide()));					//	скрываем сетку с вариантами ответов
			f1.Invoke((MethodInvoker)(() => f1.tLP_fn.Controls.Clear()));		//	отчистка сетки с тестоами
			f1.Invoke((MethodInvoker)(() => f1.tLP_fn.Show()));                 //	отображение сетки с тестоами

			load_tests(f1, usr);

			f1.Invoke((MethodInvoker)(() => f1.rct.res_cur_test.Text = "Поздравляем " + fio + " с успешно проиденным тестом!"));
			f1.Invoke((MethodInvoker)(() => f1.rct.Show()));
		}

		public static void load_tests(Form1 f1, user usr)
		{
			int x = f1.Width, y = f1.Height;

			string path = "data\\tests";
			string []str_paths_tests = Directory.GetFiles(path);
			List<List<test>> tests = get_tests();

			//  ФИО
			Label fio = new Label();
			fio.Text = usr.last_name + " " + usr.first_name + " " + usr.par; fio.ForeColor = Color.FromArgb(255, 200, 255, 255);
			fio.Font = new Font("Times New Roman", 15, FontStyle.Bold); fio.AutoSize = true; fio.BackColor = Color.Transparent;
			f1.Invoke((MethodInvoker)(() => f1.Controls.Add(fio)));
			fio.Invoke((MethodInvoker)(() => fio.Location = new Point(Convert.ToInt32(x - fio.Width - x/36), Convert.ToInt32(y / 12))));



			f1.h2 = new Label(); f1.h2.Text = "Выберите тест"; f1.h2.ForeColor = Color.FromArgb(255, 255, 255, 255);
				f1.h2.Font = new Font("Times New Roman", 25, FontStyle.Bold); f1.h2.AutoSize = true; f1.h2.BackColor = Color.Transparent;
				f1.Invoke((MethodInvoker)(() => f1.Controls.Add(f1.h2)));
				f1.h2.Invoke((MethodInvoker)(() => f1.h2.Location = new Point(Convert.ToInt32(x / 2 - f1.h2.Width / 2), Convert.ToInt32(y / 7))));

			//  сетка для вопросов
			f1.tLP_q.Width = x;
			f1.tLP_q.Height = Convert.ToInt32(y / 5);
			f1.tLP_q.Location = new Point(0, Convert.ToInt32(0 + (y * 0.25)));
			f1.Invoke((MethodInvoker)(() => f1.tLP_q.Hide()));

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
				f1.Invoke((MethodInvoker)(() => f1.tLP_fn.Controls.Add(lb)));

				lb.Click += (s, il) =>
				{
					f1.tLP_fn.Hide();
					f1.tLP.Show();

					string name_of_file_test = s.ToString().Split(new[] { "Text:" }, StringSplitOptions.None)[1].Trim(' ');
					f1.h2.Text = name_of_file_test;
					f1.h2.Location = new Point(Convert.ToInt32(x / 2 - (f1.h2.Width / 2)), Convert.ToInt32(y / 7));

					for (i = 0; i < str_paths_tests.Length; i++)
						if (Path.GetFileNameWithoutExtension(str_paths_tests[i]) == name_of_file_test)
						{
							object []ob = { tests[i], f1, name_of_file_test, usr };
							ThreadPool.QueueUserWorkItem(Live_test, ob);
							//Live_test(ob);
						}
				};
			}
		}
	}
}


