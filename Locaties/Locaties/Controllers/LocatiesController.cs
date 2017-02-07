using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Locaties.Models;
using Newtonsoft.Json;
using PagedList;
using System.Device;
using System.Device.Location;
using System.Globalization;

namespace Locaties.Controllers
{
    public class LocatiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locaties        
        /// <summary>
        /// Stuurd de gebruiker door naar een pagina met een lijst van alle locaties die gesorteerd zijn op basis van de gebruikers locatie.
        /// </summary>
        /// <param name="latitude">de latitude.</param>
        /// <param name="longtitude">de longtitude.</param>
        /// <returns>View met gesorteerde locatie lijst.</returns>
        public ActionResult Index(string latitude, string longitude)
        {
            
            //leest het JSON bestand in en slaat het op in een string.
            string json = System.IO.File.ReadAllText(Server.MapPath("~/JSON/locaties.json"));
            //maakt een variable met alle locaties als lijst.
            List<Locatie> LocatieLijst = JsonConvert.DeserializeObject<List<Locatie>>(json);

            

            if (latitude != null && longitude != null)
            {
                //bevat de latitude en longitude van de momenteele locatie van het apparaat.
                var uCoord = new GeoCoordinate(Convert.ToDouble(latitude, CultureInfo.InvariantCulture), Convert.ToDouble(longitude, CultureInfo.InvariantCulture));

                foreach (var l in LocatieLijst)
                {
                    var Coordinate = new GeoCoordinate(Double.Parse(l.Latitude.ToString()), Double.Parse(l.Longitude.ToString()));
                    var distance = uCoord.GetDistanceTo(Coordinate);

                    l.Distance = distance;
                }
                return View(LocatieLijst.OrderBy(d => d.Distance).ToList());
            }
            //geeft een webpagina weer met de locatie variable als lijst.
            return View(LocatieLijst);
        }

        /// <summary>
        /// Stuurde de gebruiker door naar een pagina met een google maps. hierop staan alle locaties aan gegeven met een mark.
        /// </summary>
        /// <returns>View met een IEnumerable van alle locaties</returns>
        public ActionResult GMap()
        {
            //leest het JSON bestand in en slaat het op in een string.
            string json = System.IO.File.ReadAllText(Server.MapPath("~/JSON/locaties.json"));
            //maakt een variable met alle locaties als lijst.
            var LocatieLijst = JsonConvert.DeserializeObject<List<Locatie>>(json);
            //hier wordt van de lijst met locaties een IEnumerable gemaakt.
            IEnumerable<Locatie> LocatiesMarkers = LocatieLijst;
            //geeft een webpagina weer met de locaties aangegeven op een Google map.
            return this.View(LocatiesMarkers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
