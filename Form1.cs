using System;
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
        

        Dictionary<Car, Label> cars = new Dictionary<Car, Label>();

        Random rnd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            rnd = rnd = new Random();
            gener.Tick += new EventHandler(GenEvent);
            gener.Interval = 2000;
            gener.Start();

            ticker.Tick += new EventHandler(TickerEvent);
            ticker.Interval = 5;
            ticker.Start();

        }

        private void GenEvent(object sender, EventArgs e)
        {

            Label mylab = new Label();
            mylab.Text = "100";
            mylab.Location = new Point(200, 300);
            mylab.AutoSize = true;
            mylab.Font = new Font("Calibri", 18);
            mylab.ForeColor = Color.Green;
            mylab.Padding = new Padding(6);

            Car car = new Car(200, 300, rnd);
            mylab.BackColor = Color.FromArgb(car.GetColor()[0], car.GetColor()[1], car.GetColor()[2]);
            cars.Add(car, mylab);

            // Adding this control to the form
            this.Controls.Add(mylab);
        }

        private void TickerEvent(object sender, EventArgs e) {

            foreach (Car car in cars.Keys) {
                cars[car].Location = new Point(car.GetPosition()[0] + 1, car.GetPosition()[1] + 1);
                car.Update();
            }
        }


    }
}
