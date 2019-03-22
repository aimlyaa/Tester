using System;
using System.Drawing;
using System.Windows.Forms;

namespace TesterClient
{
    public partial class Test : Form
    {
        public Point mouseLocation;
        public Test()
        {
            InitializeComponent();
        }
        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        public static string selected_answ = null;
        public static int butt_counter = 0;
        public static int actual_question = 0;
        public static int timer_full = Requests.test_timer;
        public void privet_mir(int k)
        {
            groupBox1.Controls.Clear();

            int pos_x = 6;
            int pos_y = 22;
            PictureBox[] picBox = new PictureBox[Requests.test_lenght];
            for (int i = 0; i < Requests.test_lenght; i++)
            {
                SolidBrush mybrush = new SolidBrush(Color.Silver);
                if (Requests.usr_answs[i] == 3)
                {
                    mybrush = new SolidBrush(Color.Silver);
                }
                if (Requests.usr_answs[i] == 1)
                {
                    mybrush = new SolidBrush(Color.Lime);
                }
                if (Requests.usr_answs[i] == 0)
                {
                    mybrush = new SolidBrush(Color.Red);
                }
                if (i == k)
                {
                    mybrush = new SolidBrush(Color.DimGray);
                    Bitmap temp_image = new Bitmap(1528 / (Requests.test_lenght + 6), 58);
                    Graphics temp_g = Graphics.FromImage(temp_image);
                    temp_g.FillRectangle(mybrush, 0, 0, Size.Width / Requests.test_lenght, 58);
                    PictureBox temp_pc = new PictureBox();
                    temp_pc.Name = "temp_pc";
                    temp_pc.Width = 1528 / (Requests.test_lenght + 6);
                    temp_pc.Height = 24;
                    temp_pc.Location = new Point(pos_x, pos_y);
                    temp_pc.Image = temp_image;
                    temp_pc.Visible = true;
                    groupBox1.Controls.Add(temp_pc);
                }
                int currentI = i;
                //Bitmap image = new Bitmap((Size.Width - (26 * Requests.test_lenght)) / Requests.test_lenght, 48);
                Bitmap image = new Bitmap(1528 / (Requests.test_lenght + 6), 48);
                Graphics g = Graphics.FromImage(image);
                g.FillRectangle(mybrush, 0, 0, Size.Width / Requests.test_lenght, 48);
                picBox[i] = new PictureBox();
                picBox[i].Name = i.ToString();
                //picBox[i].Width = (Size.Width - (26 * Requests.test_lenght)) / Requests.test_lenght;
                picBox[i].Width = 1528 / (Requests.test_lenght + 6);
                picBox[i].Height = 16;
                picBox[i].Location = new Point(pos_x, pos_y);
                pos_x += 1528 / Requests.test_lenght;
                picBox[i].Image = image;
                picBox[i].Visible = true;
                picBox[i].Click += (sender, e) => select_qst(sender, e, currentI);
                if (Requests.usr_answs[i] != 3)
                {
                    picBox[i].Enabled = false;
                }
                groupBox1.Controls.Add(picBox[i]);
            }
        }

