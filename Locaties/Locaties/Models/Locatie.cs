using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locaties.Models
{
    public class Locatie
    {
        public Guid LocatieID { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string StoreName { get; set; }
        private int? facebookID;
    }
}