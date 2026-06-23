using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeperPro
{
    public class TurnikeLog
    {
        public int Id { get; set; }
        public Personel Personel { get; set; }
        public DateTime Tarih { get; set; }
        public string IpAdresi { get; set; }
        public bool GecisOnaylandiMi { get; set; }
        public string RedNedeni { get; set; }
    }
}