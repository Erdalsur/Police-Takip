using System.Collections.Generic;

namespace Policem.Data
{
    public class Firma:IEntity
    {
        public Firma()
        {
            Policeler = new HashSet<Police>();
        }
        public int FirmaId { get; set; }
        public string Kod { get; set; }
        public string Name { get; set; }        
        public string Unvan { get; set; }
        public string Yetkili { get; set; }
        public string VKNO { get; set; }
        public virtual ICollection<Police> Policeler { get; set; }
        public override string ToString()
        {
            return Unvan.ToString();
        }

    }
}
