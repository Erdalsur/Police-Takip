using System.ComponentModel;

namespace Policem.Data.Enums
{
    public enum PoliceTuru
    {
        [EnumDescription("Seçiniz")]
        Seciniz,
        [EnumDescription("Kasko Sigortası")]
        Kasko,
        [EnumDescription("Trafik Sigortası")]
        Trafik,
        [EnumDescription("Araç Muayenesi")]
        Muayene,
        [EnumDescription("Egsoz Muayenesi")]
        Egsoz,
        [EnumDescription("K2 Yetki Belgesi")]
        K2,
        [EnumDescription("Piskoteknik Belgesi")]
        Piskoteknik,
        [EnumDescription("Sağlık Sigortası")]
        Saglık,
        [EnumDescription("Hayat Sigortası")]
        Hayat,
        [EnumDescription("Konut Sigortası")]
        Konut,
        [EnumDescription("Dask Sigortası")]
        Dask,
        [EnumDescription("Ticari Risk Sigortası")]
        TicariRisk,
        [EnumDescription("Elektronik Cihaz Sigortası")]
        Elektronik,
        [EnumDescription("Makina Kırılması Sigortası")]
        MakinaKirilmasi,
        [EnumDescription("İşveren Mali Mesuliyet Sigortası")]
        IsverenMaliMesuliyet,
        [EnumDescription("3. Şahıs Mali Mesuliyet Sigortası")]
        SahisMaliMesuliyet,
        [EnumDescription("İş Yeri Sigortası")]
        Isyeri,
    }
}
