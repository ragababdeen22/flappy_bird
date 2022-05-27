using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy_bird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int gravity = 20;
        int speed = 15;
        Random random = new Random();
        int score = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox3.Top += gravity;
            pictureBox2.Left -= speed;
            pictureBox4.Left -= speed;
            label1.Text = $" your score is: {score}";
            if (pictureBox4.Left < 0)
            {
                pictureBox4.Left=random.Next(500, 600);
                score++;
            }
            if (pictureBox2.Left < 0)
            {
                pictureBox2.Left = random.Next(500, 600);
                score++;
            }
            if (pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds) || pictureBox3.Bounds.IntersectsWith(pictureBox4.Bounds)
                || pictureBox3.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                timer1.Stop();
                label1.Text=$"Game over ! : your score is {score}";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.Enabled == false)     
            {


                if (e.KeyCode == Keys.Enter)
                {
                    timer1.Start();
                    pictureBox4.Left = random.Next(500, 600);
                    pictureBox2.Left = random.Next(500, 600);
                    pictureBox3.Top = 50;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                gravity -= 15;      
            }
            if (pictureBox3.Top < 2)
            {
                pictureBox3.Top = 15;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }
    }
}
