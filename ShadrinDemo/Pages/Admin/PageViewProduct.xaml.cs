using ShadrinDemo.Models;
using ShadrinDemo.Pages.Admin;
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

namespace ShadrinDemo.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageViewProduct.xaml
    /// </summary>
    public partial class PageViewProduct : Page
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        public static string artNumber;
        Product prodObj;
        List<string> filt = new List<string>();
        public PageViewProduct()
        {
            InitializeComponent();
           
            Form.btnLeave.Visibility = Visibility.Visible;

            cmbSort.Items.Add("По возврастанию");
            cmbSort.Items.Add("По убыванию");

            filt.Add("Показать все");
            foreach (var items in ConnectHelper.entObj.Manufacturer)
                filt.Add(items.Name);

            cmbFilt.ItemsSource = filt.ToList();


            lvProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
            Count();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cmbSort.SelectedValue == null && cmbFilt.SelectedValue == null)
            {
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).ToList();
                Count();
            }
            else if (cmbFilt.SelectedValue == null && cmbSort.SelectedValue != null)
            {
                if (cmbSort.SelectedIndex == 0)
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                            x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderBy(x => x.ProductCost).ToList();
                    Count();
                }

                else
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                        x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderByDescending(x => x.ProductCost).ToList();
                    Count();
                }

            }
            else if (cmbSort.SelectedValue == null && cmbFilt.SelectedValue != null)
            {
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).Where(y => y.ProductName.Contains(txbSearch.Text) || y.ProductDescription.Contains(txbSearch.Text) ||
                    y.ProductCost.ToString().Contains(txbSearch.Text) || y.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).ToList();
                Count();
            }
            else if (cmbFilt.SelectedValue != null && cmbSort.SelectedValue != null)
            {
                if (cmbSort.SelectedIndex == 0)
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).Where(y => y.ProductName.Contains(txbSearch.Text) || y.ProductDescription.Contains(txbSearch.Text) ||
                        y.ProductCost.ToString().Contains(txbSearch.Text) || y.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderBy(x => x.ProductCost).ToList();
                    Count();
                }
                else
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                        x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderByDescending(x => x.ProductCost).ToList();
                    Count();
                }
            }

        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txbSearch.Text.Length < 1 && cmbFilt.SelectedValue == null)
            {
                if (cmbSort.SelectedIndex != -1)
                {
                    if (cmbSort.SelectedIndex == 0)
                    {
                        lvProduct.ItemsSource = ConnectHelper.entObj.Product.OrderBy(x => x.ProductCost).ToList();
                        Count();
                    }
                    else if (cmbSort.SelectedIndex == 1)
                    {
                        lvProduct.ItemsSource = ConnectHelper.entObj.Product.OrderByDescending(x => x.ProductCost).ToList();
                        Count();
                    }
                }
            }
            else if (txbSearch.Text.Length < 1 && cmbFilt.SelectedValue != null)
            {
                if (cmbSort.SelectedIndex == 0)
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).OrderBy(x => x.ProductCost).ToList();
                    Count();
                }
                else if (cmbSort.SelectedIndex == 1)
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).OrderByDescending(x => x.ProductCost).ToList();
                    Count();
                }
            }
            else if (txbSearch.Text.Length > 1 && cmbFilt.SelectedValue == null)
            {
                if (cmbSort.SelectedIndex == 0)
                {


                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                            x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderBy(x => x.ProductCost).ToList();
                    Count();
                }
                else
                {


                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                        x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderByDescending(x => x.ProductCost).ToList();
                    Count();
                }
            }
            else if (txbSearch.Text.Length > 1 && cmbFilt.SelectedValue != null)
            {
                if (cmbSort.SelectedIndex == 0)
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).Where(y => y.ProductName.Contains(txbSearch.Text) || y.ProductDescription.Contains(txbSearch.Text) ||
                        y.ProductCost.ToString().Contains(txbSearch.Text) || y.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderBy(x => x.ProductCost).ToList();
                    Count();
                }
                else
                {
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                        x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).OrderByDescending(x => x.ProductCost).ToList();
                    Count();
                }
            }

        }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilt.SelectedValue == "Показать все")
            {
                cmbFilt.SelectedIndex = -1;
                cmbSort.SelectedIndex = -1;
                txbSearch.Text = null;
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
                Count();
            }
            else
            {
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).ToList();
                Count();
            }
        }
        /// <summary>
        /// Подсчёт колВа записей
        /// </summary>
        public void Count()
        {
            txbCount.Text = lvProduct.Items.Count + " из " + ConnectHelper.entObj.Product.Count();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            prodObj = lvProduct.SelectedItem as Product;
            if (prodObj == null)
                MessageBox.Show("Запись не выбрана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    ConnectHelper.entObj.Product.Remove(prodObj);
                    ConnectHelper.entObj.SaveChanges();
                    lvProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            prodObj = lvProduct.SelectedItem as Product;
            if (prodObj == null)
                MessageBox.Show("Запись не выбрана!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                artNumber = prodObj.ProductArticleNumber;
                WindowEdit windowEdit = new WindowEdit();
                windowEdit.ShowDialog();
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd windowAdd = new WindowAdd();
            windowAdd.ShowDialog();
            lvProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
        }

        public static string GetArtNumber()
        {
            return artNumber;
        }
    }
}
