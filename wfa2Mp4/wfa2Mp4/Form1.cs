using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfa2Mp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bnSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.tbSource.Text = ofd.FileName;
            }
        }

        private void bnConvert_Click(object sender, EventArgs e)
        {
            String path = toAvi(tbSource.Text);
            MessageBox.Show("转换完毕！文件保存在" + path);
            //path = toMp4(path);
        }

        //原方法转码
        private String toMp4(String spath)
        {
            String dpath = spath.Substring(0, spath.LastIndexOf(".")) + ".mp4";

            Process p = new Process();
            //p.StartInfo.FileName = "H:\\backup\\ffmpeg-latest-win64-static\\bin\\" + "ffmpeg.exe";
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\tools\\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;
            string srcFileName = "";
            string destFileName = "";
            srcFileName = spath;
            destFileName = dpath;

            p.StartInfo.Arguments = "-y -i " + srcFileName + " -vcodec copy  -acodec copy  " + destFileName;    //执行参数

            p.StartInfo.UseShellExecute = false;  ////不使用系统外壳程序启动进程
            p.StartInfo.CreateNoWindow = true;  //不显示dos程序窗口

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardError = true;//把外部程序错误输出写到StandardError流中

            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);

            p.StartInfo.UseShellExecute = false;

            p.Start();

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.BeginErrorReadLine();//开始异步读取



            p.WaitForExit();//阻塞等待进程结束

            p.Close();//关闭进程

            p.Dispose();//释放资源
            return dpath;
        }

        //原方法转码
        private String toAvi(String spath)
        {
            String dpath = spath.Substring(0, spath.LastIndexOf(".")) + ".avi";

            Process p = new Process();
            //p.StartInfo.FileName = "H:\\backup\\ffmpeg-latest-win64-static\\bin\\" + "ffmpeg.exe";
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\tools\\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;
            string srcFileName = "";
            string destFileName = "";
            srcFileName = spath;
            destFileName = dpath;

            p.StartInfo.Arguments = "-y -i " + srcFileName + "  -r 1 -q:v " + tbQV.Text + " -ac 1 -ar 8000 " + destFileName;    //执行参数

            p.StartInfo.UseShellExecute = false;  ////不使用系统外壳程序启动进程
            p.StartInfo.CreateNoWindow = true;  //不显示dos程序窗口

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardOutput = true;

            p.StartInfo.RedirectStandardError = true;//把外部程序错误输出写到StandardError流中

            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);

            p.StartInfo.UseShellExecute = false;

            p.Start();

            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            p.BeginErrorReadLine();//开始异步读取


            
            p.WaitForExit();//阻塞等待进程结束

            p.Close();//关闭进程

            p.Dispose();//释放资源
            return dpath;
        }
        private  void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine(e.Data);
            //this.rtbContent.Text = this.rtbContent.Text + "\r\n" + e.Data;
            this.rtbContent.Text = e.Data + "\r\n" + this.rtbContent.Text;



        }

        private  void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine(e.Data);
            //this.rtbContent.Text = this.rtbContent.Text + "\r\n" + e.Data;
            this.rtbContent.Text = e.Data + "\r\n" + this.rtbContent.Text;

        }


    }
}
