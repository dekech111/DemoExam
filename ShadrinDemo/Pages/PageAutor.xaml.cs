using System;
using System.Collections.Generic;
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
using ShadrinDemo.Models;

namespace ShadrinDemo.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAutor.xaml
    /// </summary>
    public partial class PageAutor : Page
    {
        Random rand = new Random();
        private int count = 0;
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        public PageAutor()
        {
            InitializeComponent();
            string[] mass = { "g", "D", "G", "J", "6", "3", "/", "&", "^", "$", "#", "0", "1", "2", "3", "J", "Y", "]", ";", "Z", "X", "V", "R", "S" };
            while (txCapcha.Text.Length < 4)
            {
                txCapcha.Text += mass[rand.Next(0, mass.Length)];
            }
            Form.btnLeave.Visibility = Visibility.Collapsed;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var userObj = ConnectHelper.entObj.User.SingleOrDefault(x => x.UserLogin == txbLogin.Text && x.UserPassword == pbPass.Password);

            if (txbLogin.Text.Length < 1 && pbPass.Password.Length < 1)
                MessageBox.Show("Заполните данные авторизации!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);

            else if (userObj == null)
            {
                count++;
                if (count == 3)
                    btnEnter.IsEnabled = false;

                MessageBox.Show("Пользователя с такими данными нет!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                spCapcha.Visibility = Visibility.Visible;
            }
            else
            {
                if (spCapcha.Visibility == Visibility.Visible)
                {
                    if (txCapcha.Text != txCapchaEnter.Text)
                        MessageBox.Show("Капча не совпадает", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        count = 0;
                        switch (userObj.UserRole)
                        {
                            case 1:
                                FrameApp.frmObj.Navigate(new PageViewProduct());
                                break;

                            case 2:
                                FrameApp.frmObj.Navigate(new PageProduct());
                                break;

                            case 3:
                                FrameApp.frmObj.Navigate(new PageProduct());
                                break;
                        }
                    }
                }
                else
                {
                    count = 0;
                    switch (userObj.UserRole)
                    {
                        case 1:
                            FrameApp.frmObj.Navigate(new PageViewProduct());
                            break;

                        case 2:
                            FrameApp.frmObj.Navigate(new PageProduct());
                            break;

                        case 3:
                            FrameApp.frmObj.Navigate(new PageProduct());
                            break;
                    }
                }
            }
        }

        private void btnEnterGhoust_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageProduct());
        }
    }
}
