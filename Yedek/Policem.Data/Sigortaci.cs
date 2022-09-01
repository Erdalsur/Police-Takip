using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policem.Data
{
    public class Sigortaci:IEntity
    {
        public Sigortaci()
        {
            Policeler = new HashSet<Police>();
        }
        public int SigortaciId { get; set; }
        public string FirmaNo { get; set; }
        public string SigortaciAdi { get; set; }        
        public string Unvan { get; set; }
        public string HasarNumarasi { get; set; }
        public string TemsilciAdi { get; set; }
        public string TemsilciTel { get; set; }
        public virtual ICollection<Police> Policeler { get; set; }
        public override string ToString()
        {
            return Unvan.ToString();
        }

    }
}
