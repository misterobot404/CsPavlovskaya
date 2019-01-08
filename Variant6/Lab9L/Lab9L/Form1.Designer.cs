using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9L
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        static public Graphics gr;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(512, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Точка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(481, 110);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Линия";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(446, 223);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(306, 93);
            this.button3.TabIndex = 2;
            this.button3.Text = "Прямоугольник";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(365, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Уменьшить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(758, 258);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Увеличить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(727, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(212, 36);
            this.button6.TabIndex = 5;
            this.button6.Text = "Повернуть";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(496, 59);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(203, 45);
            this.button8.TabIndex = 7;
            this.button8.Text = "Цветная точка";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(464, 166);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(259, 51);
            this.button9.TabIndex = 8;
            this.button9.Text = "Цветная линия";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 752);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private Button button8;
        private Button button9;
    }

    class Point
    {
        public Point() //конструктор по умолчанию
        {
        }
        public Point(int x, int y) //конструктор
        {
            this.X = x;
            this.Y = y;
        }
        virtual public void Draw(int widthSize, int heighSize)
        {
            Form1.gr.FillRectangle(new SolidBrush(Color.Black), new Rectangle(widthSize, heighSize, X, Y));
        }
      
        private int _X;
        public int X
        {
            get //способ пролучения свойства
            {
                return this._X;
            }
            set //способ задания свойства
            {
                _X = value;
            }
        }

        private int _Y;
        public int Y
        {
            get
            {
                return this._Y;
            }
            set
            {
                _Y = value;
            }
        }
    }

    class ColoredPoint : Point
    {
        public ColoredPoint()
        { }

        public ColoredPoint(int x, int y, int R, int G, int B)
            : base(x, y)
        {
            this.Color = Color.FromArgb(R, G, B);
        }

        public override void Draw(int widthSize, int heighSize)
        {
            Form1.gr.FillRectangle(new SolidBrush(Color), new Rectangle(widthSize, heighSize, X, Y));
        }

        private Color _Color;
        public Color Color
        {
            get
            {
                return this._Color;
            }
            set
            {
                _Color = value;
            }
        }
    }

    class Line
    {
        public Line()
        {
        }

        public Line(int StartX, int StartY, int EndX, int EndY)
        {
            this.StartX = StartX;
            this.StartY = StartY;
            this.EndX = EndX;
            this.EndY= EndY;
        }

        public virtual void Draw()
        {
            Pen p = new Pen(Color.Black, 3);// цвет линии и ширина
            PointF p1 = new PointF(StartX, StartY);// первая точка
            PointF p2 = new PointF(EndX, EndY);// вторая точка
            Form1.gr.DrawLine(p, p1, p2);
        }

        public static int _StartX = 600;
        public int StartX
        {
            get { return _StartX; }
            set { _StartX = value; }
        }

        static private int _StartY = 500;
        public int StartY
        {
            get { return _StartY; }
            set { _StartY = value; }
        }

        static private int _EndX = 700;
        public int EndX
        {
            get { return _EndX; }
            set { _EndX = value; }
        }

        static private int _EndY = 500;
        public int EndY
        {
            get { return _EndY; }
            set { _EndY = value; }
        }
    }

    class ColoredLine : Line
    {
        public ColoredLine(int StartX, int StartY, int EndX, int EndY, int R, int G, int B)
            : base(StartX, StartY, EndX, EndY)
        {
            this.Color = Color.FromArgb(R, G, B);
        }

        public override void Draw()
        {
            Pen p = new Pen(Color, 3);// цвет линии и ширина
            PointF p1 = new PointF(StartX, StartY);// первая точка
            PointF p2 = new PointF(EndX, EndY);// вторая точка
            Form1.gr.DrawLine(p, p1, p2);
        }

        private Color _Color;
        public Color Color
        {
            get
            {
                return this._Color;
            }
            set
            {
                _Color = value;
            }
        }
    }

    class Polygon
    {
        public Polygon()
        { }

        public Polygon(int width, int heigh)
        {
            this.Width = width;
            this.Heigh = heigh;
        }

        static private int _Width = 200;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }      
        }

        static private int _Heigh = 120;
        public int Heigh
        {
            get { return _Heigh; }
            set { _Heigh = value; }
        }

        public void Draw(int x, int y)
        {
            Color color = Color.Black;
            Rectangle rectangle = new Rectangle(x, y, Width, Heigh);
            Form1.gr.DrawRectangle(new Pen(color), rectangle);
        }
    }
}

