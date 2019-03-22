using System;
using System.Windows.Forms;
using System.Drawing;
namespace TesterClient
{
    public partial class GetResult : Form
    {
        public Point mouseLocation;
        public GetResult()
        {
            InitializeComponent();
        }

        private void GetResult_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void GetResult_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            Text = auth.user + ": " + GetTest.selected_test + " Результат.";
            label5.Text = auth.user + ": " + GetTest.selected_test + " Результат.";
            for (int i = 0; i < Requests.test_lenght; i++)
            {
                if (Requests.usr_answs[i] == 0 | Requests.usr_answs[i] == 3)
                {
                    Requests.red++;
                }
                if (Requests.usr_answs[i] == 1)
                {
                    Requests.green++;
                }
            }
            var res = Requests.test_lenght / 5;
            var ocenka = 2;
            if (Requests.green >= res*2)
            {
                ocenka = 3;
            }
            if (Requests.green >= res*3)
            {
                ocenka = 4;
            }
            if (Requests.green >= res*4)
            {
                ocenka = 5;
            }
            label1.Text = Requests.green + " правильных вопросов из " + Requests.test_lenght;
            label2.Text = "Оценка: " + ocenka;
            chart1.Series["s1"].Points.AddXY("Верно", Requests.green);
            chart1.Series["s1"].Points.AddXY("Неверно", Requests.red);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void GetResult_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void GetResult_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }
    }
}