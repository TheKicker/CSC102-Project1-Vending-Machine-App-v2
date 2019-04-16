using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vending_Machine_App
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Starting with 2nd form, button to continue to the next part of the app (Form1)
            // Hides Form2
            this.Hide();

            // Declares a new form (Form1) and shows corresponding dialog
            Form Form1 = new Form1();
            Form1.ShowDialog();

            // Closes Form2
            this.Close();

            
        }
    }
}
