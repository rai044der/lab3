using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    enum states {MOVING, FUELING, WAITING};
    public class Car
    {
        private int fuelLevel;
        private int[] color = new int[3];
        public int[] position = new int[2];
        private int[] targetPosition = new int[2];
        private int gasStaton;
        private int state;
        private bool isGettingFuel;
        private bool onPosition;
        private Station station;
        private bool isRotated = false;
        private bool isAlreadyFull = false;
        private int step = 0;

        public Car(int targetX, int targetY, Random rnd, GasStation gasStation)
        {
            color[0] = rnd.Next(255);
            color[1] = rnd.Next(255);
            color[2] = rnd.Next(255);
            fuelLevel = rnd.Next(5, 100);
            position[0] = 0; //TODO FIX POSITION TO CORRECT
            position[1] = 50;
            if (fuelLevel > 75)
            {
                targetPosition[0] = 500;
                targetPosition[1] = 50;
                isAlreadyFull = true;
            }
            else
            {
                station = gasStation.GetStation();
                if (station == null)
                {
                    isAlreadyFull = true;
                    targetPosition[0] = 500;
                    targetPosition[1] = 50;
                }
                else
                {
                    station.AddCar(this);
                    targetPosition[0] = targetX;
                    targetPosition[1] = targetY;
                }
            }
        }

        //TODO
        bool UpdatePosition()
        {
            if (!onPosition) return false;
            else
            {
                if(isAlreadyFull || fuelLevel == 100)
                {
                    return true;
                }
                if (step == 0)
                {
                    isRotated = !isRotated;
                    targetPosition[1] = station.GetPosition();
                    step++;
                    onPosition = false;
                }
                else if(step == 1)
                {
                    isRotated = !isRotated;
                    targetPosition[0] = 1140 - station.numberOfCars() * 70;
                    step++;
                    onPosition = false;
                }
                else if (step == 2)
                {
                    isGettingFuel = true;
                    step++;
                }
                else if (step == 3 && isGettingFuel == false)
                {

                }
                return false;
            }
        }

        public bool GetRotation()
        {
            return isRotated;
        }

        void Move()
        {
            if (position[0] == targetPosition[0] && position[1] == targetPosition[1])
            {
                onPosition = true;
                state = (int)states.WAITING;
                return;
            }
            if (position[0] > targetPosition[0]){
                state = (int)states.MOVING;
                position[0]--;
                return;
            }
            else if (position[0] < targetPosition[0]){
                state = (int)states.MOVING;
                position[0]++;
                return;
            }
            if (position[1] > targetPosition[1]) {
                state = (int)states.MOVING;
                position[1]--;
                return;
            }
            else if (position[1] < targetPosition[1]){
                state = (int)states.MOVING;
                position[1]++;
                return;
            }            
        }

        public bool Update()
        {
            bool isDel = UpdatePosition();
            Move();
            return isDel;
        }
        //TODO
        public void SetStation()
        {

        }

        public int[] GetPosition()
        {
            return position;
        }

        public int[] GetColor()
        {
            return color;
        }

        public bool AddFuel(int fuel)
        {
            fuelLevel += fuel;
            if(fuelLevel == 100)
            {
                isGettingFuel = false;
                return true;
            }
            return false;
        }

        public bool isReadyToFuel()
        {
            return isGettingFuel;
        }

        public int GetFuelLevel()
        {
            return fuelLevel;
        }


    }
}
