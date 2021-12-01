using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ubike2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Ubike ubike = new Ubike();
        

        private void button1_Click(object sender, EventArgs e)
        {
            ubike = new Ubike();
            ubike.Updatearea();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (Lot l in ubike.lots) listBox2.Items.Add(l.sna);
            foreach(string a in ubike.arealist) listBox1.Items.Add(a);
                    
        }
        // static public JArray getJson(string result)
        
        

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lot l = ubike.getdata(listBox2.SelectedItem.ToString());
            richTextBox1.Text = l.ToString();
            Showdata(l);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (Lot l in ubike.area(listBox1.SelectedItem.ToString())) listBox2.Items.Add(l.sna);
        }

        public void Showdata(Lot l)
        {
            textBox1.Text = l.sna;
            textBox2.Text = l.sbi.ToString();
            if (l.sbi <= 1) textBox2.BackColor = Color.IndianRed;
            else textBox2.BackColor = Color.White;
            textBox3.Text = l.bemp.ToString();
        }
    }

   
}
