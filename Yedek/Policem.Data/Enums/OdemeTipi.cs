using System.ComponentModel;

namespace Policem.Data.Enums
{
    public enum OdemeTipi
    {
        [Description("Seçiniz")]
        Seciniz = -1,
        [Description("Nakit")]
        Nakit,
        [Description("Kredi Kartı")]
        KrediKartı,
        [Description("Banka")]
        Banka,
    }
}
