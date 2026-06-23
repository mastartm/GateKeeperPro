using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeperPro
{
    public class Taseron
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; }
        public string SozlesmeNo { get; set; }
        public List<Personel> Personeller { get; set; } = new List<Personel>();
    }
}