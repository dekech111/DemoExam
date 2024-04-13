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
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        List<string> filt = new List<string>();
        public PageProduct()
        {
            InitializeComponent();
            lvProduct.ItemsSource = ConnectHelper.entObj.Product.ToList();
            Form.btnLeave.Visibility = Visibility.Visible;

            cmbSort.Items.Add("По возврастанию");
            cmbSort.Items.Add("По убыванию");

            filt.Add("Показать все");
            foreach (var items in ConnectHelper.entObj.Manufacturer)
                filt.Add(items.Name);

            cmbFilt.ItemsSource = filt.ToList();
            Count();
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cmbSort.SelectedValue == null && cmbFilt.SelectedValue == null)
            {
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.ProductName.Contains(txbSearch.Text) || x.ProductDescription.Contains(txbSearch.Text) ||
                x.Manufacturer.Name.Contains(txbSearch.Text) || x.ProductCost.ToString().Contains(txbSearch.Text) || x.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).ToList();
                Count();
            }
            else if(cmbFilt.SelectedValue == null && cmbSort.SelectedValue != null)
            {
                if(cmbSort.SelectedIndex == 0)
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
            else if(cmbSort.SelectedValue == null && cmbFilt.SelectedValue != null)
            {
                lvProduct.ItemsSource = ConnectHelper.entObj.Product.Where(x => x.Manufacturer.Name == cmbFilt.SelectedValue).Where(y => y.ProductName.Contains(txbSearch.Text) || y.ProductDescription.Contains(txbSearch.Text) ||
                    y.ProductCost.ToString().Contains(txbSearch.Text) || y.ProductQuantityInStock.ToString().Contains(txbSearch.Text)).ToList();
                Count();
            }
            else if(cmbFilt.SelectedValue != null && cmbSort.SelectedValue != null)
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
            if(txbSearch.Text.Length <1 && cmbFilt.SelectedValue == null)
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
            else if(txbSearch.Text.Length < 1 && cmbFilt.SelectedValue != null)
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

    }
}
