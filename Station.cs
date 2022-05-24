using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    // класс колонки
    public class Station
    {
        Queue<Car> cars; // очередь из машин
        int queueSize; // размер очереди
        int position; // координаты колонки
        int id; // номер колонки
        int score; // количество проданных литров
        int carsFueled; // количество заправленных машин
        int increment; // сколько заливается топлива за такт

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

        // сбор сколько литров разлила колонка и сколько машин было обслужено
        public int[] getStatistic()
        {
            int[] stats = new int[2];
            stats[0] = score;
            stats[1] = carsFueled;
            return stats;
        }
        // добавляем машину в очередь
        public void AddCar(Car newCar) { 
            if (!this.isBusy()) cars.Enqueue(newCar);
        }

        // заливаем топливо в машину
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
                carsFueled++;
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

        // получение номера машины в очереди
        public int getCarNumber(Car currentCar) {
            return cars.ToList<Car>().IndexOf(currentCar); 
        }

        // тактирование 
        public void update() {
            addFuel();
        }

        // получение номер колонки
        public int getId() { 
            return id;
        }

        // получение количества машин на колонке
        public int numberOfCars() {
            return cars.Count;
        }

        // получение координат колонки
        public int GetPosition()
        {
            return position;
        }

        // установка скорости заправки
        public void SetIncrement(int _increment)
        {
            increment = _increment;
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

        // тактирование
        public void Update()
        {
            foreach(Station station in stations)
            {
                station.update();
            }
        }

        // получение количества проданного бензина за время
        public int getGasSold() {
            return stations.Sum(elem => elem.getStatistic()[0]);
        }

        // получение количества заправленных машин за все время
        public int getCarsFueled()
        {
            return stations.Sum(elem => elem.getStatistic()[1]);
        }

        // обновление скорости заправки на всех колонках
        public void updateFuelRate(int increment)
        {
            foreach (Station station in stations)
            {
                station.SetIncrement(increment);
            }
        }
    }

}
