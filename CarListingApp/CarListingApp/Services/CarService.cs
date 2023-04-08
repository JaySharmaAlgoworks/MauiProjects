using System;
using CarListingApp.Models;
using SQLite;

namespace CarListingApp.Services
{
    public class CarService
    {
        /* public List<Car> GetCars()
         {
             return new List<Car>()
             {
                 new Car
                 {
                     Id=1,Make="Honda",Model="Fit",Vin="123"
                 },
                 new Car
                 {
                     Id=2,Make="Toyota",Model="Prade",Vin="123"
                 },
                  new Car
                 {
                     Id=3,Make="Honda",Model="Civic",Vin="123"
                 },
                 new Car
                 {
                     Id=4,Make="Audi",Model="AS",Vin="123"
                 },
                  new Car
                 {
                     Id=5,Make="BMw",Model="M1",Vin="123"
                 },
                   new Car
                 {
                     Id=6,Make="Nissan",Model="Note",Vin="123"
                 },
                    new Car
                 {
                     Id=7,Make="Ferrari",Model="Spider",Vin="123"
                 },
             };



         }*/

        SQLiteConnection conn;
        string _dbPath;
        int result=0;
        public string StatusMessage;

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
            {
                return;
            }
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Car>();
        }
       
        public List<Car> GetCars()
        {
            try
            {
                Init();
                return conn.Table<Car>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = "Falied to retrieve data.";
            }
            return new List<Car>();
        }

        public void AddCar(Car car)
        {
            try
            {
                Init();
                if (car == null)
                    throw new Exception("Invalid Car Record");
                result = conn.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Success";

            }
            catch(Exception ex)
            {
                StatusMessage = "Failed to Insert data.";
            }
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().Delete(q => q.Id == id);

            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to delete data.";
            }
            return 0;
        }

        public Car GetCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().FirstOrDefault(q=>q.Id==id);
            }
            catch (Exception)
            {
                StatusMessage = "Falied to retrieve data.";
            }
            return null;
        }

        public int UpdateCar(Car car)
        {
            try
            {
                Init();
                if (car == null)
                    throw new Exception("Invalid Car Record");

                result = conn.Update(car);

                StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
                

            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to update data.";
            }
            return 0;
        }
    }
}

