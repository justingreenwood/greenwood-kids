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

namespace SloppyJoes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MakeTheMenu();
        }

        private void MakeTheMenu()
        {

            MenuItem[] menuItems = new MenuItem[5];
            string guacamolePrice;

            for(int i = 0; i<5; i++)
            {

                menuItems[i] = new MenuItem();
                if(i>= 3)
                {

                    menuItems[i].Breads = new string[] { "pumpkin bagel", "cheese bagel", "chocolate chip bagel", "whole wheat bagel", "regular bagel" };

                }
                menuItems[i].Generate();

            }

            item1.Text = menuItems[0].Description;
            price1.Text = menuItems[0].Price;
            item2.Text = menuItems[1].Description;
            price2.Text = menuItems[1].Price;
            item3.Text = menuItems[2].Description;
            price3.Text = menuItems[2].Price;
            item4.Text = menuItems[3].Description;
            price4.Text = menuItems[3].Price;
            item5.Text = menuItems[4].Description;
            price5.Text = menuItems[4].Price;

            MenuItem specialMenuItem = new MenuItem()
            {
                Meats = new string[] { "Steak", "Veggie burger", "Salmon" },
                Breads = new string[] { "donut", "rice bun", "garlic bread" },
                Sauces = new string[] { "1000 island dressing", "Sweet Baby Rays", "garlic sauce" }

            };
            specialMenuItem.Generate();

            item6.Text = specialMenuItem.Description;
            price6.Text = specialMenuItem.Price;

            MenuItem guacamoleMenuItem = new MenuItem();
            guacamoleMenuItem.Generate();
            guacamolePrice = guacamoleMenuItem.Price;

        }

    }
}
