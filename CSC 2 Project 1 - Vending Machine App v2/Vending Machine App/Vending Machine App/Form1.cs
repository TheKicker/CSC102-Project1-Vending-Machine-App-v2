using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

//***************************************//
//  
//  "Version 1"                                     
//  Cavan Lemasters                      
//  CSC 101 Vending Machine Proj         
//  April 2017  (Due May 2017)                         
//  *Created program using basic programming
//  *Basic decimal / int values and their relationships 
//   
//  **UPDATED "Version 2"
//  Cavan Lemasters & Josh Gilliland (Tutor)
//  CSC 102 Vending Machine Proj
//  October 2017 (Due Nov 2017)
//  *Code is structured
//  *Cleaned and shortened by over 100 lines of code
//  
//  **UPDATED "Version 3"
//  Cavan Lemasters
//  Not started
//  *Plan to implement classes into code
//  *Item.cs file is created for this
//                                       
//***************************************//

namespace Vending_Machine_App
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            VendMachList = ReadFile();
        }

        /*
         *  Vending Machine Physical Layout 
         * 
         *  Sprite      Pepsi           CocaCola    Gum 
         *  Lemonade    Tea             Water       Warheads
         *  MandMs      Skittles        Snickers    Twix
         *  Lays        SaltandVinegar  Pickle      Doritos
         *  
         */


        // Prepare the items for our Structure
        struct VendItem
        {
            // Create our item detail variables 
            public string _itemName;
            public double _itemInventory;
            public decimal _itemPrice;

            public string ItemName // The users food/drink selection
            {          
                get { return _itemName; }
                set { _itemName = value; }
            }

            public double ItemInventory  // The inventory available of selected item
            {
                get { return _itemInventory; }
                set { _itemInventory = value; }
            }

            public decimal ItemPrice          // The price of the item selected
            {
                get { return _itemPrice; }
                set { _itemPrice = value; }
            }
            
        }


        List<VendItem> VendMachList = new List<VendItem>();

        // Read the VendMachItems.txt file 
        private List<VendItem> ReadFile()
        {

            // Creates a list called ItemInfo populated of type VendItem
            List<VendItem> ItemInfo = new List<VendItem>();

            try
            {
                StreamReader inputFile;
                string Line;

                VendItem entry = new VendItem();              

                char[] delim = { ',' };

                inputFile = File.OpenText("VendMachItems.txt");


                while (!inputFile.EndOfStream)
                {
                    Line = inputFile.ReadLine();

                    string[] tokens = Line.Split(delim);


                    entry.ItemName = tokens[0];
                    entry.ItemInventory = Convert.ToDouble(tokens[1]);
                    entry.ItemPrice = Convert.ToDecimal(tokens[2]);

                    ItemInfo.Add(entry);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
                // Return the item's info 
                return ItemInfo;

        }

        
        // Sets up total price reference 
        public decimal TotalPrice = 0.00m;
        public decimal ContPrice = 0.00m;

        // Our method we'll use for the action of each item  
        private void Choice(VendItem i, PictureBox p, int loc)
        {

            if (i.ItemInventory > 0)
            {
                VendItem locItem = new VendItem();

                locItem.ItemInventory = i.ItemInventory - 1;
                locItem.ItemPrice = i.ItemPrice;
                locItem.ItemName = i.ItemName;


                VendMachList[loc] = locItem;

                TotalPrice = TotalPrice + i.ItemPrice;
                listBox1.Items.Add(i.ItemName);
                label1.Text = "$ " + TotalPrice.ToString();
            }
            else
            {
                // If item is out of inventory ( ItemInv < 1 )
                MessageBox.Show("Sorry we are all out of that item!");
                // Hides empty stock 
                p.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) // Sprite
        {
            Choice(VendMachList[0], pictureBox1, 0);
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)  // Pepsi
        {
            Choice(VendMachList[1], pictureBox2, 1);
        }

        private void CheckoutButton_Click(object sender, EventArgs e) // Checkout Button
        {

            // If user has selected an item they can check out
            if (TotalPrice > 0)
            {
                // Informs user of final total
                MessageBox.Show("Thank you for your purchase of " + TotalPrice);
                // Clears cart
                listBox1.Items.Clear();
                // Resets the current total label for next user
                label1.Text = ("$ 00.00");
                // Adds to running total of what the machine has earned this session
                ContPrice = ContPrice + TotalPrice;
                // Puts Cumulative Price in Label 3 by refresh button 
                label3.Text = "$ " + ContPrice.ToString();
                // Clears Total Price
                TotalPrice = 0.00m;
            }
            // If no selection has been made -- they must choose something before checking out
            else
            {
                MessageBox.Show("Please buy something before attempting to checkout!");
            }
        }




        private void RefreshButton_Click(object sender, EventArgs e) // Refresh Button 
        {
                PictureBox[] pictures = {pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10,
                pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16};

                for (int index = 0; index < pictures.Length; index++)
                {
                    VendItem locItem = new VendItem();

                    locItem.ItemInventory = 5;
                    locItem.ItemPrice = VendMachList[index].ItemPrice;
                    locItem.ItemName = VendMachList[index].ItemName;

                    VendMachList[index] = locItem;

                    pictures[index].Show();
                }

            // Clears all the factors that change - clears labels, clears list of cart, clears current count of money accumulated
            label1.Text = ("$ 0.00");
            listBox1.Items.Clear();
            TotalPrice = 0.00m;
            ContPrice = 0.00m;
            label3.Text = ("");
        }

        private void ExitButton_Click(object sender, EventArgs e)   // Exit Button
        {
            // Thanks user and closes app 
            MessageBox.Show("Thank you and have a great day!!");
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)  // Coca Cola
        {
            Choice(VendMachList[2], pictureBox3, 2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)  // Gum
        {
            Choice(VendMachList[3], pictureBox4, 3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)  // Lemonade
        {
            Choice(VendMachList[4], pictureBox5, 4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)  // Tea
        {
            Choice(VendMachList[5], pictureBox6, 5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)  // Water
        {
            Choice(VendMachList[6], pictureBox7, 6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)  // Warheads
        {
            Choice(VendMachList[7], pictureBox8, 7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)  // M&Ms
        {
            Choice(VendMachList[8], pictureBox9, 8);
        }

        private void pictureBox10_Click(object sender, EventArgs e) // Skittles
        {
            Choice(VendMachList[9], pictureBox10, 9);
        }

        private void pictureBox11_Click(object sender, EventArgs e) // Snickers
        {
            Choice(VendMachList[10], pictureBox11, 10);
        }

        private void pictureBox12_Click(object sender, EventArgs e) // Twix
        {
            Choice(VendMachList[11], pictureBox12, 11);
        }

        private void pictureBox13_Click(object sender, EventArgs e) // Lays
        {
            Choice(VendMachList[12], pictureBox13, 12);
        }

        private void pictureBox14_Click(object sender, EventArgs e) // Salt and Vinegar
        {
            Choice(VendMachList[13], pictureBox14, 13);
        }

        private void pictureBox15_Click(object sender, EventArgs e) // Pickle
        {
            Choice(VendMachList[14], pictureBox15, 14);
        }

        private void pictureBox16_Click(object sender, EventArgs e) // Doritos
        {
            Choice(VendMachList[15], pictureBox16, 15);
        }

        // End of Code //
    }
}
