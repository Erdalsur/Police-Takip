using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Policem.Data.Enums;

namespace Policem.Data
{
    public class Police:IEntity
    {
        public int PoliceId { get; set; }
        public int FirmaId { get; set; }
        public int SigortaciId { get; set; }
        public string Aciklama { get; set; }
        public PoliceTuru PoliceTuru { get; set; }
        public string PoliceNo { get; set; }
        public DateTime PoliceBaslangicTarih { get; set; }
        public DateTime PoliceBitisTarih { get; set; }
        public string Policelenen { get; set; }
        public OdemeTipi OdemeTuru { get; set; }
        public decimal Tutar { get; set; }
        public decimal OncekiTutar { get; set; }
        public decimal ArtisYuzdesi { get; set; }
        public Taksit Taksit { get; set; }
        public int TaksitSayisi { get; set; }
        public int Yenilendimi { get; set; }
        public int YeniPoliceId { get; set; }
        public EvetHayir PoliceGeldimi { get; set; }
        public virtual Sigortaci Sigortaci { get; set; }
        public virtual Firma Firma { get; set; }

        public override string ToString()
        {
            string a;
            if (PoliceNo != null)
                a = PoliceNo.ToString();
            else
                a = string.Empty;
            return a;
        }
    }
}
