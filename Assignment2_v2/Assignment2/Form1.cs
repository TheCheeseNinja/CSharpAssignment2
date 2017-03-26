using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//LELAND SHANE AND OSCAR MARTINEZ
namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char[] delim = { ' ', ';', ',', '\t'};
        List<PersonEntry> people = new List<PersonEntry>();
        int counter;
        private void Form1_Load(object sender, EventArgs e)
        {
            counter = 0;
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                { //OK
                    string filePath = openFileDialog1.FileName;
                    StreamReader inputFile = File.OpenText(filePath);
                    PersonEntry person;
                    while (!inputFile.EndOfStream)
                    {
                        string[] info = inputFile.ReadLine().Split(delim);
                        person = new PersonEntry(info[0], info[1], info[2], info[3]);
                        people.Add(person);
                        listBox1.Items.Add(people[counter].FirstName + "\t" + people[counter].LastName + "\t" +
                            people[counter].Email + "\t" + people[counter].PhoneNumber);
                        counter++;
                    }
                    inputFile.Close();
                    button2.Enabled = true;
                }
                else if (result == DialogResult.Cancel)
                { //cancel
                    MessageBox.Show("You have not selected a file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nPlease select a text file that meets the parameters");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //
            int i = listBox1.SelectedIndex;
            f2.Text = people[i].FullName;
            f2.fNameLabel.Text = people[i].FirstName;
            f2.lNameLabel.Text = people[i].LastName;
            f2.emailLabel.Text = people[i].Email;
            f2.phoneLabel.Text = people[i].PhoneNumber;
            //
            f2.ShowDialog();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { //newFile brings up form 3 and utilizes click and drag into list boxes!
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if (f3.openSelected == true)
            {
                people.Clear();
                listBox1.Items.Clear();
                counter = 0;
                try
                {
                    string filePath = f3.newFilePath;
                    StreamReader inputFile = File.OpenText(filePath);
                    PersonEntry person;
                    while (!inputFile.EndOfStream)
                    {
                        string[] info = inputFile.ReadLine().Split(delim);
                        person = new PersonEntry(info[0], info[1], info[2], info[3]);
                        people.Add(person);
                        listBox1.Items.Add(people[counter].FirstName + "\t" + people[counter].LastName + "\t" +
                            people[counter].Email + "\t" + people[counter].PhoneNumber);
                        counter++;
                    }
                    inputFile.Close();
                    button2.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nPlease select a text file that meets the parameters");
                }
            }
            else
            {
                MessageBox.Show("New Text File operation cancelled.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //clear
            people.Clear();
            listBox1.Items.Clear();
            button2.Enabled = false;
        }
    }
    class PersonEntry
    {
        private string _firstName, _lastName, _email, _phoneNumber, _fullName;
        //
        public PersonEntry()
        {
            _firstName = "";
            _lastName = ""; 
            _email = "";
            _phoneNumber = "";
            _fullName = _firstName + " " + _lastName;
        }
        public PersonEntry(string a, string b, string c, string d)
        {
            _firstName = a;
            _lastName = b; 
            _email = c;
            _phoneNumber = d;
            _fullName = _firstName + " " + _lastName;
        }
        //
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email= value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
            }
        }
    }
}
