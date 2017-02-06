using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locaties.Models
{
    public class Locatie
    {
        //unique code voor de locatie
        public Guid LocatieID { get; set; }
        //de longitude van de locatie
        [JsonProperty(PropertyName = "LONGITUDE")]
        public decimal Longitude { get; set; }
        //de latitude van de locatie
        [JsonProperty(PropertyName = "LATITUDE")]
        public decimal Latitude { get; set; }
        //de straatnaam van de locatie
        [JsonProperty(PropertyName = "STREET")]
        public string Street { get; set; }
        //de stad naam van de locatie
        [JsonProperty(PropertyName = "CITY")]
        public string City { get; set; }
        //de zipcode van de locatie
        [JsonProperty(PropertyName = "ZIP CODE")]
        public string ZipCode { get; set; }
        //de winkelnaam van de locatie
        [JsonProperty(PropertyName = "STORE NAME")]
        public string StoreName { get; set; }
        //het facebookID van de locatie
        [JsonProperty(PropertyName = "FACEBOOK ID")]
        public string FacebookID { get; set; }
    }
}