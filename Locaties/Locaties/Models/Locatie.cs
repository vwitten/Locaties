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
        //de afstand tussen deze locatie en de gebruiker.
        public double Distance { get; set; }

        public Locatie(decimal _Longitude, decimal _Latitude, string _Street, string _City, string _ZipCode, string _StoreName, string _FacebookID)
        {
            this.Longitude = _Longitude;
            this.Latitude = _Latitude;
            this.Street = _Street;
            this.City = _City;
            this.ZipCode = _ZipCode;
            this.StoreName = _StoreName;
            this.FacebookID = _FacebookID;
        }
        //public Locatie(decimal _Longitude, decimal _Latitude, string _Street, string _City, string _ZipCode, string _StoreName, string _FacebookID, double _Distance)
        //{
        //    this.Longitude = _Longitude;
        //    this.Latitude = _Latitude;
        //    this.Street = _Street;
        //    this.City = _City;
        //    this.ZipCode = _ZipCode;
        //    this.StoreName = _StoreName;
        //    this.FacebookID = _FacebookID;
        //    this.Distance = _Distance;
        //}
    }
}