﻿using System;
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
            catch (Exception)
            {
                StatusMessage = "Falied to retrieve data.";
            }
            return new List<Car>();
        }
    }
}

