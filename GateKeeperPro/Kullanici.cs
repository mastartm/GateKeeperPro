using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeperPro
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string TcNo { get; set; }
        public string KartNo { get; set; }
        public virtual string Bilgi()
        {
            return $"{AdSoyad} (Kart No: {KartNo})";
        }
    }
}
