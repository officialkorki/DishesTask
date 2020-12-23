using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DishesTask.Filter
{
    /// <summary>
    /// Filter für die Update-Operation
    /// </summary>
    public class PutFilter
    {
        /// <summary>
        /// Angabe der ID des zu updatenden Produkts.
        /// </summary>
        [DefaultValue(0)]
        [FromQuery] public int Id { get; set; }

        /// <summary>
        /// Auswahl des Active-Flags, soll das Produkt auf Aktiv oder Inaktiv gesetzt werden.
        /// </summary>
        [FromQuery]
        public bool Active { get; set; }
    }
}