using MongoDB.Driver;

namespace DishesTask.Utilities
{
    public class DbConnector
    {
        /// <summary>
        /// Stellt die Verbindung zur Datenbank her.
        /// </summary>
        /// <returns>den Client.</returns>
        public MongoClient CreateConnection()
        {
            //Hardcoded ConnectionString und Passwort nur zur einfachen und schnellen erfüllung der Aufgabe.
            MongoClient dbClient = new MongoClient("mongodb+srv://acquaintance-task:jReRpiTCKbyjViZ1@acquaintancecluster.rluq4.mongodb.net/test");
            return dbClient;
        }
    }
}