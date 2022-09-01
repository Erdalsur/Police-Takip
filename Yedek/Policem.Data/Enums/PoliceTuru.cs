using System.ComponentModel;

namespace Policem.Data.Enums
{
    public enum PoliceTuru
    {
        [Description("Seçiniz")]
        Seciniz = -1,
        [Description("Kasko")]
        Kasko,
        [Description("Trafik")]
        Trafik,
        [Description("Araç Muayenesi")]
        Muayene,
        [Description("Egsoz Muayenesi")]
        Egsoz,
        [Description("Yetki Belgesi K2")]
        K2,
        [Description("Piskoteknik Belgesi")]
        Piskoteknik,
        [Description("Sağlık")]
        Saglık,
        [Description("Hayat")]
        Hayat,
        [Description("Konut")]
        Konut,
        [Description("Dask")]
        Dask,
        [Description("Ticari Risk")]
        TicariRisk,
        [Description("Elektronik Cihaz")]
        Elektronik,
        [Description("Makina Kırılması")]
        MakinaKirilmasi,
        [Description("İşveren Mali Mesuliyet")]
        IsverenMaliMesuliyet,
        [Description("3. Şahıs Mali Mesuliyet")]
        SahisMaliMesuliyet,
    }
}
