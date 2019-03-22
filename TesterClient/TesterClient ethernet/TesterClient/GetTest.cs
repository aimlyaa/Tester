using System;
using System.Drawing;
using System.Windows.Forms;

namespace TesterClient
{
    public partial class GetTest : Form
    {
        public Point mouseLocation;
        public GetTest()
        {
            InitializeComponent();
        }

        private void GetTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    public class RootObject
    {
        public tst[] Jsons { get; set; }
    }
        public class tst
        {
            public string[] answers { get; set; }
            public string[] quetsions { get; set; }
        }
        public static string selected_test = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                selected_test = listBox1.SelectedItem.ToString();
            }
            catch
            {

            }
            if (selected_test != null)
            {
                string json = Requests.GET("http://sprut-2.ddns.net:8080/", "get_test", Requests.token, selected_test);
                //string json = Requests.GET("http://127.0.0.1:8080/", "get_test", Requests.token, selected_test);
                foreach (string item in json.Split(';'))
                {
                    if (Requests.ended == 1)
                    {
                        GetResult GetResultForm = new GetResult();
                        Hide();
                        GetResultForm.Show();
                    }
                    else
                    {
                        Test TestForm = new Test();
                        Hide();
                        TestForm.Show();
                    }
                }
            }
        }

        private void GetTest_Load(object sender, EventArgs e)
        {
            string json = Requests.GET("http://sprut-2.ddns.net:8080/", "test_list", Requests.token, null);
            //string json = Requests.GET("http://127.0.0.1:8080/", "test_list", Requests.token, null);
            foreach (string item in json.Split(';'))
            {
                listBox1.Items.Add(item);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetTest_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void GetTest_MouseMove(object sender, MouseEventArgs e)
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
