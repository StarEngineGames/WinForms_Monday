using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WinForms_Monday
{
    public partial class Form1 : Form
    {
        public Socket listenSocket;
        public Socket client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                listenSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000)); //ip адрес сервера
                listenSocket.Listen(10);

                textBox1.Text = "Ваш ход";

                client = listenSocket.Accept();
            }
            else
            {
                textBox1.Text = "Ходит сервер";
                try
                {
                    listenSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000));

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                
                int bytes = 0;
                byte[] d = new byte[256]; // буфер для получаемых данных

                bytes = listenSocket.Receive(d);

                string ass = Encoding.Unicode.GetString(d, 0, bytes);
                if(ass == "1")
                {
                    button2.BackColor = System.Drawing.Color.Red;
                    button2.Text = "O";
                    button2.Enabled = false;
                }
                else if (ass == "2")
                {
                    button3.BackColor = System.Drawing.Color.Red;
                    button3.Text = "O";
                    button3.Enabled = false;
                }
                else if (ass == "3")
                {
                    button3.BackColor = System.Drawing.Color.Red;
                    button3.Text = "O";
                    button3.Enabled = false;
                }
                else if (ass == "4")
                {
                    button4.BackColor = System.Drawing.Color.Red;
                    button4.Text = "O";
                    button4.Enabled = false;
                }
                else if (ass == "5")
                {
                    button5.BackColor = System.Drawing.Color.Red;
                    button5.Text = "O";
                    button5.Enabled = false;
                }
                else if (ass == "6")
                {
                    button6.BackColor = System.Drawing.Color.Red;
                    button6.Text = "O";
                    button6.Enabled = false;
                }
                else if (ass == "7")
                {
                    button7.BackColor = System.Drawing.Color.Red;
                    button7.Text = "O";
                    button7.Enabled = false;
                }
                else if (ass == "8")
                {
                    button8.BackColor = System.Drawing.Color.Red;
                    button8.Text = "O";
                    button8.Enabled = false;
                }
                else if (ass == "9")
                {
                    button9.BackColor = System.Drawing.Color.Red;
                    button9.Text = "O";
                    button9.Enabled = false;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
        }

        public void work(String num, Socket s)
        {
            
               
            byte[] data = Encoding.Unicode.GetBytes(num);
            s.Send(data);
           
            byte[] getData = new byte[256];
            s.Receive(getData);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button2.BackColor = System.Drawing.Color.Red;
                button2.Text = "O";

                work("1", client);
                textBox1.Text = "Ходит клиент";


                button2.Enabled = false;
            }
            else
            {
                button2.BackColor = System.Drawing.Color.LightGreen;
                button2.Text = "X";

                work("11", client);
                textBox1.Text = "Ходит Сервер";
                

                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button3.BackColor = System.Drawing.Color.Red;
                button3.Text = "O";
                button3.Enabled = false;
            }
            else
            {
                button3.BackColor = System.Drawing.Color.LightGreen;
                button3.Text = "X";
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button4.BackColor = System.Drawing.Color.Red;
                button4.Text = "O";
                button4.Enabled = false;
            }
            else
            {
                button4.BackColor = System.Drawing.Color.LightGreen;
                button4.Text = "X";
                button4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button5.BackColor = System.Drawing.Color.Red;
                button5.Text = "O";
                button5.Enabled = false;
            }
            else
            {
                button5.BackColor = System.Drawing.Color.LightGreen;
                button5.Text = "X";
                button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button6.BackColor = System.Drawing.Color.Red;
                button6.Text = "O";
                button6.Enabled = false;
            }
            else
            {
                button6.BackColor = System.Drawing.Color.LightGreen;
                button6.Text = "X";
                button6.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button7.BackColor = System.Drawing.Color.Red;
                button7.Text = "O";
                button7.Enabled = false;
            }
            else
            {
                button7.BackColor = System.Drawing.Color.LightGreen;
                button7.Text = "X";
                button7.Enabled = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button8.BackColor = System.Drawing.Color.Red;
                button8.Text = "O";
                button8.Enabled = false;
            }
            else
            {
                button8.BackColor = System.Drawing.Color.LightGreen;
                button8.Text = "X";
                button8.Enabled = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button9.BackColor = System.Drawing.Color.Red;
                button9.Text = "O";
                button9.Enabled = false;
            }
            else
            {
                button9.BackColor = System.Drawing.Color.LightGreen;
                button9.Text = "X";
                button9.Enabled = false;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button10.BackColor = System.Drawing.Color.Red;
                button10.Text = "O";
                button10.Enabled = false;
            }
            else
            {
                button10.BackColor = System.Drawing.Color.LightGreen;
                button10.Text = "X";
                button10.Enabled = false;
            }
        }
    }
}
