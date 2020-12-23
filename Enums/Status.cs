using System;
using System.ComponentModel;

namespace DishesTask.Enums
{
    /// <summary>
    /// Zum festlegen nach welchem Produktstatus gefiltert werden soll.
    /// </summary>
    [Flags]
    public enum Status
    {
        /// <summary>
        /// Ruft alle Produkte aus der Datenbank ab.
        /// </summary>
        [Description("All")]
        All = 0,
        /// <summary>
        /// Ruft alle Aktiven Produkte aus der Datenbank ab.
        /// </summary>
        [Description("Active")]
        Active = 1,
        /// <summary>
        /// Ruft alle Inaktiven Produkte aus der Datenbank ab.
        /// </summary>
        [Description("Inactive")]
        Inactive = 1 << 1
    }
}