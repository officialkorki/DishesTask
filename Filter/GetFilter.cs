using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DishesTask.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DishesTask.Filter
{
    /// <summary>
    /// Filter für die GET-Operation
    /// </summary>
    public class GetFilter
    {
        /// <summary>
        /// Auswahl des Status welche Produkte man zurückgeliefert bekommen möchte
        /// </summary>
        [EnumDataType(typeof(Status))]
        [JsonConverter(typeof(StringEnumConverter))]
        [DefaultValue(Status.All)]
        [FromQuery]
        public Status Status { get; set; }
    }
}