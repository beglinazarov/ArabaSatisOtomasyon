using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArabaSatisOtomasyon.Entities
{
    [Table("YakitTuru")]
    public class YakitTurleri
    {
        public int Id { get; set; }
        public int Adi { get; set; }
    }
}