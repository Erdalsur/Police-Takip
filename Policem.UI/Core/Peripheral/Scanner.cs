using DevExpress.XtraEditors;
using Microsoft.Win32;
using Policem.UI.Core.Peripheral.PoliceScan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using WIA;

namespace Policem.UI.Core.Peripheral
{
    public class Scanner
    {
        static Device device;
        static string DeviceId = string.Empty;
        static WIA.Item PreparedScanner;

        private static void Initialize(int dotsperinch = 300)
        {
            try
            {
                RegistryKey register = Registry.CurrentUser.CreateSubKey(@"Software\PoliceTakip");
                DeviceId = (string)register.GetValue("DeviceID", String.Empty);
                if (DeviceId == string.Empty)
                    DeviceId = AppSession.ScannerDeviceId;

                if (DeviceId == string.Empty)
                    OpenDeviceDialog();

                DeviceManager manager = new DeviceManager();
                device = null;
                foreach (DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.DeviceID == DeviceId)
                    {
                        device = info.Connect();
                        break;
                    }
                }

                WIA.Device scanner = null;
                try
                {
                    object something = 1;
                    scanner = manager.DeviceInfos.get_Item(ref something).Connect();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                int DPI = dotsperinch;




                PreparedScanner = scanner.Items[1] as WIA.Item;

                //SetProperty(PreparedScanner, "6146", 1);    //Color: 4 black and white, 2 grayscale, 1 color, 0 unspecified
                //SetProperty(PreparedScanner, "6147", DPI);  //Horizontal Resolution
                //SetProperty(PreparedScanner, "6148", DPI);  //Vertical Resolution            
                //SetProperty(PreparedScanner, "6149", 16);   //Horizontal Starting Position (Scanning Area)
                //SetProperty(PreparedScanner, "6150", 0);    //Vertical Starting Position (Scanning Area)

                // SetProperty(PreparedScanner, "6154", 0);    //Brightness
                // SetProperty(PreparedScanner, "6155", 0);    //Contrast

                //SetProperty(PreparedScanner, "4104", 16);     //Color Depth
                //SetProperty(PreparedScanner, "71723", 1);     //Color Enhanced

                /*
                string s = string.Empty;
                foreach (Property propertyItem in Item1.Properties)
                    if (!propertyItem.IsReadOnly)
                        s += String.Format("{0}\t{1}\t{2}", propertyItem.Name, propertyItem.PropertyID, propertyItem.get_Value()) + Environment.NewLine;
                */

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void OpenDeviceDialog()
        {
            CommonDialog dialog = new CommonDialog();
            device = dialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
            if (device != null)
            {
                RegistryKey register = Registry.CurrentUser.CreateSubKey(@"Software\PoliceTakip");
                register.SetValue("DeviceID", DeviceId, RegistryValueKind.String);
                AppSession.ScannerDeviceId = DeviceId;
                Registry.LocalMachine.Flush();
                DeviceId = device.DeviceID;
            }
        }

        public static Image ScanImage()
        {
            try
            {
                Initialize();
                WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
                WIA.ImageFile ImageX = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(PreparedScanner, wiaFormatJPEG, false);
                //WIA.ImageFile ImageX = (WIA.ImageFile)PreparedScanner.Transfer(WIA.FormatID.wiaFormatPNG);
                Vector vector = ImageX.FileData;
                return Image.FromStream(new MemoryStream((byte[])vector.get_BinaryData()));
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("Tarayıcıya ulaşılamıyor. Cihazın açık ve kablolarının takılı olduğundan emin olun.", "Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                throw Ex;
            }
        }
        public static IEnumerable<Bitmap> Scan()
        {
            List<Bitmap> images = new List<Bitmap>();
            try
            {
                Initialize();
                /*
                SetProperty(PreparedScanner, "6151", 2400);  //Horizontal Scanning Area
                SetProperty(PreparedScanner, "6152", 3100);  //Vertical Scanning Area
                */
                WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
                WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(PreparedScanner, wiaFormatPNG, false);
                //WIA.ImageFile ImageX = (WIA.ImageFile)PreparedScanner.Transfer(wiaFormatBMP);
                //Vector vector = ImageX.FileData;

                //return Image.FromStream(new MemoryStream((byte[])vector.get_BinaryData()));
                Stream stream = new MemoryStream();
                stream.Write(image.FileData.get_BinaryData() as Byte[], 0, (image.FileData.get_BinaryData() as Byte[]).Length);

                // resetting stream position to beginning after data was written into it. 
                stream.Position = 0;
                Bitmap bitmap = new Bitmap(stream);
                images.Add(bitmap);
                return images;
            }
            catch (Exception Ex)
            {
                XtraMessageBox.Show("Tarayıcıya ulaşılamıyor. Cihazın açık ve kablolarının takılı olduğundan emin olun.", "Hata!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                throw Ex;
            }
        }

        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatPNG = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatGIF = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
        const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";
        //class WIA_DPS_DOCUMENT_HANDLING_SELECT
        //{
        //    public const uint FEEDER = 0x00000001;
        //    public const uint FLATBED = 0x00000002;
        //}

        //class WIA_DPS_DOCUMENT_HANDLING_STATUS
        //{
        //    public const uint FEED_READY = 0x00000001;
        //}

        //class WIA_PROPERTIES
        //{
        //    public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
        //    public const uint WIA_DIP_FIRST = 2;
        //    public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        //    public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        //    //
        //    // Scanner only device properties (DPS)
        //    //
        //    public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
        //    public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
        //    public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;
        //}

        ///// <summary>
        ///// Use scanner to scan an image (with user selecting the scanner from a dialog).
        ///// </summary>
        ///// <returns>Scanned images.</returns>
        //public static IEnumerable<Image> Scan()
        //{
        //    WIA.ICommonDialog dialog = new WIA.CommonDialog();
        //    WIA.Device device = dialog.ShowSelectDevice(WIA.WiaDeviceType.UnspecifiedDeviceType, true, false);

        //    if (device != null)
        //    {
        //        return Scan(device.DeviceID);
        //    }
        //    else
        //    {
        //        throw new Exception("You must select a device for scanning.");
        //    }
        //}

        ///// <summary>
        ///// Use scanner to scan an image (scanner is selected by its unique id).
        ///// </summary>
        ///// <param name="scannerName"></param>
        ///// <returns>Scanned images.</returns>
        //public static List<Image> Scan(string scannerId)
        //{
        //    List<Image> images = new List<Image>();

        //    bool hasMorePages = true;
        //    while (hasMorePages)
        //    {
        //        // select the correct scanner using the provided scannerId parameter
        //        WIA.DeviceManager manager = new WIA.DeviceManager();
        //        WIA.Device device = null;
        //        foreach (WIA.DeviceInfo info in manager.DeviceInfos)
        //        {
        //            if (info.DeviceID == scannerId)
        //            {
        //                // connect to scanner
        //                device = info.Connect();
        //                break;
        //            }
        //        }

        //        // device was not found
        //        if (device == null)
        //        {
        //            // enumerate available devices
        //            string availableDevices = "";
        //            foreach (WIA.DeviceInfo info in manager.DeviceInfos)
        //            {
        //                availableDevices += info.DeviceID + "\n";
        //            }

        //            // show error with available devices
        //            throw new Exception("The device with provided ID could not be found. Available Devices:\n" + availableDevices);
        //        }

        //        WIA.Item item = device.Items[1] as WIA.Item;

        //        try
        //        {
        //            // scan image
        //            WIA.ICommonDialog wiaCommonDialog = new WIA.CommonDialog();
        //            WIA.ImageFile image = (WIA.ImageFile)wiaCommonDialog.ShowTransfer(item, wiaFormatBMP, false);

        //            // save to temp file
        //            string fileName = Path.GetTempFileName();
        //            File.Delete(fileName);
        //            image.SaveFile(fileName);
        //            image = null;

        //            // add file to output list
        //            images.Add(Image.FromFile(fileName));
        //        }
        //        catch (Exception exc)
        //        {
        //            throw exc;
        //        }
        //        finally
        //        {
        //            item = null;

        //            //determine if there are any more pages waiting
        //            WIA.Property documentHandlingSelect = null;
        //            WIA.Property documentHandlingStatus = null;

        //            foreach (WIA.Property prop in device.Properties)
        //            {
        //                if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
        //                    documentHandlingSelect = prop;

        //                if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
        //                    documentHandlingStatus = prop;
        //            }

        //            // assume there are no more pages
        //            hasMorePages = false;

        //            // may not exist on flatbed scanner but required for feeder
        //            if (documentHandlingSelect != null)
        //            {
        //                // check for document feeder
        //                if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
        //                {
        //                    hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);
        //                }
        //            }
        //        }
        //    }

        //    return images;
        //}

        ///// <summary>
        ///// Gets the list of available WIA devices.
        ///// </summary>
        ///// <returns></returns>
        //public static List<string> GetDevices()
        //{
        //    List<string> devices = new List<string>();
        //    WIA.DeviceManager manager = new WIA.DeviceManager();

        //    foreach (WIA.DeviceInfo info in manager.DeviceInfos)
        //    {
        //        devices.Add(info.DeviceID);
        //    }

        //    return devices;
        //}

    }


}
