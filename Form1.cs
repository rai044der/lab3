﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer ticker = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer gener = new System.Windows.Forms.Timer();
        List<Car> cars = new List<Car>();
        Random rnd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            Car car = new Car(200, 300, rnd);
            cars.Add(car);

            ticker.Tick += new EventHandler(TickerEvent);
            ticker.Interval = 5;
            ticker.Start();

            gener.Tick += new EventHandler(GenEvent);
            gener.Interval = 1000;
            gener.Start();
        }



        private void TickerEvent(Object myObject, EventArgs myEventArgs)
        {
            paint();
        }

        private void GenEvent(Object myObject, EventArgs myEventArgs)
        {
            Car car = new Car(200, 300, rnd);
            cars.Add(car);
        }

        private void paint()
        {
            Graphics g = canvas.CreateGraphics();
            g.Clear(Color.White);
            foreach (Car car in cars)
            {
                Brush c = new SolidBrush(Color.FromArgb(car.GetColor()[0], car.GetColor()[1], car.GetColor()[2]));
                g.FillRectangle(c, car.GetPosition()[0], car.GetPosition()[1], 40, 20);

                car.Update();
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            paint();
        }
    }
}
