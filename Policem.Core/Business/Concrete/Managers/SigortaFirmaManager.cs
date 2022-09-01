using System;
using System.Collections.Generic;
using System.Linq;
using Policem.Core.Business.Abstract;
using Policem.Core.Business.ValidationRules.FluentValidation;
using Policem.Core.Core.Aspects.ValidationAspects;
using Policem.Data;
using Policem.Data.Common.Abstract;


namespace Policem.Core.Business.Concrete.Managers
{
    public class FirmaPoliceManager: IFirmaPoliceService
    {
        private ISigortaFirmaDal _sigortaFirma;
        private IPoliceDal _policeDal;

        public FirmaPoliceManager(ISigortaFirmaDal sigortaFirma,IPoliceDal policeDal)
        {
            _sigortaFirma = sigortaFirma;
            _policeDal = policeDal;
        }

        public List<SigortaciEkran> GetAll()
        {
            List<SigortaciEkran> sigortaciEkrans = new List<SigortaciEkran>();
            var sigortaciListesi = _sigortaFirma.GetList();
            foreach (Sigortaci sigortaci in sigortaciListesi)
            {
                SigortaciEkran Kayit = new SigortaciEkran();
                Kayit.FirmaNo = sigortaci.FirmaNo;
                Kayit.HasarNumarasi = sigortaci.HasarNumarasi;
                Kayit.Policeler = sigortaci.Policeler;
                Kayit.SigortaciAdi = sigortaci.SigortaciAdi;
                Kayit.SigortaciId = sigortaci.SigortaciId;
                Kayit.TemsilciAdi = sigortaci.TemsilciAdi;
                Kayit.TemsilciTel = sigortaci.TemsilciTel;
                Kayit.Unvan = sigortaci.Unvan;                
                var a = _policeDal.GetList(t=> t.SigortaciId==sigortaci.SigortaciId);
                var aktifler = a.Where(t => t.PoliceBitisTarih >= DateTime.Now).ToList();
                Kayit.ToplamPoliceSayisi =a.Count;
                Kayit.AktifPoliceSayisi = aktifler.Count;
                Kayit.PasifPoliceSayisi = 0;
                sigortaciEkrans.Add(Kayit);
            }
            return sigortaciEkrans;
        }
    }
    public class SigortaFirmaManager : ISigortaFirmaService
    {
        private ISigortaFirmaDal _sigortaDal;


        public SigortaFirmaManager(ISigortaFirmaDal sigortaDal)
        {
            _sigortaDal = sigortaDal;

        }
        [FluentValidationAspect(typeof(SigortaciValidator))]
        public Sigortaci Add(Sigortaci sigortaFirma)
        {
            return _sigortaDal.Add(sigortaFirma);
        }

        public Sigortaci Delete(Sigortaci sigortaFirma)
        {
            return _sigortaDal.Delete(sigortaFirma);
        }

        public List<Sigortaci> GetAll()
        {
            return _sigortaDal.GetList();
        }

        public Sigortaci GetByFirmaNumber(string number)
        {
            return _sigortaDal.Get(i => i.FirmaNo == number);
        }

        public Sigortaci GetById(int id)
        {
            return _sigortaDal.Get(i => i.SigortaciId == id);
        }

        [FluentValidationAspect(typeof(SigortaciValidator))]
        public Sigortaci Update(Sigortaci sigortaFirma)
        {
            //validation
            //ValidatorTool.FluentValidate(new SigortaciValidator(), sigortaFirma);
            return _sigortaDal.Update(sigortaFirma);
        }
    }
}
