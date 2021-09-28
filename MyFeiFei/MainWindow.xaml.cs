using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace MyFeiFei
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OpenSocket();
        }

        public void Init() 
        {
        
        }
        public void Save()
        {
            Bitmap image = new Bitmap((int)this.Width, (int)this.Height);
            Graphics g = Graphics.FromImage(image);

            g.CopyFromScreen((int)this.Left, (int)this.Top, 0, 0,
            new System.Drawing.Size((int)this.Width, (int)this.Height),
            CopyPixelOperation.SourceCopy);
            g.Dispose();

            image.Save("D://weiboTemp.png");//默认保存格式为PNG，保存成jpg格式质量不是很好}
        }

        public void OpenSocket() 
        {
            SocketTest socket = new SocketTest();
            socket.OpenSocket();
        }
    }
}
