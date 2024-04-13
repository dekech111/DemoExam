using ShadrinDemo.Models;
using ShadrinDemo.Pages;
using System.Windows;


namespace ShadrinDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.entObj = new TradeEntities();
            FrameApp.frmObj = FrmMain;
            FrameApp.frmObj.Navigate(new PageAutor());
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageAutor());
        }
    }
}
