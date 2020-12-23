using DishesTask.Filter;
using DishesTask.Models;
using DishesTask.Repositories;
using MongoDB.Driver;
using System;
using System.Diagnostics;

namespace DishesTask.Workers
{
    public class UpdateDishesWorker
    {
        /// <summary>
        /// Setzt das im Filter per ID übergegebene Produkt auf aktiv oder inaktiv
        /// </summary>
        /// <param name="filter">der Filter.</param>
        /// <returns>true wenn das Update erfolgreich war, false wenn nicht.</returns>
        public bool DoWork(PutFilter filter)
        {
            try
            {
                var col = new InternalDishesRepository().FindAll();
                var item = col.Find(x => x.Id == filter.Id).FirstOrDefault();
                if (item == null)
                {
                    Trace.WriteLine($"No Product found with Id: {filter.Id}.");
                    return false;
                }

                var updFilter = Builders<Dishes>.Filter.Eq("_id", filter.Id);
                var update = Builders<Dishes>.Update.Set("active", filter.Active);
                var res = col.UpdateOne(updFilter, update);
                return res.IsAcknowledged;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Log {e} here.");
            }
            return false;
        }
    }
}