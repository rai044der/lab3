using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{

    //координаты тупого блять говна (заправок)
    // 1: 1031, 194
    // 2: 1031, 341
    // 3: 1031, 500
    // 4: 1031, 654
    // 5: 1031, 800
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
            cars = new Queue<Car>();   
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

        // заливаем топливо в машину СДЕЛАТЬ НОРМАЛЬНО
        public void addFuel() {
            if (cars.Count == 0) return;
            Car car = cars.First();
            int addedFuel = increment <= 500 - car.GetFuelLevel() ? increment: 500 - car.GetFuelLevel();
            if (car.isReadyToFuel())
            {
                car.AddFuel(addedFuel);
                score += addedFuel;
            }
            if (car.GetFuelLevel() == 500)
            {
                cars.Dequeue();
                foreach (Car currentCar in cars) { 
                    currentCar.Update();
                }    
            }
        }

        // сколько литров надо залить машинам в очереди
        public int getInfo() {
            int result = 0;
            foreach (Car car in cars) {
                result += 500 - car.GetFuelLevel();
            }
            return result;
        }

        public int getCarNumber(Car currentCar) {
            return cars.ToList<Car>().IndexOf(currentCar); 
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

        public int GetPosition()
        {
            return position;
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
            other = other.OrderBy(element => element.numberOfCars()).ToList<Station>();
            
            if (other.Count() > 0)
            {
                return other[0];
            }
            else {
                return null;
            }
        }

        public void Update()
        {
            foreach(Station station in stations)
            {
                station.update();
            }
        }

        public int getGasSold() {
            return stations.Sum(elem => elem.getStatistic());
        }

        
    }

}
