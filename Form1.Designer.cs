namespace questions
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tLP = new System.Windows.Forms.TableLayoutPanel();
            this.tLP_fn = new System.Windows.Forms.TableLayoutPanel();
            this.bt = new System.Windows.Forms.Button();
            this.tLP_q = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tLP
            // 
            this.tLP.BackColor = System.Drawing.Color.Transparent;
            this.tLP.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tLP.ColumnCount = 2;
            this.tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLP.Location = new System.Drawing.Point(1003, 34);
            this.tLP.Name = "tLP";
            this.tLP.RowCount = 5;
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP.Size = new System.Drawing.Size(131, 116);
            this.tLP.TabIndex = 0;
            // 
            // tLP_fn
            // 
            this.tLP_fn.AutoSize = true;
            this.tLP_fn.BackColor = System.Drawing.Color.Transparent;
            this.tLP_fn.ColumnCount = 2;
            this.tLP_fn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLP_fn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLP_fn.Location = new System.Drawing.Point(34, 267);
            this.tLP_fn.Name = "tLP_fn";
            this.tLP_fn.RowCount = 9;
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tLP_fn.Size = new System.Drawing.Size(1114, 449);
            this.tLP_fn.TabIndex = 1;
            // 
            // bt
            // 
            this.bt.BackColor = System.Drawing.SystemColors.Window;
            this.bt.Location = new System.Drawing.Point(545, 727);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(91, 23);
            this.bt.TabIndex = 5;
            this.bt.Text = "Ок";
            this.bt.UseVisualStyleBackColor = false;
            this.bt.Click += new System.EventHandler(this.button1_Click);
            // 
            // tLP_q
            // 
            this.tLP_q.BackColor = System.Drawing.Color.Transparent;
            this.tLP_q.ColumnCount = 1;
            this.tLP_q.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tLP_q.Location = new System.Drawing.Point(1003, 156);
            this.tLP_q.Name = "tLP_q";
            this.tLP_q.RowCount = 1;
            this.tLP_q.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLP_q.Size = new System.Drawing.Size(131, 64);
            this.tLP_q.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.tLP_q);
            this.Controls.Add(this.bt);
            this.Controls.Add(this.tLP_fn);
            this.Controls.Add(this.tLP);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.TableLayoutPanel tLP;
        protected internal System.Windows.Forms.TableLayoutPanel tLP_fn;
        protected internal System.Windows.Forms.TableLayoutPanel tLP_q;
        protected internal System.Windows.Forms.Button bt;
    }
}

