﻿using System;
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

        //Menu Items
        MenuItem BreakfastSet_Menu = new MenuItem("Breakfast Set", 7.90);
        MenuItem HamburgerCombo_Menu = new MenuItem("Hamburger Combo", 10.20);
        MenuItem DinnerSet_Menu = new MenuItem("Dinner Set", 18.50);
        MenuItem Hotcakes_Menu = new MenuItem("Hotcakes with Sausage", 6.90);
        MenuItem Hamburger_Menu = new MenuItem("Hamburger", 7.50);
        MenuItem NasiLemak_Menu = new MenuItem("Nasi Lemak", 5.40);
        MenuItem Steak_Menu = new MenuItem("Ribeye Steak", 10.20);
        MenuItem HashBrown_Menu = new MenuItem("Hash Brown", 2.10);
        MenuItem Fries_Menu = new MenuItem("Truffle Fries", 3.70);
        MenuItem Calamari_Menu = new MenuItem("Calamari", 3.40);
        MenuItem Salad_Menu = new MenuItem("Caesar Salad", 4.30);
        MenuItem Cola_Menu = new MenuItem("Cola", 2.85);
        MenuItem GreenTea_Menu = new MenuItem("Green Tea", 3.70);
        MenuItem Coffee_Menu = new MenuItem("Coffee", 2.70);
        MenuItem Tea_Menu = new MenuItem("Tea", 2.70);
        MenuItem RootBeer_Menu = new MenuItem("Tom's Root Beer", 9.70);
        MenuItem Mocktail_Menu = new MenuItem("Mocktail", 15.90);

        //Setting variable for retrieving today's DateTime
        DateTime Now = DateTime.Now;

        //Creating List for Bundle Meals
        List<String> BundleMeals = new List<String> { };

        public MainPage()
        {
            this.InitializeComponent();
        
            //Adding Products to Bundle Meals items
            //-------------------------------------------------------------------------------------------
            //Breakfast Set
            List<Product> BreakfastSetProductList = new List<Product> { Hotcakes, HashBrown };
            BreakfastSet_Menu.ProductList = BreakfastSetProductList;

            //Hamburger Combo
            List<Product> HamburgerComboProductList = new List<Product> { Hamburger, Fries, Cola};
            HamburgerCombo_Menu.ProductList = HamburgerComboProductList;

            //Dinner Set
            List<Product> DinnerSetProductList = new List<Product> { Steak, Fries, Salad, Coffee};
            DinnerSet_Menu.ProductList = DinnerSetProductList;
            //------------------------------------------------------------------------------------------

            //Populating Bundle Meals
            if ((Now.TimeOfDay > Hotcakes.StartTime.TimeOfDay) && (Now.TimeOfDay < Hotcakes.StartTime.TimeOfDay))
            {
                BundleMeals.Add(String.Format("{0}\n{1}\n${2:0.00}", BreakfastSet_Menu.Name, String.Format("({0}, {1})", BreakfastSet_Menu.ProductList[0].Name, BreakfastSet_Menu.ProductList[1].Name), BreakfastSet_Menu.Price));
            }
            if((Now.TimeOfDay > Hamburger.StartTime.TimeOfDay) && (Now.TimeOfDay < Hamburger.EndTime.TimeOfDay))
            {
                BundleMeals.Add(String.Format("{0}\n{1}\n${2:0.00}", HamburgerCombo_Menu.Name, String.Format("({0}, {1}, {2})", HamburgerCombo_Menu.ProductList[0].Name, HamburgerCombo_Menu.ProductList[1].Name, HamburgerCombo_Menu.ProductList[2].Name), HamburgerCombo_Menu.Price));
            }
            if ((Now.TimeOfDay > Steak.StartTime.TimeOfDay) && (Now.TimeOfDay < Steak.EndTime.TimeOfDay))
            {
                BundleMeals.Add(String.Format("{0}\n{1}\n${2:0.00}", DinnerSet_Menu.Name, String.Format("({0}, {1}, {2}, {3})", DinnerSet_Menu.ProductList[0].Name, DinnerSet_Menu.ProductList[1].Name, DinnerSet_Menu.ProductList[2].Name, DinnerSet_Menu.ProductList[3].Name), DinnerSet_Menu.Price));
            }

            //Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
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
            //Populating Bundle Meals
            if ((Now.TimeOfDay > Hotcakes.StartTime.TimeOfDay) && (Now.TimeOfDay < Hotcakes.StartTime.TimeOfDay))
            {
                BundleMeals.Add(String.Format("{0}\n{1}\n${2:0.00}", BreakfastSet_Menu.Name, String.Format("({0}, {1})", BreakfastSet_Menu.ProductList[0].Name, BreakfastSet_Menu.ProductList[1].Name), BreakfastSet_Menu.Price));
            }
            if ((Now.TimeOfDay > Hamburger.StartTime.TimeOfDay) && (Now.TimeOfDay < Hamburger.EndTime.TimeOfDay))
            {
                BundleMeals.Add(String.Format("{0}\n{1}\n${2:0.00}", HamburgerCombo_Menu.Name, String.Format("({0}, {1}, {2})", HamburgerCombo_Menu.ProductList[0].Name, HamburgerCombo_Menu.ProductList[1].Name, HamburgerCombo_Menu.ProductList[2].Name), HamburgerCombo_Menu.Price));
            }
            if ((Now.TimeOfDay > Steak.StartTime.TimeOfDay) && (Now.TimeOfDay < Steak.EndTime.TimeOfDay))
            {
                BundleMeals.Add(String.Format("{0}\n{1}\n${2:0.00}", DinnerSet_Menu.Name, String.Format("({0}, {1}, {2}, {3})", DinnerSet_Menu.ProductList[0].Name, DinnerSet_Menu.ProductList[1].Name, DinnerSet_Menu.ProductList[2].Name, DinnerSet_Menu.ProductList[3].Name), DinnerSet_Menu.Price));
            }

            //Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
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
