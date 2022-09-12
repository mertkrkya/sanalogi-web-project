using Sanalogi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanalogi.Data.Dto
{
    public class SiparisDto
    {
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }
        public string SiparisVerenFirma { get; set; }
        public DateTime SiparisTarihi { get; set; }
    }
}
