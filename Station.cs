using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{


    public class Station
    {
        Queue<Car> cars;
        int queueSize;
        int position;
        int id;
        int score;
        // сколько заливается топлива за такт
        int increment;

        public Station(int size, int position, int id, int increment) { 
            queueSize = size;
            this.position = position;
            this.id = id;
            this.increment = increment;
        }

        // проверка занята ли колонка
        public bool IsBusy() {
            return cars.Count == queueSize;
        }

        // сбор сколько литров разлила колонка
        public int GetStatistic()
        {
            return score;
        }
        // добавляем машину в очередь
        public void AddCar(Car newCar) { 
            if (!this.IsBusy()) cars.Enqueue(newCar);
        }

        // заливаем топливо в машину
        public void AddFuel() {
            Car car = cars.First();
            int addedFuel = increment <= 100 - car.GetFuelLevel() ? increment: 100 - car.GetFuelLevel();
            car.AddFuel(addedFuel);
            score += addedFuel;

            if (car.GetFuelLevel() == 100) { 
                //
                cars.Dequeue();
            }
        }

        // сколько литров надо залить машинам в очереди
        public int GetInfo() {
            int result = 0;
            foreach (Car car in cars) {
                result += 100 - car.GetFuelLevel();
            }
            return result;
        }

        public void Update() {
            AddFuel();
        }

        public int GetId() { 
            return id;
        }

        public int NumberOfCars() {
            return cars.Count;
        }


    }

    // материнская станция
    public class GasStation { 
        List<Station> stations = new List<Station>();

        public GasStation(int numberOfStations, int increment, List<int> id, List<int> positions, int sizeOfStation) {
            for (int i = 0; i < numberOfStations; i++){
                stations.Add(new Station(sizeOfStation, positions[i], id[i], increment));
            }
        }
        public Station GetStation() {
            List<Station> other =  stations.Where((element) => !element.IsBusy()).ToList<Station>();
            other.OrderBy(element => element.GetInfo());
            if (other.Count() > 0)
            {
                return other[0];
            }
            else {
                return null;
            }
        }

        public int GetGasSold() {
            return stations.Sum(elem => elem.GetStatistic());
        }

        
    }

}
