using System;

namespace Policem.Core.Core.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string mesaj)
            : base(mesaj)
        {

        }

        public BusinessException(string mesaj, Exception exception)
            : base(mesaj, exception)
        {

        }
    }
}
