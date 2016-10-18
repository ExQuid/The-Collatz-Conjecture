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
using System.Text.RegularExpressions;
using System.IO;

namespace MathEq
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> numberList = new List<string>(); // Creates the list for the numbers
        public MainWindow()
        {
            InitializeComponent();
            textBox1.VerticalScrollBarVisibility = ScrollBarVisibility.Visible; // Creates a scrollbar for the result box
            textBox1.IsReadOnly = true; // Makes sure the user can´t edit the result box
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(textBox.Text, "^[0-9]*$")) //Checks if there are letters in the input
            {
                MessageBox.Show("Please enter NUMBERS!", "Logic Error", MessageBoxButton.OK, MessageBoxImage.Error); // Sends an error box if letter is entered
                textBox.Clear();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0; //Creates a the counter to count how many results there are
            ulong number = ulong.Parse(textBox.Text); //Makes the input into a ulong(UINT64)
            numberList.Clear(); // Clears the list of numbers if there are any
            textBox1.Text = ""; //Empties the result box
            while (true) // Main loop
            {
                // ALL THE MATH
                /*___________________________________________________________________*/
                if (number == 1)
                {
                    break;
                }
                if (number % 2 == 0)
                {
                    number = (ulong)(number / 2);
                }
                else number = (ulong)(number * 3 + 1);
                counter += 1;
                if(!number.Equals(1337))
                numberList.Add(counter.ToString() + ". " + number.ToString() + "\r\n");
                /*___________________________________________________________________*/
                else 
                    numberList.Add(counter.ToString() + ". " + number.ToString()+ " :) " + "\r\n");
            }
            foreach (string data in numberList)
            {
                textBox1.AppendText(data);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = ""; //Clears the textbox if the clear button is pressed
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Saves the data
            /*___________________________________________________________________*/
            FileStream stream = File.Open(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Collatz Conjecture.txt", FileMode.Create);
            foreach (string data in numberList)
            {
                byte[] temp = new UTF8Encoding(true).GetBytes(data.ToString());
                stream.Write(temp, 0, data.ToString().Length);

            }
            stream.Close();
            /*___________________________________________________________________*/
        }
    }
}
