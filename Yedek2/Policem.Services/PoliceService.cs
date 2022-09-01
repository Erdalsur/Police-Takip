using System.ServiceProcess;
using Quartz;
using Quartz.Impl;

namespace Policem.Services
{
    public partial class PoliceService : ServiceBase
    {
        public PoliceService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            InitializeGelmeyenPolicelerJobs();
            InitializeGelecekAyBitecekPolicelerJobs();
            InitializeSon15GunBitecekPolicelerJobs();
            InitializeSon7GunBitecekPolicelerJobs();
        }

        protected override void OnStop()
        {
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //scheduler.Shutdown();
        }
        public void Start()
        {

            OnStart(new string[0]);
        }

        private static async void InitializeGelecekAyBitecekPolicelerJobs()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var GelecekAyBitecekPolicelerJob = JobBuilder.Create<GelecekAyBitecekPoliceler>()
                .WithIdentity("GelecekAyBitecekPolicelerJob")
                .Build();
            var GelecekAyBitecekPolicelerTrigger = TriggerBuilder.Create()
                .WithIdentity("GelecekAyBitecekPolicelerCron")
                .StartNow()
                .WithCronSchedule("0 15 10 ? * 6L")//Her ayın sonuncu Cuma günü saat 08: 15'te ateş edin
                .Build();

            var result = await _scheduler.ScheduleJob(GelecekAyBitecekPolicelerJob, GelecekAyBitecekPolicelerTrigger);
        }
        private static async void InitializeGelmeyenPolicelerJobs()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var GelmeyenPolicelerJob = JobBuilder.Create<GelmeyenPoliceler>()
                .WithIdentity("GelmeyenPolicelerJob")
                .Build();
            var GelmeyenPolicelerTrigger = TriggerBuilder.Create()
                .WithIdentity("GelmeyenPolicelerCron")
                .StartNow()
                .WithCronSchedule("0 15 10 ? * *")//Her gün saat 10:15'te ateş edin
                .Build();

            var result = await _scheduler.ScheduleJob(GelmeyenPolicelerJob, GelmeyenPolicelerTrigger);
        }
        private static async void InitializeSon15GunBitecekPolicelerJobs()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var Son15GunBitecekPolicelerJob = JobBuilder.Create<Son15GunBitecekPoliceler>()
                .WithIdentity("Son15GunBitecekPolicelerJob")
                .Build();
            var Son15GunBitecekPolicelerTrigger = TriggerBuilder.Create()
                .WithIdentity("Son15GunBitecekPolicelerCron")
                .StartNow()
                .WithCronSchedule("0 0 12 ? * MON *")//Her Hafta Pazartesi saat 12:00'te ateş edin
                .Build();

            var result = await _scheduler.ScheduleJob(Son15GunBitecekPolicelerJob, Son15GunBitecekPolicelerTrigger);
        }
        private static async void InitializeSon7GunBitecekPolicelerJobs()
        {
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();

            var Son7GunBitecekPolicelerJob = JobBuilder.Create<Son7GunBitecekPoliceler>()
                .WithIdentity("Son7GunBitecekPolicelerJob")
                .Build();
            var Son7GunBitecekPolicelerTrigger = TriggerBuilder.Create()
                .WithIdentity("Son7GunBitecekPolicelerCron")
                .StartNow()
                .WithCronSchedule("0 0 9 ? * WED,SAT *")//Her Hafta Pazartesi-Cumartesi saat 09:00'te ateş edin
                .Build();

            var result = await _scheduler.ScheduleJob(Son7GunBitecekPolicelerJob, Son7GunBitecekPolicelerTrigger);
        }
    }
}
