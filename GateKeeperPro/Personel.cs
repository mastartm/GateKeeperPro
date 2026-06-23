using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeperPro
{
    public class Personel : Kullanici
    {
        public int TaseronId { get; set; }
        public bool SgkGirisiVar { get; set; }
        public bool IsgBelgesiVar { get; set; }
        public bool KartIptalMi { get; set; }

        public bool IsEvraklariTamam => SgkGirisiVar && IsgBelgesiVar;
        public override string Bilgi()
        {
            return $"{AdSoyad} | Personel | Evrak Tamam: {IsEvraklariTamam}";
        }
    }
}