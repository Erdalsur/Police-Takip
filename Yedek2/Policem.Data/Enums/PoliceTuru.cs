using System.ComponentModel;

namespace Policem.Data.Enums
{
    public enum PoliceTuru
    {
        [EnumDescription("Seçiniz")]
        Seciniz,
        [EnumDescription("Kasko")]
        Kasko,
        [EnumDescription("Trafik")]
        Trafik,
        [EnumDescription("Araç Muayenesi")]
        Muayene,
        [EnumDescription("Egsoz Muayenesi")]
        Egsoz,
        [EnumDescription("Yetki Belgesi K2")]
        K2,
        [EnumDescription("Piskoteknik Belgesi")]
        Piskoteknik,
        [EnumDescription("Sağlık")]
        Saglık,
        [EnumDescription("Hayat")]
        Hayat,
        [EnumDescription("Konut")]
        Konut,
        [EnumDescription("Dask")]
        Dask,
        [EnumDescription("Ticari Risk")]
        TicariRisk,
        [EnumDescription("Elektronik Cihaz")]
        Elektronik,
        [EnumDescription("Makina Kırılması")]
        MakinaKirilmasi,
        [EnumDescription("İşveren Mali Mesuliyet")]
        IsverenMaliMesuliyet,
        [EnumDescription("3. Şahıs Mali Mesuliyet")]
        SahisMaliMesuliyet,
    }
}
