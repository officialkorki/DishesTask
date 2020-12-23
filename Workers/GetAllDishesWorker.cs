using DishesTask.Enums;
using DishesTask.Filter;
using DishesTask.Models;
using DishesTask.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DishesTask.Workers
{
    public class GetAllDishesWorker
    {
        /// <summary>
        /// Ruft die Produkte aus der Datenbank anhand des Filters ab.
        /// </summary>
        /// <param name="filter">der Filter.</param>
        /// <returns>Alle, nur Aktive oder nur Inaktive Produkte.</returns>
        public IEnumerable<Dishes> DoWork(GetFilter filter)
        {
            try
            {
                var col = new InternalDishesRepository().FindAll();
                var res = col.Find(new BsonDocument()).ToList();
                switch (filter.Status)
                {
                    case Status.All:
                        return res;
                    case Status.Active:
                    {
                        var activeDishes = res.Where(x => x.Active);
                        return activeDishes;
                    }
                    case Status.Inactive:
                    {
                        var inactiveDishes = res.Where(x => x.Active == false);
                        return inactiveDishes;
                    }
                    default:
                        return res;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Log {e} here.");
            }
            return null;
        }
    }
}