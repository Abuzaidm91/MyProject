using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inks
{
    public partial class Form1 : Form
    {
        string Exit;
        public Form1()
        {
            Exit = "No";
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        public void Show (string Text)
        {

            this.label1.Text = Text;
            this.Width = pictureBox1.Width + label1.Width + 30;
            this.Show(); 

        }
        private void Timer1_Tick(object sender, EventArgs e)
        { 
            if (Exit == "Ok")
            {
                timer1.Stop();
                timer1.Dispose();
                timer1.Interval = 1;
                timer1.Start();

                if (this.Opacity > 0)
                {
                    this.Opacity -= 0.01;
                }
                else
                {
                    this.Close();
                }
            }




            if (Exit == "No")
            {
                if (this.Opacity < 0.9)
                {
                    this.Opacity += 0.01;
                }
                else
                {
                    //  System.Threading.Thread.Sleep(2500);
                    timer1.Stop(); 
                    timer1.Dispose();
                    timer1.Interval = 2500;                
                    timer1.Start();
                    Exit = "Ok";                  
                }

            }


           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
            // this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            var _point = new Point(Cursor.Position.X, Cursor.Position.Y);
             this.Top = _point.Y;
             this.Left = _point.X;
             timer1.Start();
           
          




        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }

        }


    }
}
