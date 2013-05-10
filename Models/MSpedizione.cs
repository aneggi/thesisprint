using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KiLab.Models
{
    public class MSpedizione
    {

        public int ID { get; set; }
        public string titolo { get; set; }
        public string descrizione { get; set; }
        public decimal costo { get; set; }
        public bool isDelete { get; set; }
    }
}