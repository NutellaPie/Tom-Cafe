using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TomCafe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Menu Items

        //Value Meal Items
        ValueMeal Hotcakes = new ValueMeal("Hotcake with sausage", 6.90, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 07, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 00, 00));
        ValueMeal Hamburger = new ValueMeal("Hamburger", 7.50, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00));
        ValueMeal NasiLemak = new ValueMeal("Nasi Lemak", 5.40, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));
        ValueMeal Steak = new ValueMeal("Ribeye Steak", 10.20, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 00, 00));

        //Sides Items
        Side HashBrown = new Side("Hash Brown", 2.10);
        Side Fries = new Side("Truffle fries", 3.70);
        Side Calamari = new Side("Calamari", 3.40);
        Side Salad = new Side("Caesar Salad", 4.30);

        //Beverages
        Beverage Cola = new Beverage("Cola", 2.85, 0.00);
        Beverage GreenTea = new Beverage("Green Tea", 3.70, 0.85);
        Beverage Coffee = new Beverage("Coffee", 2.70, 0.00);
        Beverage Tea = new Beverage("Tea", 2.70, 0.00);
        Beverage RootBeer = new Beverage("Tom's Root Beer", 9.70, 6.85);
        Beverage Mocktail = new Beverage('MockTail', 15.90, 13.05);

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void mainsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sidesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void beveragesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bundlesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
