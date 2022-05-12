using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onoff_Controller
{
    public partial class Form1 : Form
    {
        double refe,uk=0,yk=0;
        bool tmpst=false;   

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                refe = double.Parse(textBox1.Text);
                timer1.Enabled = true;
                tmpst = true;

            }
            catch
            {
                MessageBox.Show("Invalid Ref!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //yk = double.Parse(serialPort1.ReadLine());
            //serialPort1.WriteLine(uk.ToString());

            if (yk < refe - 5 && tmpst)
            {
                uk = 1;
                textBox2.Text = uk.ToString();
            }
            else if (yk >= refe + 5 )
            {
                uk = 0;
                textBox2.Text = uk.ToString();
            }
        }

        private void serialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            //serialPort1.WriteLine(uk.ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            serialPort1.WriteLine(uk.ToString());
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //yk = double.Parse(serialPort1.ReadLine());
            //textBox3.Text=yk.ToString();
            string rev_data = serialPort1.ReadLine();
            textBox3.Text=rev_data;
            yk = double.Parse(rev_data);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            Control.CheckForIllegalCrossThreadCalls = false;
            serialPort1.Open();
        }
    }
}
