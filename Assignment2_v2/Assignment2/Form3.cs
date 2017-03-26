using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//LELAND SHANE AND OSCAR MARTINEZ
namespace Assignment2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.listBox2.DragDrop += new
            System.Windows.Forms.DragEventHandler(this.listBox2_DragDrop);
            this.listBox2.DragEnter += new
                       System.Windows.Forms.DragEventHandler(this.listBox2_DragEnter);
        }
        private void listBox2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listBox2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            listBox2.Items.Clear();
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < s.Length; i++)
                listBox2.Items.Add(s[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        { //browse
            //openFileDialog1.ShowDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            { //OK
                string filePath = openFileDialog1.FileName;
                listBox2.Items.Clear();
                listBox2.Items.Add(filePath);
            }
            else if (result == DialogResult.Cancel)
            { //cancel
                MessageBox.Show("The browse operation has been cancelled.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { //open
            int i = listBox2.Items.Count;
            if (i == 0)
                MessageBox.Show("You have not selected a file");
            else
            {
                openSelected = true;
                listBox2.SelectedIndex = 0;
                newFilePath = listBox2.SelectedItem.ToString();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { //cancel
            openSelected = false;
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
