using System;


namespace Policem.Core.Core.CrossCuttingConcern.ExceptionHandling.Exceptions
{
    public class ValidationCoreException : NotificationException
    {
        public ValidationCoreException(string mesaj)
            : base(mesaj)
        {

        }

        public ValidationCoreException(string mesaj,string errorCode)
            : base(mesaj)
        {
            this.Data.Add(5, errorCode);
        }

        public ValidationCoreException(string mesaj, Exception hata)
            : base(mesaj, hata)
        {

        }
    }
}
