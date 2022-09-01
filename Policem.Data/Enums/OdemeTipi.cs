using System.ComponentModel;

namespace Policem.Data.Enums
{
    public enum OdemeTipi
    {
        [EnumDescription("Seçiniz")]
        Seciniz,
        [EnumDescription("Nakit")]
        Nakit,
        [EnumDescription("Kredi Kartı")]
        KrediKartı,
        [EnumDescription("Banka")]
        Banka,
    }
}
