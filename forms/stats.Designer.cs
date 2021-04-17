namespace questions.forms
{
    partial class stats
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stats));
            this.fLP = new System.Windows.Forms.FlowLayoutPanel();
            this.lb = new System.Windows.Forms.Label();
            this.bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fLP
            // 
            this.fLP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fLP.AutoScroll = true;
            this.fLP.BackColor = System.Drawing.Color.Transparent;
            this.fLP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fLP.Location = new System.Drawing.Point(12, 95);
            this.fLP.Margin = new System.Windows.Forms.Padding(0);
            this.fLP.Name = "fLP";
            this.fLP.Size = new System.Drawing.Size(425, 522);
            this.fLP.TabIndex = 0;
            this.fLP.WrapContents = false;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.BackColor = System.Drawing.Color.Transparent;
            this.lb.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb.ForeColor = System.Drawing.SystemColors.Window;
            this.lb.Location = new System.Drawing.Point(57, 9);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(368, 26);
            this.lb.TabIndex = 0;
            this.lb.Text = "Статистика правильных ответов";
            // 
            // bt
            // 
            this.bt.BackColor = System.Drawing.SystemColors.Window;
            this.bt.Location = new System.Drawing.Point(176, 628);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(91, 23);
            this.bt.TabIndex = 5;
            this.bt.Text = "Ок";
            this.bt.UseVisualStyleBackColor = false;
            this.bt.Click += new System.EventHandler(this.bt_Click);
            // 
            // stats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(455, 663);
            this.ControlBox = false;
            this.Controls.Add(this.bt);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.fLP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "stats";
            this.Text = " ";
            this.Load += new System.EventHandler(this.stats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected internal System.Windows.Forms.FlowLayoutPanel fLP;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Button bt;
    }
}