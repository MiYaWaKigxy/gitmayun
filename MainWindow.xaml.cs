using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace You_canTry
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon notifyIcon;
        System.Drawing.Icon originIcon;
        System.Drawing.Icon transIcon;

        bool isStop = false;
        public MainWindow()
        {
            InitializeComponent();

            originIcon = new System.Drawing.Icon(@"D:\YQ\WPFIcon\music1.ico");
            transIcon = new System.Drawing.Icon(@"D:\YQ\WPFIcon\music2.ico");
            InitIcon();
        }

        private void InitIcon()
        {
            notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);
            notifyIcon.Icon = originIcon;
            
            notifyIcon.Text = "QQ音乐";
            notifyIcon.Visible = true;

            System.Windows.Forms.MenuItem menuItem=new System.Windows.Forms.MenuItem("退出");
            menuItem.Click += MenuItem_Click;

            System.Windows.Forms.MenuItem menuItem1 = new System.Windows.Forms.MenuItem("关于");
            menuItem1.Click += MenuItem1_Click;

            System.Windows.Forms.MenuItem[] menuItems=new System.Windows.Forms.MenuItem[] {menuItem1,menuItem};

            notifyIcon.ContextMenu=new System.Windows.Forms.ContextMenu(menuItems);

            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            isStop = true;
            System.Windows.MessageBox.Show("请购买腾讯版权再进行播放！");
            notifyIcon.Icon= originIcon;
        }

        private void sendms_Click(object sender, RoutedEventArgs e)
        {
            Flicker();
        }
        //闪烁函数
        private void Flicker()
        {
            new Task(() =>
            {
                while (true)
                {
                    Thread.Sleep(400);
                    if (!isStop)
                    {
                        notifyIcon.Icon = notifyIcon.Icon == originIcon ? transIcon : originIcon;
                    }
                    else
                    {
                        isStop = false;
                        break;
                    }
                }
            }).Start();
            
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("This is a Music APP create by 懒羊羊");
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            this.Close();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void small_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Minimized;
            }
            
        }

        private void big_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState= WindowState.Maximized;
        }

        private void wrong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Label_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        


    }
}
