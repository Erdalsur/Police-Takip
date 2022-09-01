using Policem.Data.Enums;

namespace Policem.Data
{
    public class PoliceDosyaDetay:IEntity
    {
        public int Id { get; set; }
        public int PoliceId { get; set; }
        public byte[] Dosya { get; set; }
        public string DosyaType { get; set; }
        public string Aciklama { get; set; }
        public EvetHayir Dosyalandimi { get; set; }
        
    }
}
