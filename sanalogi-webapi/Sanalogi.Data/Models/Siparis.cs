using Sanalogi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanalogi.Data.Models
{
    public class Siparis : Entity
    {
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }
        public string SiparisVerenFirma { get; set; }
        public DateTime SiparisTarihi { get; set; }
    }
}
