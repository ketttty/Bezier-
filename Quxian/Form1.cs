using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quxian
{

    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Fuchsia, 4);
        Pen penp = new Pen(Color.Lime, 4);         
        int clickCount = 0;   
        Point[] points = new Point[4];  
        bool ispoints1 = false;  
        bool ispoints2 = false;
        bool ispoints3 = false;   
        bool ispoints4 = false;
        bool lineVisible = false;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
    

         private void draw(Graphics g)
        {
            Pen pen1 = new Pen(pictureBox3.BackColor, 3);
            g.DrawBezier(pen1, points[0], points[1], points[2], points[3]);
            g.DrawLine(pen, points[0], points[1]);
            g.DrawLine(pen, points[2], points[1]);
            g.DrawLine(pen, points[2], points[3]);
            g.DrawEllipse(penp, points[0].X, points[0].Y, 4, 4);
            g.DrawEllipse(penp, points[1].X, points[1].Y, 4, 4);
            g.DrawEllipse(penp, points[2].X, points[2].Y, 4, 4);
            g.DrawEllipse(penp, points[3].X, points[3].Y, 4, 4);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen1 = new Pen(pictureBox3.BackColor, 3);
            if (ispoints1)     
            { 
                points[0] = e.Location;      
                g.DrawEllipse(penp, e.X, e.Y, 4, 4);              
                draw(g); 
            }
            else if (ispoints2)  
            {      
            points[1] = e.Location;
            g.DrawEllipse(penp, e.X, e.Y, 2, 2);
            draw(g);
             }    
            else  if (ispoints3) 
            {
            points[2] = e.Location;
            g.DrawEllipse(penp, e.X, e.Y, 2, 2);
            draw(g);
             }
             else if (ispoints4)
            {
            points[3] = e.Location;
            g.DrawEllipse(penp, e.X, e.Y, 2, 2);
            draw(g);
             }
            else    
            {

                switch (clickCount)
                {
                    case 0: 
                        points[0] = new Point(e.X, e.Y);                        
                        g.DrawEllipse(penp, e.X, e.Y, 4, 4);           
                        clickCount++;
                        break;
                    case 1:
                        points[1] = new Point(e.X, e.Y); 
                        g.DrawLine(pen, points[0], points[1]);
                        g.DrawEllipse(penp, e.X, e.Y, 4, 4);                  
                        clickCount++;
                        break;
                    case 2:
                        points[2] = new Point(e.X, e.Y);
                        g.DrawLine(pen, points[1], points[2]);
                        g.DrawEllipse(penp, e.X, e.Y, 4, 4);
                        
                        clickCount++;
                        break;
                    case 3:
                        points[3] = new Point(e.X, e.Y);
                        g.DrawLine(pen, points[2], points[3]);
                        g.DrawEllipse(penp, e.X, e.Y, 4, 4);
                        clickCount=0;
                        break;
                }
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ispoints1 = false;
            ispoints2 = false;
            ispoints4 = false;
            ispoints3 = true;
       

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
       

        }

        private void button1_Click(object sender, EventArgs e)
        {  
            
            ispoints1 = true;
            ispoints2 = false;
            ispoints3 = false;
            ispoints4 = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ispoints1 = false;
            ispoints2 = false;
            ispoints4 = false;
            ispoints3 = false;
            g.Clear(Color.LemonChiffon ); 
            Array.Clear(points, 0, points.Length);
         
        }

        private void button5_Click(object sender, EventArgs e)
        {       
                draw(g);        
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        
            pictureBox3.BackColor = Color.Blue;
            draw(g);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ispoints1 = false;
            ispoints3 = false;
            ispoints4 = false; 
            ispoints2 = true;
   

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ispoints1 = false;
            ispoints2 = false;
            ispoints3 = false;
            ispoints4 = true;
         

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
             pictureBox3.BackColor = Color.Red;
            draw(g);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Lime;
            draw(g);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
     
         
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.LemonChiffon);
            Pen pen1 = new Pen(pictureBox3.BackColor, 3);
          
            if (lineVisible)
            {
            draw(g);
            }
            else
            {
            g.DrawBezier(pen1, points[0], points[1], points[2], points[3]);
            }
            // 切换线的状态
            lineVisible = !lineVisible;

        }
    }
}
