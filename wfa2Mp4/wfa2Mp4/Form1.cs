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
using System.IO;

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
            String path, path_del;
            path = WaterMarkMkv(tbSource.Text,"1", " overlay = main_w - overlay_w:main_h - overlay_h - 20[out]");
            path_del = path;
            path = WaterMarkMkv(path, "2", "  overlay=0:main_h-overlay_h[out]");
            File.Delete(path_del);
            path_del = path;
            path = WaterMarkMkv(path, "3", " overlay=0:50[out]");
            File.Delete(path_del);
            path_del = path;
            path = toMp4(path);
            File.Delete(path_del);
            MessageBox.Show("转换完毕！文件保存在" + path);

            this.rtbContent.Text = "\r\n\r\n转换完毕！文件保存在" + path + "\r\n" + this.rtbContent.Text;
            return;
            /*
            String path = toMkv(tbSource.Text);
            String path_del = path;
            path = toAvi(path);
            //File.Delete(path_del);
            path_del = path;
            path = WaterMark(path, "1"," overlay = main_w - overlay_w:main_h - overlay_h - 20[out]");
            //File.Delete(path_del);
            path_del = path;
            path = WaterMark(path, "2", "  overlay=0:main_h-overlay_h[out]");
            //File.Delete(path_del);
            path_del = path;
            path = WaterMark(path, "3", " overlay=0:50[out]","20");
            //File.Delete(path_del);
            MessageBox.Show("转换完毕！文件保存在" + path);

            this.rtbContent.Text = "\r\n\r\n转换完毕！文件保存在" + path + "\r\n" + this.rtbContent.Text;
            //path = toMp4(path);
            */
        }


        //原方法转码
        private String WaterMarkMkv(String spath, String id, String overlay, String qv = "10")
        {
            String dpath = spath.Substring(0, spath.LastIndexOf(".")) + "_copy" + ".mkv";

            if (!qv.Equals("10"))
                qv = tbQV.Text;

            Process p = new Process();
            p.StartInfo.WorkingDirectory = System.Environment.CurrentDirectory + "\\tools\\";
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\tools\\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;
            String srcFileName = spath;
            String destFileName = dpath;
            String marker = System.Environment.CurrentDirectory + "\\tools\\" + id + ".png";
            marker = marker.Replace('\\', '/');
            marker = id + ".png";

            p.StartInfo.Arguments = "-y -i " + srcFileName + "  -vf \"movie = " + marker + "[logo]; [in] [logo] " + overlay + "\"  -q:v 0 " + destFileName;    //执行参数
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
        private String WaterMark(String spath,String id,String overlay,String qv = "10")
        {
            String dpath = spath.Substring(0, spath.LastIndexOf(".")) + "_" + id + ".avi";

            if(!qv.Equals("10"))
                qv = tbQV.Text;

            Process p = new Process();
            p.StartInfo.WorkingDirectory = System.Environment.CurrentDirectory + "\\tools\\";
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\tools\\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;
            String srcFileName = spath;
            String destFileName = dpath;
            String marker = System.Environment.CurrentDirectory + "\\tools\\" + id + ".png";
            marker = marker.Replace('\\', '/');
            marker = id + ".png";

            p.StartInfo.Arguments = "-y -i " + srcFileName + "  -vf \"movie = "+marker+"[logo]; [in] [logo] "+ overlay +"\"  -q:v "+ qv +" " + destFileName;    //执行参数
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
        private String toMkv(String spath)
        {
            String dpath = spath.Substring(0, spath.LastIndexOf(".")) + "_copy.mkv";

            Process p = new Process();
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\tools\\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;
            string srcFileName = "";
            string destFileName = "";
            srcFileName = spath;
            destFileName = dpath;

            p.StartInfo.Arguments = "-y -i " + srcFileName + " -q:v 0 " + destFileName;    //执行参数

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
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\tools\\ffmpeg.exe";
            p.StartInfo.UseShellExecute = false;
            string srcFileName = "";
            string destFileName = "";
            srcFileName = spath;
            destFileName = dpath;

            //p.StartInfo.Arguments = "-y -i " + srcFileName + "  -r 1 -q:v 0 -ac 1 -ar 8000 " + destFileName;    //执行参数
            p.StartInfo.Arguments = "-y -i " + srcFileName + " -q:v 0  " + destFileName;    //执行参数

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
            try
            {
                //this.rtbContent.Text = this.rtbContent.Text + "\r\n" + e.Data;
                this.rtbContent.Text = e.Data + "\r\n" + this.rtbContent.Text;
            }catch(Exception e1)
            {

            }



        }

        private  void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine(e.Data);
            try
            {
                //this.rtbContent.Text = this.rtbContent.Text + "\r\n" + e.Data;
                this.rtbContent.Text = e.Data + "\r\n" + this.rtbContent.Text;
            }catch(Exception e1)
            {

            }

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

            p.StartInfo.Arguments = "-y -i " + srcFileName + " -q:v "+ tbQV.Text + " -r 1 -ac 1 -ar 8000 " + destFileName;    //执行参数

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


    }
}
