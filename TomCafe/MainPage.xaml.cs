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
        Beverage Mocktail = new Beverage("Mocktail", 15.90, 13.05);

        //Bundle Meals
        MenuItem BreakfastSet_Menu = new MenuItem("Breakfast Set", 7.90);
        MenuItem HamburgerCombo_Menu = new MenuItem("Hamburger Combo", 10.20);
        MenuItem DinnerSet_Menu = new MenuItem("Dinner Set", 18.50);

        //Setting variable for retrieving today's DateTime
        DateTime Now = DateTime.Now;

        //Creating Lists for Menu parts
        //List of all Menu Items
        List<System.Collections.IList> MenuList = new List<System.Collections.IList> { };

        //Bundle Meals
        List<MenuItem> BundleMeals = new List<MenuItem> { };
        //Value Meals
        List<ValueMeal> ValueMeals = new List<ValueMeal> { };
        //Sides
        List<Side> Sides = new List<Side> { };
        //Beverages
        List<Beverage> Beverages = new List<Beverage> { };

        //Creating list for cart items
        List<OrderItem> CartList = new List<OrderItem> { };


        public MainPage()
        {
            this.InitializeComponent();

            //Add all products lists

            // BundleMeals ---------------------------------------------------------------------------------------------------------------------------------
            //Add Breakfast Set if time within availability of Hotcakes with sausage
            if ((Now.TimeOfDay > Hotcakes.StartTime.TimeOfDay) && (Now.TimeOfDay < Hotcakes.EndTime.TimeOfDay))
            {
                BundleMeals.Add(BreakfastSet_Menu);
            }
            //Add Hamburger Combo if time within availability of Hamburger
            if ((Now.TimeOfDay > Hamburger.StartTime.TimeOfDay) && (Now.TimeOfDay < Hamburger.EndTime.TimeOfDay))
            {
                BundleMeals.Add(HamburgerCombo_Menu);
            }
            //Add Dinner Set if time within availability of Ribeye Steak
            if ((Now.TimeOfDay > Steak.StartTime.TimeOfDay) && (Now.TimeOfDay < Steak.EndTime.TimeOfDay))
            {
                BundleMeals.Add(DinnerSet_Menu);
            }
            // ---------------------------------------------------------------------------------------------------------------------------------------------

            ValueMeals = new List<ValueMeal> { Hotcakes, Hamburger, NasiLemak, Steak };
            Sides = new List<Side> { HashBrown, Fries, Calamari, Salad };
            Beverages = new List<Beverage> { Cola, GreenTea, Coffee, Tea, RootBeer, Mocktail };

            //Master List
            MenuList = new List<System.Collections.IList> { BundleMeals, ValueMeals, Sides, Beverages };

            //Adding Products to Bundle Meals items
            //-------------------------------------------------------------------------------------------
            //Breakfast Set
            BreakfastSet_Menu.ProductList = new List<Product> { Hotcakes, HashBrown };

            //Hamburger Combo
            HamburgerCombo_Menu.ProductList = new List<Product> { Hamburger, Fries, Cola };

            //Dinner Set
            DinnerSet_Menu.ProductList = new List<Product> { Steak, Fries, Salad, Coffee };
            //------------------------------------------------------------------------------------------            

            //Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
        }

        private void mainsButton_Click(object sender, RoutedEventArgs e)
        {
            //Display ValueMeals
            itemsListView.ItemsSource = ValueMeals;
        }

        private void sidesButton_Click(object sender, RoutedEventArgs e)
        {
            //Display Sides
            itemsListView.ItemsSource = Sides;
        }

        private void beveragesButton_Click(object sender, RoutedEventArgs e)
        {
            //Display Beverages
            itemsListView.ItemsSource = Beverages;
        }

        private void bundlesButton_Click(object sender, RoutedEventArgs e)
        {
            //Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            cartsListView.ItemsSource = null;

            foreach (OrderItem oi in CartList)
            {
                if ((MenuItem)itemsListView.SelectedItem == oi.Item)
                {
                    oi.AddQty();
                    break;
                }
            }

            if (itemsListView.SelectedItem is MenuItem)
            {
                CartList.Add(new OrderItem((MenuItem)itemsListView.SelectedItem));
                cartsListView.ItemsSource = CartList;
            }

            else
            {
                CartList.Add(new OrderItem(new MenuItem(((Product)(itemsListView.SelectedItem)).Name, ((Product)(itemsListView.SelectedItem)).Price)));
                cartsListView.ItemsSource = CartList;
                //testing.Text = String.Format("{0}", new MenuItem(((Product)itemsListView.SelectedItem).Name, ((Product)itemsListView.SelectedItem).Price));

                //MenuItem temp = new MenuItem(((Product)itemsListView.SelectedItem).Name, ((Product)itemsListView.SelectedItem).Price);
                //temp.ProductList.Add((Product)itemsListView.SelectedItem);

                //CartList.Add(new OrderItem(temp));
                //cartsListView.ItemsSource = CartList;
            }
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
