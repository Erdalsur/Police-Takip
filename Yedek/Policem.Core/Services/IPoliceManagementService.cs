using System;
using System.Collections.Generic;
using Policem.Data;

namespace Policem.Core.Services
{
    public interface IPoliceManagementService : IDisposable
    {
        IEnumerable<Police> GetAllPolice();
        int GetTotalPolice();
        Police GetPolice(int Id);
        Police EklePolice(Police police);
        Police SilPolice(Police police);
        Police GüncellePolice(Police police);
    }
}
