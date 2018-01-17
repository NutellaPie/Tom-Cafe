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
        Beverage Mocktail = new Beverage("MockTail", 15.90, 13.05);

        //Bundle Meals
        MenuItem BreakfastSet_Menu = new MenuItem("Breakfast Set", 7.90);
        MenuItem HamburgerCombo_Menu = new MenuItem("Hamburger Combo", 10.20);
        MenuItem DinnerSet_Menu = new MenuItem("Dinner Set", 18.50);

        //Value Meals
        MenuItem Hotcakes_Menu = new MenuItem("Hotcakes with Sausage", 6.90);
        MenuItem Hamburger_Menu = new MenuItem("Hamburger", 7.50);
        MenuItem NasiLemak_Menu = new MenuItem("Nasi Lemak", 5.40);
        MenuItem Steak_Menu = new MenuItem("Ribeye Steak", 10.20);

        //Sides
        MenuItem HashBrown_Menu = new MenuItem("Hash Brown", 2.10);
        MenuItem Fries_Menu = new MenuItem("Truffle Fries", 3.70);
        MenuItem Calamari_Menu = new MenuItem("Calamari", 3.40);
        MenuItem Salad_Menu = new MenuItem("Caesar Salad", 4.30);

        //Beverages
        MenuItem Cola_Menu = new MenuItem("Cola", 2.85);
        MenuItem GreenTea_Menu = new MenuItem("Green Tea", 3.70);
        MenuItem Coffee_Menu = new MenuItem("Coffee", 2.70);
        MenuItem Tea_Menu = new MenuItem("Tea", 2.70);
        MenuItem RootBeer_Menu = new MenuItem("Tom's Root Beer", 9.70);
        MenuItem Mocktail_Menu = new MenuItem("Mocktail", 15.90);

        //Setting variable for retrieving today's DateTime
        DateTime Now = DateTime.Now;

        //Creating Lists for Menu parts
        //Bundle Meals
        List<String> BundleMeals = new List<String> { };
        //Value Meals
        List<String> ValueMeals = new List<String> { };
        //Sides
        List<String> Sides = new List<String> { };
        //Beverages
        List<String> Beverages = new List<string> { };

        public MainPage()
        {
            this.InitializeComponent();

            //Adding Products to Bundle Meals items
            //-------------------------------------------------------------------------------------------
            //Breakfast Set
            BreakfastSet_Menu.ProductList = new List<Product> { Hotcakes, HashBrown };

            //Hamburger Combo
            HamburgerCombo_Menu.ProductList = new List<Product> { Hamburger, Fries, Cola };

            //Dinner Set
            DinnerSet_Menu.ProductList = new List<Product> { Steak, Fries, Salad, Coffee };
            //------------------------------------------------------------------------------------------

            //Populating Bundle Meals
            //Clear Bundle Meals list to prevent repeats
            BundleMeals.Clear();
            //Add Breakfast Set if time within availability of Hotcakes with sausage
            if ((Now.TimeOfDay > Hotcakes.StartTime.TimeOfDay) && (Now.TimeOfDay < Hotcakes.EndTime.TimeOfDay))
            {
                BundleMeals.Add(BreakfastSet_Menu.ToString());
            }
            //Add Hamburger Combo if time within availability of Hamburger
            if ((Now.TimeOfDay > Hamburger.StartTime.TimeOfDay) && (Now.TimeOfDay < Hamburger.EndTime.TimeOfDay))
            {
                BundleMeals.Add(HamburgerCombo_Menu.ToString());
            }
            //Add Dinner Set if time within availability of Ribeye Steak
            if ((Now.TimeOfDay > Steak.StartTime.TimeOfDay) && (Now.TimeOfDay < Steak.EndTime.TimeOfDay))
            {
                BundleMeals.Add(DinnerSet_Menu.ToString());
            }

            //Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
        }

        private void mainsButton_Click(object sender, RoutedEventArgs e)
        {
            //Populating Value Meals List
            //Clear Value Meals list to prevent repeats
            ValueMeals.Clear();

            //Add Hotcakes with sausage if time within availability
            if ((Now.TimeOfDay > Hotcakes.StartTime.TimeOfDay) && (Now.TimeOfDay < Hotcakes.EndTime.TimeOfDay))
            {
                ValueMeals.Add(Hotcakes.ToString());
            }
            //Add Hamburger if time within availability
            if ((Now.TimeOfDay > Hamburger.StartTime.TimeOfDay) && (Now.TimeOfDay < Hamburger.EndTime.TimeOfDay))
            {
                ValueMeals.Add(Hamburger.ToString());
            }
            //Add Nasi Lemak as it is available at all timing
            ValueMeals.Add(NasiLemak.ToString());

            //Add Ribeye steak if time within availability
            if ((Now.TimeOfDay > Steak.StartTime.TimeOfDay) && (Now.TimeOfDay < Steak.EndTime.TimeOfDay))
            {
                ValueMeals.Add(Steak.ToString());
            }

            //Display ValueMeals
            itemsListView.ItemsSource = ValueMeals;
        }

        private void sidesButton_Click(object sender, RoutedEventArgs e)
        {
            //Populating Sides List
            //Clear Sides list to prevent repeats
            Sides.Clear();

            Sides.Add(HashBrown.ToString());
            Sides.Add(Fries.ToString());
            Sides.Add(Calamari.ToString());
            Sides.Add(Salad.ToString());

            //Display Sides
            itemsListView.ItemsSource = Sides;

        }

        private void beveragesButton_Click(object sender, RoutedEventArgs e)
        {
            //Populating Beverages List
            //Clear Beverages list to prevent repeats
            Beverages.Clear();

            Beverages.Add(Cola.ToString());
            Beverages.Add(GreenTea.ToString());
            Beverages.Add(Coffee.ToString());
            Beverages.Add(Tea.ToString());
            Beverages.Add(RootBeer.ToString());
            Beverages.Add(Mocktail.ToString());

            //Display Beverages
            itemsListView.ItemsSource = Beverages;
        }

        private void bundlesButton_Click(object sender, RoutedEventArgs e)
        {
            //Populating Bundle Meals
            //Clear Bundle Meals list to prevent repeats
            BundleMeals.Clear();
            //Add Breakfast Set if time within availability of Hotcakes with sausage
            if ((Now.TimeOfDay > Hotcakes.StartTime.TimeOfDay) && (Now.TimeOfDay < Hotcakes.EndTime.TimeOfDay))
            {
                BundleMeals.Add(BreakfastSet_Menu.ToString());
            }
            //Add Hamburger Combo if time within availability of Hamburger
            if ((Now.TimeOfDay > Hamburger.StartTime.TimeOfDay) && (Now.TimeOfDay < Hamburger.EndTime.TimeOfDay))
            {
                BundleMeals.Add(HamburgerCombo_Menu.ToString());
            }
            //Add Dinner Set if time within availability of Ribeye Steak
            if ((Now.TimeOfDay > Steak.StartTime.TimeOfDay) && (Now.TimeOfDay < Steak.EndTime.TimeOfDay))
            {
                BundleMeals.Add(DinnerSet_Menu.ToString());
            }

            //Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
        }

            private void addButton_Click(object sender, RoutedEventArgs e)
        {
            List<MenuItem> Cart = new List<MenuItem> { };

            if (itemsListView.ItemsSource == BundleMeals)
                cartsListView.ItemsSource = Cart.Add(BundleMeals[itemsListView.SelectedIndex]);

            else if (itemsListView.ItemsSource == ValueMeals)
                cartsListView.ItemsSource = ValueMeals[itemsListView.SelectedIndex];

            else if (itemsListView.ItemsSource == Sides)
                cartsListView.ItemsSource = Sides[itemsListView.SelectedIndex];

            else if (itemsListView.ItemsSource == Beverages)
                cartsListView.ItemsSource = Beverages[itemsListView.SelectedIndex];
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
