using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_üzerindeki_nesneyi_hareket_ettirmek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:     label1.Left -= 5;  break;
                case Keys.Right:    label1.Left += 5; break;
                case Keys.Up:       label1.Top  -= 5; break;
                case Keys.Down:     label1.Top  += 5; break;
                default:    break;
            }
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int yk = e.X - label1.Width / 2;
            if (sender is Label)
                yk = label1.Left+(e.X - label1.Width / 2);

            if(yk>=0 && yk<this.Width-label1.Width)
                    label1.Left = yk;

        }
        string yön = "sağüst";
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (yön)
            {
                case "sağalt": kare.Top += 8; kare.Left += 8; break;
                case "sağüst": kare.Top -= 8; kare.Left += 8; break;
                case "solalt": kare.Top += 8; kare.Left -= 8; break;
                case "solüst": kare.Top -= 8; kare.Left -= 8; break;
            }
            int altcizgi = kare.Top + kare.Height;
            int üstcizgi = kare.Top;
            int solcizgi = kare.Left;
            int sağcizgi = kare.Left + kare.Width;
            
            if (üstcizgi <= 0 && yön == "sağüst") yön = "sağalt";
            else if (üstcizgi <= 0 && yön == "solüst") yön = "solalt";
            else if (solcizgi <= 0 && yön == "solalt") yön = "sağalt";
            else if (solcizgi <= 0 && yön == "solüst") yön = "sağüst";
            else if (sağcizgi >= this.Width && yön == "sağüst") yön = "solüst";
            else if (sağcizgi >= this.Width && yön == "sağalt") yön = "solalt";

            if (altcizgi >= label1.Top)
                if (solcizgi+kare.Width > label1.Left && sağcizgi-kare.Width-1 < label1.Left + label1.Width)
                {
                    if (yön == "solalt") yön = "solüst";
                    else if (yön == "sağalt") yön = "sağüst";
                }
                else if (altcizgi >= label1.Top + label1.Height +1)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Kaybettiniz!");
                    yön = "sağalt";
                    kare.Top = 20;
                    kare.Left = 20;
                    timer1.Enabled = true;
                }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            label1.Top = this.Height - label1.Height - 50;
            label1.Width = this.Width/2;
        }
    }
}
