using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArabaSatisOtomasyon.Entities
{
    [Table("Araba")]
    public class Araba
    {
        public int Id { get; set; }
        public int Model;
        public string Marka { get; set; }
        public string Seri { get; set; }
        public string Yakit { get; set; }
        public int VitesTuruId { get; set; }
        public int KM { get; set; }
        public int MotorHacmi { get; set; }
        public int HP { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime IlanTarihi { get; set; }
    }
}