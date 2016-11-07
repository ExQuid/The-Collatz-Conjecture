using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MessageBox = System.Windows.MessageBox;

namespace MathEq
{
    /// <summary>
    /// Interaction logic for TCC_Client.xaml
    /// </summary>
    public partial class TCC_Client : MetroWindow
    {
        public TCC_Client()
        {
            InitializeComponent();
        }
        List<string> numberList = new List<string>(); // Creates the list for the numbers

        private async void btn_visitgithub_Click(object sender, RoutedEventArgs e)
        {
            var link = "https://github.com/exquid/";
            MessageDialogResult result = await this.ShowMessageAsync("Are you sure you want to visit webpage?", "Are you sure you want to visit " + link, MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
                System.Diagnostics.Process.Start(link);
            else return;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = ""; //Clears the textbox if the clear button is pressed
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ulong.Parse(textBox.Text);
            }
            catch
            {
                await this.ShowMessageAsync("Logic Error", "Please enter NUMBERS!");
                return;
            }


            int counter = 0; //Creates a the counter to count how many results there are
            ulong number = ulong.Parse(textBox.Text); //Makes the input into a ulong(UINT64)
            numberList.Clear(); // Clears the list of numbers if there are any
            textBox1.Text = ""; //Empties the result box
            while (true) // Main loop
            {
                // ALL THE MATH
                /*___________________________________________________________________*/
                if (number == 1)// Checks if the number is equal to 1 if so break
                {
                    break;
                }
                if (number % 2 == 0) // Checks if the number is even. If so slice it in half
                {
                    number = (ulong)(number / 2);
                }
                else number = (ulong)(number * 3 + 1); // If the number is not even multiply it by 3 and add 1 on top of that.

                counter += 1;

                numberList.Add(counter.ToString() + ". " + number.ToString() + "\r\n"); // Adds the number to the list
                /*___________________________________________________________________*/
            }
            foreach (string data in numberList)
            {
                textBox1.AppendText(data); // Writes the numberlist into the program
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Saves the data
            /*___________________________________________________________________*/
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "CollatzConjecture.txt";
            dialog.Filter = "Text File (.txt)|*.txt";

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            FileStream stream = File.Open(dialog.FileName, FileMode.Create); // Opens a filestream to the desktop to save Collatz Conjecture.txt
            foreach (string data in numberList) // Does the same as the foreach did earlier but with a diffrent goal
            {
                byte[] temp = new UTF8Encoding(true).GetBytes(data.ToString());
                stream.Write(temp, 0, data.ToString().Length); // Adds the data to the txt file
            }
            stream.Close();
            /*___________________________________________________________________*/
        }


        private async void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void textBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}
