using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_扇形菜单
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Point curPos ;
        bool isOpen=true;
        public MainWindow()
        {
            InitializeComponent();

            btnHome.AddHandler(Button.MouseLeftButtonDownEvent, new RoutedEventHandler(btnHome_PreviewMouseLeftButtonDown), true);
            btnHome.AddHandler(Button.MouseLeftButtonUpEvent, new RoutedEventHandler(btnHome_PreviewMouseLeftButtonUp), true);
            myWindow.AddHandler(Button.PreviewMouseDownEvent, new RoutedEventHandler(window_PreviewMouseDown), true);
        }
        private void btnClick(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            MessageBox.Show(feSource.Name);
            if (feSource.Name == "btnHome")
            {
                this.DragMove();
            }
        }
        private void window_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            base.DragMove();
            Debug.Print("window_PreviewMouseDown");
            //curPos = e.GetPosition(this);

            //Point tmp = Mouse.GetPosition(e.Source as FrameworkElement);//WPF方法
            //curPos = (e.Source as FrameworkElement).PointToScreen(tmp);//WPF方法
        }
        private void btnHome_PreviewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

            Debug.Print("btnHome_PreviewMouseLeftButtonDown");
            curPos = Mouse.GetPosition(this);

            Point tmp = Mouse.GetPosition(e.Source as FrameworkElement);//WPF方法
            curPos = (e.Source as FrameworkElement).PointToScreen(tmp);//WPF方法


            
        }
        private void btnHome_PreviewMouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            Debug.Print("btnHome_PreviewMouseLeftButtonUp");

            Point tmp = Mouse.GetPosition(e.Source as FrameworkElement);//WPF方法
            Point nowPos = (e.Source as FrameworkElement).PointToScreen(tmp);//WPF方法

          
            if (isOpen == false)
            {
                Visibility vi = Visibility.Visible;
                gdOpen.Visibility = vi;
                gdSelect.Visibility = vi;
                gdRemove.Visibility = vi;
                gdSetting.Visibility = vi;
                gdWriting.Visibility = vi;
                gdStar.Visibility = vi;
                gdClip.Visibility = vi;
                gdSave.Visibility = vi;
                gdClose.Visibility = vi;
                if (Math.Abs(nowPos.X - curPos.X) < 10 && Math.Abs(nowPos.Y - curPos.Y) < 10)
                {

                    Storyboard story = (Storyboard)this.FindResource("OnLoaded1");
                    story.Begin();
                }

            }
            else
            {
                Visibility vi = Visibility.Collapsed;
                gdOpen.Visibility = vi;
                gdSelect.Visibility = vi;
                gdRemove.Visibility = vi;
                gdSetting.Visibility = vi;
                gdWriting.Visibility = vi;
                gdStar.Visibility = vi;
                gdClip.Visibility = vi;
                gdSave.Visibility = vi;
                gdClose.Visibility = vi;
            }
            isOpen = !isOpen;
        }

        private void btnHome_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //Point tmp = Mouse.GetPosition(e.Source as FrameworkElement);//WPF方法
            //Point nowPos = (e.Source as FrameworkElement).PointToScreen(tmp);//WPF方法

            //if (Math.Abs(nowPos.X - curPos.X) < 5 && Math.Abs(nowPos.Y - curPos.Y) < 5)
            //{

            //    Storyboard story = (Storyboard)this.FindResource("OnLoaded1");
            //    story.Begin();
            //}
        }

        private void Window_MouseDown(object sender, RoutedEventArgs e)
        {
            base.DragMove();
            Debug.Print("Window_MouseDown");
        }
    }
}