        public void select_qst(object sender, EventArgs e, int i)
        {
            actual_question = i;
            Requests.usr_answs[i] = 3;
            privet_mir(i);
            do_this(i);
        }
        public void do_this(int x)
        {
            listBox1.Items.Clear();
            string[] qs = Requests.qst.Split(';');
            string[] an = Requests.ans.Split('¯');
            foreach (string item in an[x].Split(';'))
            {
                listBox1.Items.Add(item);
            }
            label2.Text = qs[x];
            var qwa = 0;
            for (int i = 0; i < Requests.test_lenght; i++)
            {
                if (Requests.usr_answs[i] == 3)
                {
                    qwa++;
                }
            }
            if (Requests.test_lenght - qwa + 1 < Requests.test_lenght)
            {
                label1.Text = "Вопрос " + (Requests.test_lenght - qwa + 1) + " из " + Requests.test_lenght;
            }
            else
            {
                label1.Text = "Вопрос " + (Requests.test_lenght) + " из " + Requests.test_lenght;
            }
        }
        public void time_progress_bar(double x)
        {
            float perfect_value = Convert.ToSingle(220 * x);
            SolidBrush mybrush = new SolidBrush(Color.DodgerBlue);
            Bitmap temp_image = new Bitmap(220, 20);
            Graphics temp_g = Graphics.FromImage(temp_image);
            temp_g.FillRectangle(mybrush, 0, 0, perfect_value, 20);
            pictureBox1.Image = temp_image;
        }
        private void Test_Load(object sender, EventArgs e)
        {
            var perfect_value = (double) Requests.test_timer / timer_full;
            Text = "Группа " + auth.group + ": " + auth.user + ", " + GetTest.selected_test;
            label5.Text = "Группа " + auth.group + ": " + auth.user + ", " + GetTest.selected_test;
            button2.Enabled = true;
            label3.ForeColor = Color.Green;
            label3.Text = "Осталось: " + Requests.test_timer.ToString() + " минут";
            int qwa = 0;
            for (int i = 0; i < Requests.test_lenght; i++)
            {
                if (Requests.usr_answs[i] == 3)
                {
                    qwa++;
                }
            }
            for (int i = 0; i < Requests.test_lenght; i++)
            {
                if (qwa != 0)
                {
                    if (Requests.usr_answs[i] == 3)
                    {
                        actual_question = i;
                        break;
                    }
                    actual_question = i;
                }
            }
            do_this(actual_question);
            privet_mir(actual_question);
            time_progress_bar(perfect_value);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            selected_answ = "-1";
            try
            {
                selected_answ = listBox1.SelectedIndex.ToString();
            }
            catch
            {

            }
            if (selected_answ != "-1")
            {
                int qwa = 0; //переменная, считающая сколько вопросов без ответа
                string good = Requests.POST("http://127.0.0.1:8080/", "send_answ", Requests.token+ "," + (actual_question+1).ToString() + "," + selected_answ); //отправка ответа на сервер
                if (good == "0")
                {
                    Requests.usr_answs[actual_question] = 0;
                }
                if (good == "1")
                {
                    Requests.usr_answs[actual_question] = 1;
                }
                //подсчет кол-ва вопросов без ответа
                for (int i = 0; i < Requests.test_lenght; i++)
                {
                    if (Requests.usr_answs[i] == 3)
                    {
                        qwa++;
                    }
                }
                //если есть вопросы без ответа, то после нажатия кнопки "Ответить" будет следующий вопрос
                for (int i = 0; i < Requests.test_lenght; i++)
                {
                    if (qwa != 0)
                    {
                        if (Requests.usr_answs[i] == 3)
                        {
                            butt_counter++;
                            actual_question = i;
                            break;
                        }
                        actual_question = i;
                    }
                }
                do_this(actual_question); // показ вопроса, согласно правилам выше
                privet_mir(actual_question); // отрисовка панели навигации вопросов, согласно правилам выше
                //деактивация кнопки "Ответить" после ответа на все вопросы.
                if (qwa == 0)
                {
                    button2.Enabled = false;
                }
            }
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            Requests.POST("http://127.0.0.1:8080/", "end_test", Requests.token);
            timer1.Enabled = false;
            GetResult GetResultForm = new GetResult();
            Hide();
            GetResultForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer_full - (timer_full - Requests.test_timer) < timer_full - (timer_full / 3))
            {
                label3.ForeColor = Color.Gold;
            }
            if (timer_full - (timer_full - Requests.test_timer) < timer_full - (timer_full / 2))
            {
                label3.ForeColor = Color.Orange;
            }
            if (Requests.test_timer < 10)
            {
                label3.ForeColor = Color.Red;
            }
            if (Requests.test_timer <= 1)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                listBox1.Enabled = false;
                button2.Enabled = false;
                timer1.Enabled = false;
            }
            Requests.POST("http://127.0.0.1:8080/", "test_timer", Requests.token);
            var perfect_value = (double) Requests.test_timer / timer_full;
            time_progress_bar(perfect_value);
            label3.Text = "Осталось: " + Requests.test_timer.ToString() + " минут";
        }

        private void Test_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void Test_MouseMove(object sender, MouseEventArgs e)
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
