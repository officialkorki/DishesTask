using DishesTask.Models;
using DishesTask.Utilities;
using MongoDB.Driver;

namespace DishesTask.Repositories
{
    /// <summary>
    /// Collection-Abruf ausgelagert.
    /// </summary>
    public class InternalDishesRepository
    {
        public IMongoCollection<Dishes> FindAll()
        {
            var con = new DbConnector().CreateConnection();
            var col = DbCollection.GetCollection(con);
            return col;
        }
    }
}