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

        List<int> idList;
        List<int> posList;
        GasStation gasStation;
        Dictionary<Car, Label> cars = new Dictionary<Car, Label>();
        int generatorTick = 100;
        int currentGeneratorTick = 0;

        Random rnd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)

        {
            idList = new List<int>();
            for (int i = 0; i < 5; i++) idList.Add(i);
            posList = new List<int>(5);
            posList.Add(190);
            posList.Add(335);
            posList.Add(495);
            posList.Add(650);
            posList.Add(790);
            gasStation = new GasStation(5, 1, idList, posList, 14);

            rnd = new Random();

            ticker.Tick += new EventHandler(TickerEvent);
            ticker.Interval = 1;
            ticker.Start();

            carGeneratorTrackBar.Value = generatorTick;

        }

        private void CarGenerator()
        {
            Car car = new Car(70, 50, rnd, gasStation);
            Label mylab = new Label
            {
                Text = car.GetFuelLevel().ToString(),
                Location = new Point(2000, 2000),
                AutoSize = false,
                Size = new Size(60, 40),
                Font = new Font("Calibri", 12),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(255 - car.GetColor()[0],
                                             255 - car.GetColor()[1],
                                             255 - car.GetColor()[2]),
                Padding = new Padding(3),
                BackColor = Color.FromArgb(car.GetColor()[0], car.GetColor()[1], car.GetColor()[2])
            };
            cars.Add(car, mylab);
            // Adding this control to the form
            this.Controls.Add(mylab);
            if (randomCarGeneratorCheckBox.Checked)
            {
                generatorTick = rnd.Next(carGeneratorTrackBar.Minimum, carGeneratorTrackBar.Maximum);
                carGeneratorTrackBar.Value = generatorTick;
            }
        }

        private void TickerEvent(object sender, EventArgs e) {
            if (currentGeneratorTick > generatorTick)
            {
                CarGenerator();
                currentGeneratorTick = 0;
            }
            else currentGeneratorTick++;
            Car carToDel = null;
            foreach (Car car in cars.Keys) {
                cars[car].Location = new Point(car.GetPosition()[0], car.GetPosition()[1]);
                cars[car].Size = car.GetRotation() ? new Size(40, 60) : new Size(60, 40);
                cars[car].Text = car.GetFuelLevel().ToString();
                bool isDel = car.Update();
                if (isDel)
                {
                    this.Controls.Remove(cars[car]);
                    carToDel = car;
                }
            }
            if(carToDel != null) cars.Remove(carToDel);
            gasStation.Update();
            ticksRemainingLabel.Text = (generatorTick - currentGeneratorTick).ToString();

        }

        private void statBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Всего продано " + gasStation.getGasSold().ToString() + " литра.\n" + "Обслужено " + gasStation.getCarsFueled().ToString() + " машин.");
        }

        private void tickTrackBar_Scroll(object sender, EventArgs e)
        {
            ticker.Interval = tickTrackBar.Value;
        }

        private void carGeneratorTrackBar_Scroll(object sender, EventArgs e)
        {
            generatorTick = carGeneratorTrackBar.Value;
        }

        private void randomCarGeneratorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (randomCarGeneratorCheckBox.Checked)
            {
                carGeneratorTrackBar.Enabled = false;
            }
            else
            {
                carGeneratorTrackBar.Enabled = true;
            }
        }

        private void fuelSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            gasStation.updateFuelRate(fuelSpeedTrackBar.Value);
        }
    }
}
