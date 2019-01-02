/*
Создать класс Point (точка). На его основе создать классы ColoredPoint и Line (линия). На основе класса Line создать классы ColoredLine и PolyLine (многоугольник).
В классах описать следующие элементы:
• конструкторы с параметрами и конструкторы по умолчанию;
• свойства для установки и получения значений всех координат, а также для изменения цвета и получения текущего цвета;
• для линий – методы изменения угла поворота линий относительно первой точки;
• для многоугольника – метод масштабирования
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab9L
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gr = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));
            Point p1 = new Point(3, 3);
            p1.Draw(600, 500);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));      
            Line Line = new Line(600, 500, 700, 500);
            Line.Draw();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));
            ColoredPoint colPoint = new ColoredPoint(3, 3, 58, 226, 206);
            colPoint.Draw(600, 500);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));
            ColoredLine colLine = new ColoredLine(600, 500, 700, 500, 58, 226, 206);
            colLine.Draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));
            Polygon plg = new Polygon(200,150);
            plg.Draw(400, 500);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));
            Polygon plg = new Polygon();
            plg.Width -= 8;
            plg.Heigh -= 5;
            plg.Draw(400, 500);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.FromArgb(240, 240, 240));
            Polygon plg = new Polygon();
            plg.Width += 8;
            plg.Heigh += 5;
            plg.Draw(400, 500);
        }

        private void button6_Click(object sender, EventArgs e)
        {
          gr.Clear(Color.FromArgb(240, 240, 240));
          Line line = new Line();

         if (Line._StartX == 600)
            {
                line.StartX = 650;
                line.StartY = 450;

                line.EndX = 650;
                line.EndY = 550;

                line.Draw();
            }
            else
            {
                line.StartX = 600;
                line.StartY = 500;

                line.EndX = 700;
                line.EndY = 500;

                line.Draw();
            }
        }
    }
}
