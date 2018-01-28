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

// The Blank Page item template is documented at https:// go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TomCafe
{
    // / <summary>
    // / An empty page that can be used on its own or navigated to within a Frame.
    // / </summary>
    public sealed partial class MainPage : Page
    {
        // Menu Items

        // Value Meal Items
        ValueMeal Hotcakes = new ValueMeal("Hotcake with sausage", 6.90, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 07, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 00, 00));
        ValueMeal Hamburger = new ValueMeal("Hamburger", 7.50, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00));
        ValueMeal NasiLemak = new ValueMeal("Nasi Lemak", 5.40, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));
        ValueMeal Steak = new ValueMeal("Ribeye steak", 10.20, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 00, 00), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 00, 00));

        // Sides Items
        Side HashBrown = new Side("Hash brown", 2.10);
        Side Fries = new Side("Truffle fries", 3.70);
        Side Calamari = new Side("Calamari", 3.40);
        Side Salad = new Side("Caesar salad", 4.30);

        // Beverages
        Beverage Cola = new Beverage("Cola", 2.85, 0.00);
        Beverage GreenTea = new Beverage("Green Tea", 3.70, 0.00);
        Beverage Coffee = new Beverage("Coffee", 2.70, 0.00);
        Beverage Tea = new Beverage("Tea", 2.70, 0.00);
        Beverage RootBeer = new Beverage("Tom's Root Beer", 9.70, 0.00);
        Beverage Mocktail = new Beverage("Mocktail", 15.90, 0.00);

        // Bundle Meals
        MenuItem BreakfastSet_Menu = new MenuItem("Breakfast Set", 7.90);
        MenuItem HamburgerCombo_Menu = new MenuItem("Hamburger Combo", 10.20);
        MenuItem DinnerSet_Menu = new MenuItem("Dinner Set", 18.50);
        MenuItem CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

        // Setting variable for retrieving today's DateTime
        DateTime Now = DateTime.Now;

        // Creating Lists for Menu parts
        // List of all Menu Items
        List<System.Collections.IList> MenuList = new List<System.Collections.IList> { };

        // Bundle Meals
        List<MenuItem> BundleMeals = new List<MenuItem> { };
        // Value Meals
        List<ValueMeal> ValueMeals = new List<ValueMeal> { };
        // Sides
        List<Side> Sides = new List<Side> { };
        // Beverages
        List<Beverage> Beverages = new List<Beverage> { };

        // Creating OrderItem for insertion into cart
        OrderItem oi = new OrderItem();

        // Create new Order
        Order Order = new Order();

        // Tradein variables
        bool TradeInFlag = false;
        int BeverageIndex = 0;

        // Customise Bundle Variables
        bool CustomiseBundleFlag = false;
        bool CustomiseSideFlag = false;
        bool CustomiseBeverageFlag = false;


        public MainPage()
        {
            this.InitializeComponent();

            // Display greeting message
            displayText.Text = "Welcome to Tom's Cafe!\n\nChoose your item from the menu.";

            // Add all products lists
            Sides = new List<Side> { HashBrown, Fries, Calamari, Salad };
            Beverages = new List<Beverage> { Cola, GreenTea, Coffee, Tea, RootBeer, Mocktail };

            // BundleMeals/ValueMeals ---------------------------------------------------------------------------------------------------------------------------------
            // Add Breakfast Set & Hotcakes if time within availability of Hotcakes with sausage
            if (Hotcakes.IsAvailable())
            {
                BundleMeals.Add(BreakfastSet_Menu);
                ValueMeals.Add(Hotcakes);
            }
            // Add Hamburger Combo & Hamburger if time within availability of Hamburger
            if (Hamburger.IsAvailable())
            {
                BundleMeals.Add(HamburgerCombo_Menu);
                ValueMeals.Add(Hamburger);
            }

            // Add Nasi Lemak as it is always available
            ValueMeals.Add(NasiLemak);

            // Add Dinner Set & Steak if time within availability of Ribeye Steak
            if (Steak.IsAvailable())
            {
                BundleMeals.Add(DinnerSet_Menu);
                ValueMeals.Add(Steak);
            }

            // Add option for Customise bundle
            BundleMeals.Add(CustomiseBundle_Menu);
            // ---------------------------------------------------------------------------------------------------------------------------------------------

            // Adding Products to Bundle Meals items
            // -------------------------------------------------------------------------------------------
            // Breakfast Set
            BreakfastSet_Menu.ProductList = new List<Product> { Hotcakes, HashBrown };

            // Hamburger Combo
            HamburgerCombo_Menu.ProductList = new List<Product> { Hamburger, Fries, Cola };

            // Dinner Set
            DinnerSet_Menu.ProductList = new List<Product> { Steak, Fries, Salad, Coffee };
            // ------------------------------------------------------------------------------------------            

            // Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
        }

        private void mainsButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset flags & Customise Bundle
            TradeInFlag = false;
            CustomiseBundleFlag = false;
            CustomiseSideFlag = false;
            CustomiseBeverageFlag = false;
            CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

            // Display ValueMeals
            itemsListView.ItemsSource = ValueMeals;
        }

        private void sidesButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset flags & Customise Bundle
            TradeInFlag = false;
            CustomiseBundleFlag = false;
            CustomiseSideFlag = false;
            CustomiseBeverageFlag = false;
            CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

            // Display Sides
            itemsListView.ItemsSource = Sides;
        }

        private void beveragesButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset flags & Customise Bundle
            TradeInFlag = false;
            CustomiseBundleFlag = false;
            CustomiseSideFlag = false;
            CustomiseBeverageFlag = false;
            CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

            // Reset trade in value
            foreach (Beverage b in Beverages)
            {
                b.TradeIn = 0.00;
            }

            // Refresh Listview
            itemsListView.ItemsSource = null;
            // Display Beverages
            itemsListView.ItemsSource = Beverages;
        }

        private void bundlesButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset flags & Customise Bundle
            TradeInFlag = false;
            CustomiseBundleFlag = false;
            CustomiseSideFlag = false;
            CustomiseBeverageFlag = false;
            CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

            // Display Default Menu(Bundle Set)
            itemsListView.ItemsSource = BundleMeals;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            // If user has selected an item on the menu
            if (itemsListView.SelectedItem != null)
            {
                // Run only when there is an option to trade in drink
                if (TradeInFlag)
                {
                    // Return flags back to false 
                    TradeInFlag = false;

                    // Creating a copy of original order item
                    OrderItem oi_modified = new OrderItem(oi.Item.Copy());

                    // Modifing the productList and Price of new item
                    oi_modified.Item.ProductList[BeverageIndex] = ((Beverage)itemsListView.SelectedItem).Copy();

                    // Add to order and display confirmation message
                    Order.Add(oi_modified);
                    displayText.Text = String.Format("{0} added.\nTotal: ${1:0.00}\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", oi_modified.Item.Name, Order.GetTotalAmt());

                    // Return menu display to default after adding to cart
                    itemsListView.ItemsSource = BundleMeals;
                }

                // Run only when customise bundle is selected
                else if (CustomiseBundleFlag)
                {
                    // Return flag back to false 
                    CustomiseBundleFlag = false;

                    // Add selected item to product list
                    CustomiseBundle_Menu.ProductList.Add((ValueMeal)itemsListView.SelectedItem);

                    //Display selected items for customised bundle in displayText
                    displayText.Text = String.Format("Value Meal selected: {0}", CustomiseBundle_Menu.ProductList[0].Name);

                    // Display Sides list
                    itemsListView.ItemsSource = Sides;

                    // Set flag for next step
                    CustomiseSideFlag = true;
                }

                // Select side for customise bundle
                else if (CustomiseSideFlag)
                {
                    // Return flag back to false 
                    CustomiseSideFlag = false;

                    // Add selected item to product list
                    CustomiseBundle_Menu.ProductList.Add((Side)itemsListView.SelectedItem);

                    //Display selected items for customised bundle in displayText
                    displayText.Text = String.Format("Value Meal selected: {0}\nSide selected: {1}", CustomiseBundle_Menu.ProductList[0].Name, CustomiseBundle_Menu.ProductList[1].Name);

                    // Display Sides list
                    itemsListView.ItemsSource = Beverages;

                    // Set flag for next step
                    CustomiseBeverageFlag = true;
                }

                else if (CustomiseBeverageFlag)
                {
                    // Return flag back to false 
                    CustomiseBeverageFlag = false;

                    // Add selected item to product list
                    CustomiseBundle_Menu.ProductList.Add((Beverage)itemsListView.SelectedItem);

                    // Check if selected items already make up a premade bundle
                    String Check = "";
                    int Index = 0;
                    bool PremadeFlag = false;

                    // Get names of products in customised bundle (except beverage)
                    foreach (Product p in CustomiseBundle_Menu.ProductList)
                    {
                        if (p is Beverage)
                        {
                            continue;
                        }
                        Check += p.Name;
                    }

                    // Get names of products in current bundles (except beverage)
                    for (int i = 0; i < BundleMeals.Count; i++)
                    {
                        if (BundleMeals[i].Name == "Customise Bundle")
                        {
                            continue;
                        }

                        String Premade = "";
                        foreach (Product p in BundleMeals[i].ProductList)
                        {
                            if (p is Beverage)
                            {
                                continue;
                            }
                            Premade += p.Name;
                        }

                        // Compare the product lists
                        if (Check == Premade)
                        {
                            PremadeFlag = true;
                            Index = i;
                            break;
                        }
                    }

                    // Run if selected items is already a premade bundle
                    if (PremadeFlag)
                    {
                        displayText.Text = String.Format("The products you have selected is already a bundle meal ({0})\nPlease select '{0}' in the list\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", BundleMeals[Index].Name);
                    }

                    // Run if selected items do not make up a premade bundle
                    else
                    {
                        // Calculate price of customised bundle
                        double Total = 0.00;
                        foreach (Product p in CustomiseBundle_Menu.ProductList)
                        {
                            Total += p.Price;
                        }
                        CustomiseBundle_Menu.Price = Total * 0.9;

                        // Add to order and display confirmation message
                        Order.Add(new OrderItem(CustomiseBundle_Menu.Copy()));
                        displayText.Text = String.Format("{0} added.\nTotal: ${1:0.00}\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", CustomiseBundle_Menu.Name, Order.GetTotalAmt());
                    }

                    // Reset Customise menu back to default
                    CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

                    // Return menu display to default after adding to cart
                    itemsListView.ItemsSource = BundleMeals;
                }

                else
                {
                    // Check if selected item is bundle meal
                    if (itemsListView.SelectedItem is MenuItem)
                    {
                        oi = new OrderItem((MenuItem)itemsListView.SelectedItem);

                        // Customise Bundle
                        if (oi.Item.Name == "Customise Bundle")
                        {
                            // Reset trade in value
                            foreach (Beverage b in Beverages)
                            {
                                b.TradeIn = 0.00;
                            }

                            // Display list of value meals
                            itemsListView.ItemsSource = ValueMeals;
                            CustomiseBundleFlag = true;
                        }

                        // Check if selected bundle meal has beverage
                        else if (oi.Item.ProductList.FindIndex(x => x is Beverage) != -1)
                        {
                            // Find index of beverage in bundle meal's product list
                            BeverageIndex = oi.Item.ProductList.FindIndex(x => x is Beverage);
                            // Set tradein price to price of default beverage
                            foreach (Beverage b in Beverages)
                            {
                                b.TradeIn = oi.Item.ProductList[BeverageIndex].Price;
                            }

                            // Display list of beverages for tradein
                            itemsListView.ItemsSource = Beverages;
                            TradeInFlag = true;
                        }

                        else
                        {
                            // Add to order and display confirmation message
                            Order.Add(oi);
                            displayText.Text = String.Format("{0} added.\nTotal: ${1:0.00}\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", oi.Item.Name, Order.GetTotalAmt());
                        }
                    }

                    else
                    {
                        oi = new OrderItem(new MenuItem(((Product)itemsListView.SelectedItem).Name, ((Product)itemsListView.SelectedItem).Price));

                        // Add to order and display confirmation message
                        oi.Item.ProductList.Add((Product)itemsListView.SelectedItem);
                        Order.Add(oi);
                        displayText.Text = String.Format("{0} added.\nTotal: ${1:0.00}\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", oi.Item.Name, Order.GetTotalAmt());
                    }
                }

                // Clear cartsListView
                cartsListView.ItemsSource = null;
                cartsListView.ItemsSource = Order.ItemList;
            }

            // If user did not select an item on the menu
            else
                displayText.Text = String.Format("Please select an item on the menu to add to your cart.\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.");
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            if (Order.ItemList.Count == 0)
            {
                displayText.Text = "Please select an item\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.";
            }

            // Display receipt
            else
            {
                //Increase the receipt number by 1 (Everytime order is confirmed)
                Order.OrderNo += 1;
                displayText.Text = "Tom's Cafe\n\n" + Order.ToString();

                //Clear order after confirmation
                cartsListView.ItemsSource = null;
                Order.ItemList.Clear();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset flags & Customise Bundle
            TradeInFlag = false;
            CustomiseBundleFlag = false;
            CustomiseSideFlag = false;
            CustomiseBeverageFlag = false;
            CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

            // If customer attempts to clear a list with menu items
            if (Order.ItemList.Count != 0)
            {
                // Clear cartsListView
                cartsListView.ItemsSource = null;

                //Clear all items from Order object(cart)
                Order.ItemList.Clear();

                displayText.Text = String.Format("Your order has been cancelled.\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.");

                // Return customer to Bundle Meals menu
                itemsListView.ItemsSource = BundleMeals;
            }

            // If customer tries to clear cart even when no items are in it
            else
            {
                displayText.Text = String.Format("There is nothing in your cart.\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.");

                // Return customer to Bundle Meals menu
                itemsListView.ItemsSource = BundleMeals;
            }

        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset flags & Customise Bundle
            TradeInFlag = false;
            CustomiseBundleFlag = false;
            CustomiseSideFlag = false;
            CustomiseBeverageFlag = false;
            CustomiseBundle_Menu = new MenuItem("Customise Bundle", 0.00);

            // If customer selected an item correctly
            if (cartsListView.SelectedItem is OrderItem)
            {
                Order.Remove(cartsListView.SelectedIndex);

                displayText.Text = String.Format("{0} has been removed.\nTotal: ${1:0.00}\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", ((OrderItem)cartsListView.SelectedItem).Item.Name, Order.GetTotalAmt());

                // Clear cartsListView
                cartsListView.ItemsSource = null;

                // Display cartsListView to show updated quantity
                cartsListView.ItemsSource = Order.ItemList;
            }

            // If customer's cart still has item but tries to remove an item without selecting something
            else if ((Order.ItemList.Count >= 1) && (cartsListView.SelectedItem is null))
            {
                displayText.Text = String.Format("Please select an item.\nTotal: ${0:0.00}\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.", Order.GetTotalAmt());
            }

            // If customer tries to remove something from an empty cart
            else
            {
                displayText.Text = String.Format("There is nothing in your cart.\n\nWelcome to Tom's Cafe!\n\nChoose your item from the menu.");

                // Return customer to Bundle Meals menu
                itemsListView.ItemsSource = BundleMeals;
            }
        }
    }
}