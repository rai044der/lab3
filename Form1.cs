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
        //static System.Windows.Forms.Timer ticker = new System.Windows.Forms.Timer();
        //static System.Windows.Forms.Timer gener = new System.Windows.Forms.Timer();
        
        // создаём словарь, где Сar - логически объект,
        // а Label - его отображение на экране

        //Dictionary<Car, Label> cars = new Dictionary<Car, Label>();

        //Random rnd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rnd = new Random();
            /*
            // создаём новую модель машины
            Label label = new Label();

            // уровень топлива конкретной машинки
            label.Text = "100";
            // размеры машинки
            label.Size = new System.Drawing.Size(40, 20);
            // позиция, где машинка появляется
            label.Location = new System.Drawing.Point(200, 300);
            // каждая машинка имеет собственное имя гененрируемое
            // на основе длины словаря
            label.Name = String.Concat("car", cars.Keys.Count.ToString());
            // Car car = new Car(200, 300, rnd);
            // cars.Add(car);
            this.Controls.Add(label);
            */

            //ticker.Tick += new EventHandler(TickerEvent);
            //ticker.Interval = 5;
            //ticker.Start();

            //gener.Tick += new EventHandler(GenEvent);
            //gener.Interval = 1000;
            //gener.Start();


            // Creating and setting the label
            int n = 4;
            TextBox[] textBoxes = new TextBox[n];
            Label[] labels = new Label[n];

            for (int i = 0; i < n; i++)
            {
                textBoxes[i] = new TextBox();
                // Here you can modify the value of the textbox which is at textBoxes[i]

                labels[i] = new Label();
                // Here you can modify the value of the label which is at labels[i]
                labels[i].Visible = true;
                labels[i].Text = i.ToString();
                labels[i].BackColor = Color.Black;
                labels[i].Location = new Point(200, 300);
            }

            // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
            for (int i = 0; i < n; i++)
            {
                this.Controls.Add(textBoxes[i]);
                this.Controls.Add(labels[i]);
            }
        }



        private void TickerEvent(Object myObject, EventArgs myEventArgs)
        {
            paint();
        }

        private void GenEvent(Object myObject, EventArgs myEventArgs)
        {
            //Car car = new Car(200, 300, rnd);
            //cars.Add(car);


        }

        private void paint()
        {
        
        }

    }
}
