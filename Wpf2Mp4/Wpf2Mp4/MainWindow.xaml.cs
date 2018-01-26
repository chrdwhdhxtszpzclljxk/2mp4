using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf2Mp4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public String file;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".mkv";
            ofd.Filter = "YY录像文件|*.mkv";
            if (ofd.ShowDialog() == true)
            {
                //此处做你想做的事 ...=ofd.FileName; 
                this.tbSourcePath.Text = ofd.FileName;
                file = ofd.SafeFileName;
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Test1(tbSourcePath.Text);
        }


        //原方法转码
        private void Test1(String spath)
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

            p.StartInfo.Arguments = "-i " + srcFileName + "  -r 1 -q:v "+ tbQV.Text +" -ac 1 -ar 8000 " + destFileName;    //执行参数

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
        }
        private static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine(e.Data);

        }

        private static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            Console.WriteLine(e.Data);

        }

    }
}
