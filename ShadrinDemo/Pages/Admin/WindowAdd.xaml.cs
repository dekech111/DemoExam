using ShadrinDemo.Models;
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
using System.Windows.Shapes;

namespace ShadrinDemo.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
            cmbCategory.SelectedValuePath = "ID_Category";
            cmbCategory.DisplayMemberPath = "Name";
            cmbCategory.ItemsSource = ConnectHelper.entObj.Category.ToList();

            cmbManuf.SelectedValuePath = "ID_Manufacturer";
            cmbManuf.DisplayMemberPath = "Name";
            cmbManuf.ItemsSource = ConnectHelper.entObj.Manufacturer.ToList();

            cmbSupplier.SelectedValuePath = "ID_Supplier";
            cmbSupplier.DisplayMemberPath = "Name";
            cmbSupplier.ItemsSource = ConnectHelper.entObj.Supplier.ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var productOj = ConnectHelper.entObj.Product.FirstOrDefault(x => x.ProductArticleNumber == txbActicle.Text && x.ProductName == txbName.Text && x.ProductDescription == txbDescription.Text &&
            x.ProductCategory == (int)cmbCategory.SelectedValue && x.ProductManufacturer == (int)cmbManuf.SelectedValue && x.ProductCost.ToString() == txbCost.Text && x.ProductDiscountAmount.ToString() == txbDiscoundAmount.Text &&
            x.ProductQuantityInStock.ToString() == txbQuantityInStock.Text && x.ProductSupplier == (int)cmbSupplier.SelectedValue && x.ProductDiscountMax.ToString() == txbDiscountMax.Text && x.ProductUnit == txbUnit.Text);
            if (productOj != null)
                MessageBox.Show("Такая запись уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    Product prod = new Product()
                    {
                        ProductArticleNumber = txbActicle.Text,
                        ProductName = txbName.Text,
                        ProductDescription = txbDescription.Text,
                        ProductCategory = (int)cmbCategory.SelectedValue,
                        ProductManufacturer = (int)cmbManuf.SelectedValue,
                        ProductCost = Decimal.Parse(txbCost.Text),
                        ProductDiscountAmount = Byte.Parse(txbDiscoundAmount.Text),
                        ProductQuantityInStock = int.Parse(txbQuantityInStock.Text),
                        ProductSupplier = (int)cmbSupplier.SelectedValue,
                        ProductDiscountMax = Decimal.Parse(txbDiscountMax.Text),
                        ProductUnit = txbUnit.Text
                    };
                    ConnectHelper.entObj.Product.Add(prod);
                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Добавление данных прошло успешно", "уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }
    }
}
