using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Policem.Core.Utility
{
    public class FormatYuzde : IFormatProvider, ICustomFormatter
    {
        public FormatYuzde()
        {
        }

        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            try
            {
                double value = double.Parse(arg.ToString());
                return value == 0.0 ? "" : value.ToString("'%' #,##0.##");

            }
            catch (Exception)
            {
                return arg.ToString();
            }
        }
    }

    public class FormatPara : IFormatProvider, ICustomFormatter
    {
        readonly string sembol;
        public FormatPara(string ParaSembolu)
        {
            sembol = ParaSembolu;
        }

        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            try
            {
                double value = double.Parse(arg.ToString());
                return value == 0.0 ? "" : value.ToString("#,###.## '"+sembol+"'");

            }
            catch (Exception)
            {
                if (arg == null)
                    return null;
                return arg.ToString();
            }
        }
    }

    public class FormatAdet : IFormatProvider, ICustomFormatter
    {
        public FormatAdet()
        {
        }

        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            try
            {
                double value = double.Parse(arg.ToString());
                return value == 0.0 ? "YOK" : value.ToString("# Adet");

            }
            catch (Exception)
            {
                if (arg == null)
                    return null;
                return arg.ToString();
            }
        }
    }
}
