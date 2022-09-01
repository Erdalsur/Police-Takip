using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Policem.Core.Utility
{
    public class SqlLocator
    {
        private const short SQL_HANDLE_ENV = (short)1;
        private const short SQL_HANDLE_DBC = (short)2;
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = (short)0;
        private const short SQL_NEED_DATA = (short)99;
        private const short DEFAULT_RESULT_SIZE = (short)1024;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";

        private SqlLocator()
        {
        }

        [DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short hType, IntPtr inputHandle, out IntPtr outputHandle);

        [DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr henv, int attribute, IntPtr valuePtr, int strLength);

        [DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr handle);

        [DllImport("odbc32.dll", CharSet = CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr hconn, StringBuilder inString, short inStringLength, StringBuilder outString, short outStringLength, out short outLengthNeeded);

        public static string[] GetServers()
        {
            string[] strArray = (string[])null;
            string str = string.Empty;
            IntPtr outputHandle1 = IntPtr.Zero;
            IntPtr outputHandle2 = IntPtr.Zero;
            StringBuilder inString = new StringBuilder("DRIVER=SQL SERVER");
            StringBuilder outString = new StringBuilder(1024);
            short inStringLength = (short)inString.Length;
            short outLengthNeeded = (short)0;
            try
            {
                if ((int)SqlLocator.SQLAllocHandle((short)1, outputHandle1, out outputHandle1) == 0)
                {
                    if ((int)SqlLocator.SQLSetEnvAttr(outputHandle1, 200, (IntPtr)3, 0) == 0)
                    {
                        if ((int)SqlLocator.SQLAllocHandle((short)2, outputHandle1, out outputHandle2) == 0)
                        {
                            if (99 == (int)SqlLocator.SQLBrowseConnect(outputHandle2, inString, inStringLength, outString, (short)1024, out outLengthNeeded))
                            {
                                if (1024 < (int)outLengthNeeded)
                                {
                                    outString.Capacity = (int)outLengthNeeded;
                                    if (99 != (int)SqlLocator.SQLBrowseConnect(outputHandle2, inString, inStringLength, outString, outLengthNeeded, out outLengthNeeded))
                                        throw new ApplicationException("Unabled to aquire SQL Servers from ODBC driver.");
                                }
                                str = outString.ToString();
                                int startIndex = str.IndexOf("{") + 1;
                                int length = str.IndexOf("}") - startIndex;
                                str = startIndex <= 0 || length <= 0 ? string.Empty : str.Substring(startIndex, length);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                str = string.Empty;
            }
            finally
            {
                if (outputHandle2 != IntPtr.Zero)
                {
                    int num1 = (int)SqlLocator.SQLFreeHandle((short)2, outputHandle2);
                }
                if (outputHandle1 != IntPtr.Zero)
                {
                    int num2 = (int)SqlLocator.SQLFreeHandle((short)1, outputHandle2);
                }
            }
            if (str.Length > 0)
                strArray = str.Split(",".ToCharArray());
            return strArray;
        }
    }
}
//var passString = txtMailSifre.EditValue.ToString().Trim();
//SecureString secureString = passString.ToSecureString();
//string secureCryptolu = secureString.Encrypt();

//var test = secureCryptolu.DecryptSecure();
//var test2 = test.ToUnsecureString();
//bool deneme = test2 == passString ? true : false;