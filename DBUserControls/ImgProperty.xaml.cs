using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBOperation.Resource;
using DBOperation.Class;

namespace DBOperation.DBUserControls
{
    /// <summary>
    /// ImgProperty.xaml 的交互逻辑
    /// </summary>
    public partial class ImgProperty : UserControl
    {
        public static DependencyProperty ControlSourceProperty =
            DependencyProperty.Register("ControlSource", typeof(List<InputImgInfo>), typeof(ImgProperty), new PropertyMetadata(default(List<InputImgInfo>)));
        public List<InputImgInfo> ControlSource
        {
            get { return (List<InputImgInfo>)GetValue(ControlSourceProperty); }
            set
            {
                 
                SetValue(ControlSourceProperty, value);
            }
        }
        public ImgProperty()
        {
            InitializeComponent();
        }

        private void preImgBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nxtImgBtn_Click(object sender, RoutedEventArgs e)
        {

        }

       

    }
}
