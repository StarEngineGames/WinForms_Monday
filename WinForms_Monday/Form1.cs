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

        /*
            1) Запустить через CTRL+F5 два экземпляра приложения
            2) В одном выбрать Сервер и нажать подключиться 
            3) В другом выбрать Клиент и нажать подключиться
            4) В экземпляре с выбранным Сервер нажать на квадратную кнопку. Это событие перекрасит её, 
                добавит текст и отправит в экземпляр с Клиентом, что вызовет изменение внешнего вида кнопки и в нем.
        */


        private void button1_Click(object sender, EventArgs e)
        {
            //Подключение если выбран сервер
            if(radioButton1.Checked)
            {
                listenSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000)); //ip адрес сервера
                listenSocket.Listen(10);

                textBox1.Text = "Ваш ход";

                client = listenSocket.Accept();
            }
            //Если выбран клиент
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

                bytes = listenSocket.Receive(d); //ожидание получения данных

                // полученные данные
                string ass = Encoding.Unicode.GetString(d, 0, bytes);
                if(ass == "1")
                {
                    button2.BackColor = System.Drawing.Color.Red;
                    button2.Text = "O";
                    button2.Enabled = false;
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

        //Нажатие на квадратную кнопку
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button2.BackColor = System.Drawing.Color.Red;
                button2.Text = "O";
                button2.Enabled = false;

                work("1", client);
                textBox1.Text = "Ходит клиент";
            }
        } 
    }
}
