using Policem.Core.Services;
using Policem.Data.Common.Repository;
using StructureMap;

namespace Policem.Core.DependencyResolution
{
    public static class Mapper
    {
        public static void CreateServiceMaps()
        {
            ObjectFactory.Configure(factory =>
            {
                factory.For<ISigortaciManagementRepository>().Use<SigortaciManagementRepository>();
                factory.For<ISigortaciManagementService>().Use<SigortaciManagementService>();
                factory.For<IFirmaManagementRepository>().Use<FirmaManagementRepository>();
                factory.For<IFirmaManagementService>().Use<FirmaManagementService>();
                factory.For<IPoliceManagementRepository>().Use<PoliceManagementRepository>();
                factory.For<IPoliceManagementService>().Use<PoliceManagementService>();
            });
        }

       
    }
}
