namespace FanRader
{
    partial class Main_Window
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Window));
            this.label_UID = new System.Windows.Forms.Label();
            this.numericUpDown_UID = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            this.label_Delay = new System.Windows.Forms.Label();
            this.GlobalTimer = new System.Windows.Forms.Timer(this.components);
            this.button_Start = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).BeginInit();
            this.SuspendLayout();
            // 
            // label_UID
            // 
            this.label_UID.Location = new System.Drawing.Point(12, 9);
            this.label_UID.Name = "label_UID";
            this.label_UID.Size = new System.Drawing.Size(41, 25);
            this.label_UID.TabIndex = 0;
            this.label_UID.Text = "UID:";
            this.label_UID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_UID
            // 
            this.numericUpDown_UID.Location = new System.Drawing.Point(59, 11);
            this.numericUpDown_UID.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericUpDown_UID.Name = "numericUpDown_UID";
            this.numericUpDown_UID.Size = new System.Drawing.Size(432, 23);
            this.numericUpDown_UID.TabIndex = 1;
            this.numericUpDown_UID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_UID.ValueChanged += new System.EventHandler(this.numericUpDown_UID_ValueChanged);
            // 
            // numericUpDown_Delay
            // 
            this.numericUpDown_Delay.Location = new System.Drawing.Point(145, 40);
            this.numericUpDown_Delay.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown_Delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Delay.Name = "numericUpDown_Delay";
            this.numericUpDown_Delay.Size = new System.Drawing.Size(346, 23);
            this.numericUpDown_Delay.TabIndex = 3;
            this.numericUpDown_Delay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Delay.ValueChanged += new System.EventHandler(this.numericUpDown_Delay_ValueChanged);
            // 
            // label_Delay
            // 
            this.label_Delay.Location = new System.Drawing.Point(12, 38);
            this.label_Delay.Name = "label_Delay";
            this.label_Delay.Size = new System.Drawing.Size(127, 25);
            this.label_Delay.TabIndex = 2;
            this.label_Delay.Text = "检测间隔(单位: 秒):";
            this.label_Delay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GlobalTimer
            // 
            this.GlobalTimer.Interval = 1000;
            this.GlobalTimer.Tick += new System.EventHandler(this.GlobalTimer_Tick);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(379, 69);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(112, 28);
            this.button_Start.TabIndex = 5;
            this.button_Start.Text = "开始检测";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "FanRader";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 109);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.numericUpDown_Delay);
            this.Controls.Add(this.label_Delay);
            this.Controls.Add(this.numericUpDown_UID);
            this.Controls.Add(this.label_UID);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(519, 148);
            this.MinimumSize = new System.Drawing.Size(519, 148);
            this.Name = "Main_Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main_Window";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_UID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_UID;
        private System.Windows.Forms.NumericUpDown numericUpDown_UID;
        private System.Windows.Forms.NumericUpDown numericUpDown_Delay;
        private System.Windows.Forms.Label label_Delay;
        private System.Windows.Forms.Timer GlobalTimer;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

