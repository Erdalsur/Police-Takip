using System;
using Policem.Data.Enums;

namespace Policem.Data
{
    public partial class PasifPolicerim : IEntity
    {
        public int PoliceId { get; set; }
        public string Unvan { get; set; }
        public string Name { get; set; }
        public PoliceTuru PoliceTuru { get; set; }
        public string PoliceNo { get; set; }
        public DateTime PoliceBaslangicTarih { get; set; }
        public DateTime PoliceBitisTarih { get; set; }
        public string Aciklama { get; set; }
        public string Policelenen { get; set; }
        public decimal Tutar { get; set; }
        public decimal ArtisYuzdesi { get; set; }
        public EvetHayir Basildimi { get; set; }
    }

}