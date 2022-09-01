using System.ComponentModel;

namespace Policem.Data.Enums
{
    public enum AktifPoliceRapor
    {
        [EnumDescription("Hepsi")]
        Hepsi,
        [EnumDescription("Bu Ay Bitecek")]
        SonAy,
        [EnumDescription("Gelecek Ay Bitecek")]
        GelecekAy,
        [EnumDescription("Son 7 Gün İçinde")]
        Son7,
        [EnumDescription("Son 15 Gün İçinde")]
        Son15,
    }

    public enum PasifPoliceRapor
    {
        [EnumDescription("Hepsi")]
        Hepsi,
        [EnumDescription("Bu Ay Bitenler")]
        SonAy,
        [EnumDescription("Geçen Ay Bitenler")]
        GecenAy,
        [EnumDescription("Son 7 Gün İçinde")]
        Son7,
        [EnumDescription("Son 15 Gün İçinde")]
        Son15,
    }

    public enum PoliceRaporTipi
    {
        [EnumDescription("Hepsi")]
        Hepsi,
        [EnumDescription("Sigortalar")]
        Sigortalar,
        [EnumDescription("Muayeneler")]
        Muayeneler,
        [EnumDescription("Belgeler")]
        Belgeler,

    }
}
