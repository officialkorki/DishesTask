using DishesTask.Models;
using DishesTask.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DishesTask.Workers
{
    public class CreateDishesWorker
    {
        //Ich habe halb Stackoverflow mit Tipps durch, um an die LastInsertedId zu kommen,
        //wie man sehen kann hatte ich leider keinen Erfolg.

        /// <summary>
        /// Erstellt ein neues Gericht in der Datenbank sofern es mit der angegebenen ID noch nicht existiert.
        /// </summary>
        /// <param name="dishList">die Liste mit den Produkten die erstellt werden sollen.</param>
        /// <returns>true wenn das/die Produkt/e erstellt wurden, false wenn nicht erfolgreich.</returns>
        public bool DoWork(List<Dishes> dishList)
        {
            try
            {
                var col = new InternalDishesRepository().FindAll();

                foreach (var dish in dishList)
                {
                    var item = col.Find(x => x.Id == dish.Id).FirstOrDefault();
                    if (item == null)
                    {
                        col.InsertOne(dish);
                        Trace.WriteLine($"New Product created with Id: {dish.Id}");
                    }
                    else
                    {
                        Trace.WriteLine($"Product with Id: {dish.Id} already exists.");
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Log {e} here.");
            }
            return false;
        }
    }
}