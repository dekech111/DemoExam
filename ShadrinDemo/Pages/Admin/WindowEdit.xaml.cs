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
    /// Логика взаимодействия для WindowEdit.xaml
    /// </summary>
    public partial class WindowEdit : Window
    {
        private string artNumber = PageViewProduct.GetArtNumber();
        public WindowEdit()
        {
            InitializeComponent();
            var prod = ConnectHelper.entObj.Product.SingleOrDefault(x => x.ProductArticleNumber == artNumber);

            txbActicle.Text = prod.ProductArticleNumber;
            txbName.Text = prod.ProductName;
            txbDescription.Text = prod.ProductDescription;
            txbCost.Text = prod.ProductCost.ToString();
            txbDiscoundAmount.Text = prod.ProductDiscountAmount.ToString();
            txbQuantityInStock.Text = prod.ProductQuantityInStock.ToString();
            txbDiscountMax.Text = prod.ProductDiscountMax.ToString();
            txbUnit.Text = prod.ProductUnit;

            cmbSupplier.SelectedItem = ConnectHelper.entObj.Supplier.Where(x => x.ID_Supplier == prod.ProductSupplier).ToList();
            cmbManuf.SelectedItem = ConnectHelper.entObj.Manufacturer.Where(x => x.ID_Manufacturer == prod.ProductManufacturer).ToList();
            cmbCategory.SelectedItem = ConnectHelper.entObj.Category.Where(x => x.ID_Category == prod.ProductCategory).ToList();


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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
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
                    Product product = ConnectHelper.entObj.Product.SingleOrDefault(x => x.ProductArticleNumber == artNumber);
                    product.ProductArticleNumber = txbActicle.Text;
                    product.ProductName = txbName.Text;
                    product.ProductDescription = txbDescription.Text;
                    product.ProductCategory = (int)cmbCategory.SelectedValue;
                    product.ProductManufacturer = (int)cmbManuf.SelectedValue;
                    product.ProductCost = Decimal.Parse(txbCost.Text);
                    product.ProductDiscountAmount = Byte.Parse(txbDiscoundAmount.Text);
                    product.ProductQuantityInStock = int.Parse(txbQuantityInStock.Text);
                    product.ProductSupplier = (int)cmbSupplier.SelectedValue;
                    product.ProductDiscountMax = Decimal.Parse(txbDiscountMax.Text);
                    product.ProductUnit = txbUnit.Text;

                    ConnectHelper.entObj.SaveChanges();
                    MessageBox.Show("Данные изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message, "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
        }
    }
}
