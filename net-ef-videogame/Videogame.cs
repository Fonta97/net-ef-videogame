using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{

    [Table("videogame")]

    public class Videogame
    {
        [Key] public int VideogameID { get; set; }

        [Column("videogame_name")]
        public string _name { get; set; }

        [Column("videogame_description")]
        public string _description { get; set; }

        [Column("videogame_release")]
        public DateTime _release { get; set; }

        public DateTime _created_at { get; set; } = DateTime.Now;
        public DateTime _updated_at { get; set; } = DateTime.Now;


        // Relazione 1 a N: un videogioco appartiene a una sola software house
        public int SoftwareHouseID { get; set; }
        public Software_House SoftwareHouse { get; set; }

        public Videogame()
        {

        }

        public Videogame(int id, string name, string description, DateTime release, DateTime create, DateTime update, int sofware_house_id)
        {
            VideogameID = id;
            _name = name;
            _description = description;
            _release = release;
            _created_at = create;
            _updated_at = update;
            SoftwareHouseID = sofware_house_id;
        }
    }

    [Index(nameof(_tax_id), IsUnique = true)]
    public class Software_House
    {
        [Key] public int HouseID { get; set; }

        [Column("software_house_name")]
        public string _name { get; set; }

        [Column("software_house__tax_id")]
        public string _tax_id { get; set; }

        [Column("software_house_city")]
        public string _city { get; set; }

        [Column("software_house_country")]
        public string _country { get; set; }
        public DateTime _created_at { get; set; } = DateTime.Now;
        public DateTime _updated_at { get; set; } = DateTime.Now;


        // Relazione 1 a N: una software house può avere molti videogiochi
        public List<Videogame> Videogames { get; set; }

        public Software_House()
        {

        }
        public Software_House(string name, string taxID, string city, string country)
        {
            _name = name;
            _tax_id = taxID;
            _city = city;
            _country = country;
            _created_at = DateTime.Now;
            _updated_at = DateTime.Now;

            Videogames = new List<Videogame>();
        }
    }

}