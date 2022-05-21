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
        public bool isBusy() {
            return cars.Count == queueSize;
        }

        // сбор сколько литров разлила колонка
        public int getStatistic()
        {
            return score;
        }
        // добавляем машину в очередь
        public void AddCar(Car newCar) { 
            if (!this.isBusy()) cars.Enqueue(newCar);
        }

        // заливаем топливо в машину
        public void addFuel() {
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
        public int getInfo() {
            int result = 0;
            foreach (Car car in cars) {
                result += 100 - car.GetFuelLevel();
            }
            return result;
        }

        public void update() {
            addFuel();
        }

        public int getId() { 
            return id;
        }

        public int numberOfCars() {
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
            List<Station> other =  stations.Where((element) => !element.isBusy()).ToList<Station>();
            other.OrderBy(element => element.getInfo());
            if (other.Count() > 0)
            {
                return other[0];
            }
            else {
                return null;
            }
        }

        public int getGasSold() {
            return stations.Sum(elem => elem.getStatistic());
        }

        
    }

}
