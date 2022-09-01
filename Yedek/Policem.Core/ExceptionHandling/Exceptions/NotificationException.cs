using System;
using System.Collections.Generic;

namespace Policem.Core.ExceptionHandling.Exceptions
{
    public class NotificationException : Exception
    {
        public NotificationException(string mesaj) : base(mesaj)
        {

        }

        public NotificationException(string mesaj, Exception hata)
            : base(mesaj, hata)
        {

        }
    }
    public class ValidationCoreException : NotificationException
    {
        public ValidationCoreException(string mesaj)
            : base(mesaj)
        {

        }

        public ValidationCoreException(string mesaj, Exception hata)
            : base(mesaj, hata)
        {

        }
    }

    public static class BusinessRules
    {
        static BusinessRules()
        {
            BusinessExceptions = new List<BusinessException>();
        }

        [ThreadStatic] public static List<BusinessException> BusinessExceptions;

        public static void Add(BusinessException businessException)
        {
            BusinessExceptions.Insert(0, businessException);

        }
    }
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
