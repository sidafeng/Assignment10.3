using Assignment10._3.Data;
using Assignment10._3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
using System.Xml.Linq;

namespace Assignment10._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CRUD cRUD = new CRUD();

        private void RefreshGrid()
        {
            carGrid.ItemsSource = null;
            carGrid.ItemsSource = cRUD.GetCars();

        }

        private void MainWindow_loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
            btnAdd.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_loaded;
            var context = new CarContext();
            listGarages.ItemsSource = context.Set<BillGatesGarage>().ToList();
            listGarages.SelectedIndex = -1;

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {

            Buttons();
        }



        private void carGrid_Select(object sender, SelectionChangedEventArgs e)
        {
            Car car = carGrid.SelectedItem as Car;
            if(car != null)
            {
                btnDelete.IsEnabled = true;
                btnUpdate.IsEnabled = true;
                txtVin.Text = car.VIN.ToString();
                txtMake.Text = car.Make;
                txtModel.Text = car.Model;
                txtYear.Text = car.Year.ToString();
                txtPrice.Text = car.Price.ToString();
                btnAdd.IsEnabled = false;
                
            } else
            {
                return;
            }
        }

        private void Buttons()
        {
            if (Records.context.Cars.Any(car => car.VIN.ToString() == txtVin.Text))
            {
                btnUpdate.IsEnabled = true;
                btnAdd.IsEnabled = false;
            } else if (!txtVin.Text.IsNullOrEmpty())
            {
                btnUpdate.IsEnabled = false;
                btnAdd.IsEnabled = true;
            } else if (txtVin.Text.IsNullOrEmpty())
            {
                btnUpdate.IsEnabled = false;
                btnAdd.IsEnabled = false;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVin.Text) && !string.IsNullOrEmpty(txtMake.Text) && listGarages.SelectedIndex != -1)
            {
                Car newCar = new Car();
                newCar.VIN = long.Parse(txtVin.Text);
                newCar.Make = txtMake.Text;
                newCar.Model = txtModel.Text;
                newCar.Year = int.Parse(txtYear.Text);
                newCar.Price = double.Parse(txtPrice.Text);
                newCar.GarageID = ((BillGatesGarage)listGarages.SelectedItem).GarageID;
                cRUD.AddCar(newCar);
                RefreshGrid();
                txtVin.Clear();
                txtMake.Clear();
                txtModel.Clear();
                txtYear.Clear();
                txtPrice.Clear();
                listGarages.SelectedIndex = -1;
                carGrid.SelectedItem = null;
                Buttons();

            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Car car = carGrid.SelectedItem as Car;
            if (car != null)
            {
                cRUD.DeleteCar(car.VIN);
                RefreshGrid();
                btnDelete.IsEnabled = false;
                txtVin.Clear();
                txtMake.Clear();
                txtModel.Clear();
                txtYear.Clear();
                txtPrice.Clear();
                listGarages.SelectedIndex = -1;
                carGrid.SelectedItem = null;
                Buttons();
            }
           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var car = cRUD.getCar(long.Parse(txtVin.Text));
            if (car != null)
            {
                car.VIN = long.Parse(txtVin.Text);
                car.Make = txtMake.Text;
                car.Model = txtModel.Text;
                car.Year = int.Parse(txtYear.Text);
                car.Price = double.Parse(txtPrice.Text);
                if (((BillGatesGarage)listGarages.SelectedItem).GarageID != null)
                {
                    car.GarageID = ((BillGatesGarage)listGarages.SelectedItem).GarageID;
                }
                
                cRUD.UpdateCar(car.VIN, car);
                RefreshGrid();
                btnUpdate.IsEnabled = false;
            }
        }

        private void Unselect_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource != sender)
                return;
            carGrid.UnselectAll();
            btnDelete.IsEnabled = false;
        }

        private void listGarages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Buttons();
        }
    }
}