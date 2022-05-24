using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // класс машинки
    public class Car
    {
        private int fuelLevel; // уровень топлива
        private int[] color = new int[3]; // цвет 
        public int[] position = new int[2]; // позиция
        private int[] targetPosition = new int[2]; // целевая позиция
        private bool isGettingFuel; // флаг заправки
        private bool onPosition; // флаг достижения позиции
        private Station station; // заправочная станция
        private bool isRotated = false; // повернута ли машинка?
        private bool isAlreadyFull = false; // флаг полного бака
        private int step = 0; // шаг заправки

        public Car(int targetX, int targetY, Random rnd, GasStation gasStation)
        {
            color[0] = rnd.Next(255);
            color[1] = rnd.Next(255);
            color[2] = rnd.Next(255);
            fuelLevel = rnd.Next(5, 500);
            position[0] = 0; //TODO FIX POSITION TO CORRECT
            position[1] = 50;
            if (fuelLevel >= 400)
            {
                targetPosition[0] = 1280;
                targetPosition[1] = 50;
                isAlreadyFull = true;
            }
            else
            {
                station = gasStation.GetStation();
                if (station == null)
                {
                    isAlreadyFull = true;
                    targetPosition[0] = 1280;
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

        //обновление целевой позиции машинки
        bool UpdatePosition()
        {
            if (!onPosition) return false;
            else
            {
                if(isAlreadyFull)
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
                else if (step == 1)
                {
                    isRotated = !isRotated;
                    targetPosition[0] = 1040 - station.getCarNumber(this) * 70;
                    step++;
                    onPosition = false;
                }

                else if (step == 2 && this.GetPosition()[0] != 1040) { 
                    targetPosition[0] = 1040 - station.getCarNumber(this) * 70;
                }

                else if (step == 2)
                {
                    isGettingFuel = true;
                    step++;
                }

                else if (step == 3 && isGettingFuel == false)
                {
                    targetPosition[0] = 1180;
                    step++;
                    onPosition = false;
                }

                else if (step == 4)
                {
                    isRotated = !isRotated;
                    targetPosition[1] = 50;
                    step++;
                    onPosition = false;

                }

                else if (step == 5)
                {
                    isRotated = !isRotated;
                    targetPosition[0] = 1280;
                    step++;
                    onPosition = false;

                }

                return false;
            }
        }
        
        // получение флага повернутости машинки
        public bool GetRotation()
        {
            return isRotated;
        }

        // функция движения машинки
        void Move()
        {
            if (position[0] == targetPosition[0] && position[1] == targetPosition[1])
            {
                onPosition = true;
                return;
            }
            if (position[0] > targetPosition[0]){
                position[0]--;
                return;
            }
            else if (position[0] < targetPosition[0]){
                position[0]++;
                return;
            }
            if (position[1] > targetPosition[1]) {
                position[1]--;
                return;
            }
            else if (position[1] < targetPosition[1]){
                position[1]++;
                return;
            }            
        }
        
        // тактирование
        public bool Update()
        {
            bool isDel = UpdatePosition();
            Move();
            return isDel;
        }
        
        // получение позиции машинки 
        public int[] GetPosition()
        {
            return position;
        }

        // получение цвета
        public int[] GetColor()
        {
            return color;
        }

        // заправка машинки
        public bool AddFuel(int fuel)
        {
            fuelLevel += fuel;
            if(fuelLevel == 500)
            {
                isGettingFuel = false;
                return true;
            }
            return false;
        }

        // нужно ли заправиться?
        public bool isReadyToFuel()
        {
            return isGettingFuel;
        }

        // получение уровня топлива
        public int GetFuelLevel()
        {
            return fuelLevel;
        }


    }
}
