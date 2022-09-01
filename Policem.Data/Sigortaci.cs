using System.Collections.Generic;

namespace Policem.Data
{
    public partial class Sigortaci:IEntity
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

    public partial class SigortaciEkran : IEntity
    {
        public SigortaciEkran()
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
        public int AktifPoliceSayisi { get; set; }
        public int PasifPoliceSayisi { get; set; }
        public virtual ICollection<Police> Policeler { get; set; }
        public int ToplamPoliceSayisi { get; set; }

        public override string ToString()
        {
            return Unvan.ToString();
        }

    }
}
