using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Funcitons;
using static Funcitons.NormalFunc;

namespace FanRader
{
    public partial class Main_Window : Form
    {
        //函数========================================================================================
        //Json类=====================================================================================
        public class JsonConfig
        {
            public class Config
            {
                public class Root
                {
                    public long uid { get; set; }
                    public int testDelay { get; set; }
                    public bool isFirstUse { get; set; }
                }
            }

            public class API
            {
                public class Root
                {
                    public int code { get; set; }
                    public string message { get; set; }
                    public int ttl { get; set; }
                    public JsonConfig.API.Data data { get; set; }

                }

                public class Data
                {
                    public long mid { get; set; }
                    public int following { get; set; }
                    public int whisper { get; set; }
                    public int follower { get; set; }
                }
            }
        }
        //变量========================================================================================
        public static string RunPath = Directory.GetCurrentDirectory();
        public static string ConfigPath = $"{RunPath}\\config.json";
        public static string WindowTitle = "FanRader控制面板";
        public static string APIUrl = "https://api.bilibili.com";

        public static JsonConfig.Config.Root GlobalConfig;
        public static JsonConfig.API.Root APIConfig;
        public static JsonConfig.API.Root LastAPIConfig;
        //事件========================================================================================
        public Main_Window()
        {
            InitializeComponent();

            try
            {
                this.Text = WindowTitle;

                //写入config
                if (!File.Exists(ConfigPath))
                {
                    GlobalConfig = new JsonConfig.Config.Root
                    {
                        uid = 1,
                        testDelay = 1,
                        isFirstUse = true
                    };

                    WriteJson<JsonConfig.Config.Root>(ConfigPath, GlobalConfig);
                }

                //读config
                GlobalConfig = ReadJson<JsonConfig.Config.Root>(ConfigPath);

                numericUpDown_UID.Value = GlobalConfig.uid;
                numericUpDown_Delay.Value = GlobalConfig.testDelay;


                if (GlobalConfig.isFirstUse)
                {
                    notifyIcon.ShowBalloonTip(3000, "欢迎使用FanRader", "一款帮你实时监测粉丝状态的小工具！", ToolTipIcon.Info);
                    GlobalConfig.isFirstUse = false;
                    WriteJson<JsonConfig.Config.Root>(ConfigPath, GlobalConfig);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"在初始化程序时发生错误!\n\n错误原因: \n\n{ex}", "发生错误\n\n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;

                this.BringToFront();
            }


        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if (button_Start.Text == "开始检测")
            {
                button_Start.Text = "停止检测";

                GlobalTimer.Interval = GlobalConfig.testDelay * 1000;
                GlobalTimer.Enabled = true;

            }
            else if (button_Start.Text == "停止检测")
            {
                button_Start.Text = "开始检测";

                GlobalTimer.Enabled = false;
            }
        }

        private async void GlobalTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    LastAPIConfig = APIConfig;
                    File.WriteAllText($"{RunPath}\\api.json", await http.GetStringAsync($"{APIUrl}/x/relation/stat?vmid={GlobalConfig.uid}&jsonp=jsonp"));
                    APIConfig = ReadJson<JsonConfig.API.Root>($"{RunPath}\\api.json");

                    if (APIConfig.code == 0 && APIConfig.message == "0")
                    {
                        if (APIConfig.data.follower == LastAPIConfig.data.follower)
                        {
                            //无事发生
                        }
                        else if (APIConfig.data.follower > LastAPIConfig.data.follower)
                        {
                            notifyIcon.ShowBalloonTip(3000, "您的粉丝数有变动", $"您增加了 {APIConfig.data.follower - LastAPIConfig.data.follower} 位粉丝!\n当前粉丝: {APIConfig.data.follower}  |  此前粉丝: {LastAPIConfig.data.follower}", ToolTipIcon.Info);
                        }
                        else if (APIConfig.data.follower < LastAPIConfig.data.follower)
                        {
                            notifyIcon.ShowBalloonTip(3000, "您的粉丝数有变动", $"您减少了 {LastAPIConfig.data.follower - APIConfig.data.follower} 位粉丝!\n当前粉丝: {APIConfig.data.follower}  |  此前粉丝: {LastAPIConfig.data.follower}", ToolTipIcon.Warning);
                        }
                    }
                    else
                    {
                        notifyIcon.ShowBalloonTip(3000, "在获取API数据时发生错误!", $"错误代码: {APIConfig.code}\n错误信息: {APIConfig.message}", ToolTipIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"在获取API数据时发生错误!\n\n错误原因:\n{ex}", "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void Main_Window_Load(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    if (!File.Exists($"{RunPath}\\api.json")) File.WriteAllText($"{RunPath}\\api.json", await http.GetStringAsync($"{APIUrl}/x/relation/stat?vmid={GlobalConfig.uid}&jsonp=jsonp"));

                    LastAPIConfig = ReadJson<JsonConfig.API.Root>($"{RunPath}\\api.json");

                    File.WriteAllText($"{RunPath}\\api.json", await http.GetStringAsync($"{APIUrl}/x/relation/stat?vmid={GlobalConfig.uid}&jsonp=jsonp"));
                    APIConfig = ReadJson<JsonConfig.API.Root>($"{RunPath}\\api.json");

                    if (APIConfig.code == 0 && APIConfig.message == "0")
                    {
                        if (APIConfig.data.follower == LastAPIConfig.data.follower)
                        {
                            //无事发生
                        }
                        else if (APIConfig.data.follower > LastAPIConfig.data.follower)
                        {
                            notifyIcon.ShowBalloonTip(3000, "在您没有使用此软件的期间", $"您增加了 {APIConfig.data.follower - LastAPIConfig.data.follower} 位粉丝!\n当前粉丝: {APIConfig.data.follower}  |  此前粉丝: {LastAPIConfig.data.follower}", ToolTipIcon.Info);
                        }
                        else if (APIConfig.data.follower < LastAPIConfig.data.follower)
                        {
                            notifyIcon.ShowBalloonTip(3000, "在您没有使用此软件的期间", $"您减少了 {LastAPIConfig.data.follower - APIConfig.data.follower} 位粉丝!\n当前粉丝: {APIConfig.data.follower}  |  此前粉丝: {LastAPIConfig.data.follower}", ToolTipIcon.Warning);
                        }
                    }
                    else
                    {
                        notifyIcon.ShowBalloonTip(3000, "在获取API数据时发生错误!", $"错误代码: {APIConfig.code}\n错误信息: {APIConfig.message}", ToolTipIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"在获取API数据时发生错误!\n\n错误原因:\n{ex}", "发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void numericUpDown_UID_ValueChanged(object sender, EventArgs e)
        {
            GlobalConfig.uid = (long)numericUpDown_UID.Value;
            WriteJson<JsonConfig.Config.Root>(ConfigPath, GlobalConfig);
        }

        private void numericUpDown_Delay_ValueChanged(object sender, EventArgs e)
        {
            GlobalConfig.testDelay = (int)numericUpDown_Delay.Value;
            WriteJson<JsonConfig.Config.Root>(ConfigPath, GlobalConfig);
        }
    }
}
