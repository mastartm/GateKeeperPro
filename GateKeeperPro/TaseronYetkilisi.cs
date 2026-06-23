using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeperPro
{
    public class TaseronYetkilisi : Kullanici
    {
        public int YetkiSeviyesi { get; set; }

        public override string Bilgi()
        {
            return $"{AdSoyad} | Taşeron Yetkilisi | Yetki Seviyesi: {YetkiSeviyesi}";
        }
    }
}
