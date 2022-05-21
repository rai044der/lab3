using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    enum states {MOVING, FUELING, WAITING = 2};
    public class Car
    {
        private int fuelLevel;
        private int[] color = new int[3];
        private int[] position = new int[2];
        private int[] targetPosition = new int[2];
        private int gasStaton;
        private int state;
        private bool isGettingFuel;
        private bool onPosition;

        public Car(int targetX, int targetY, Random rnd)
        {
            color[0] = rnd.Next(255);
            color[1] = rnd.Next(255);
            color[2] = rnd.Next(255);
            position[0] = 0; //TODO FIX POSITION TO CORRECT
            position[1] = 50;
            targetPosition[0] = targetX;
            targetPosition[1] = targetY;
        }

        //TODO
        void UpdatePosition()
        {
            if (!onPosition) return;
            else
            {

                onPosition = false;
            }
        }

        void Move()
        {
            if(position[0] > targetPosition[0]){
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

            if (position[0] == targetPosition[0] && position[1] == targetPosition[1])
            {
                onPosition = true;
                state = (int)states.WAITING;
            }
        }

        public void Update()
        {
            UpdatePosition();
            Move();
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

        public int GetFuelLevel()
        {
            return fuelLevel;
        }


    }
}
