using System;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace TesterClient
{
    public partial class auth : Form
    {
        public Point mouseLocation;
        public auth()
        {
            InitializeComponent();
        }
        public static string group = null;
        public static string user = null;
        static bool shit = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length !=0 & textBox2.Text.Length !=0)
            {
                group = textBox1.Text;
                foreach (var i in textBox2.Text) //делаем первые буквы инициалов заглавными
                {
                    if (shit)
                    {
                        user = user + i.ToString().ToUpper();
                        shit = false;
                    }
                    else
                    {
                        user = user + i.ToString().ToLower();
                    }
                    if (i == 32)
                    {
                        shit = true;
                    }
                    //label4.Visible = true;
                    //label4.Text = user;
                }
                string token = Requests.POST("http://127.0.0.1:8080/", "auth", textBox1.Text + "," + textBox2.Text + "," + textBox3.Text);
                if (!(token == "False"))
                {
                    GetTest GetTestForm = new GetTest();
                    Hide();
                    GetTestForm.Show();
                }
                else
                {
                    label4.Visible = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (label3.Enabled & textBox3.Enabled)
            {
                label3.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                label3.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void auth_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X,-e.Y);
        }

        private void auth_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(mouseLocation.X,mouseLocation.Y);
                Location = mousePos;
            }
        }
    }
}
