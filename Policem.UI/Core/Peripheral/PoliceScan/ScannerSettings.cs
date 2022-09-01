using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using WIA;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using Policem.UI.Properties;
using System.Drawing.Imaging;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;

namespace Policem.UI.Core.Peripheral.PoliceScan
{
    

}
    //public enum ScanningSize
    //{
    //    Letter,
    //    Legal
    //}

    //public enum Color
    //{
    //    GrayScale = 0,
    //    Color = 1,
    //    BlackWhite = 4
    //}

    //public class ScannerSettings : ISerializable
    //{
    //    #region Fields
    //    /// <summary>
    //    /// Width of the scanned image.
    //    /// Default is 8500. 
    //    /// </summary>
    //    private double _width = 8.5;

    //    /// <summary>
    //    /// Height of the scanned image.
    //    /// Default is 11000.
    //    /// </summary>
    //    private double _height = 11;

    //    /// <summary>
    //    /// Optical Resolution.
    //    /// </summary>
    //    private int _resolution = 120;

    //    /// <summary>
    //    /// Color setting, default is 0 - grayscale. 
    //    /// </summary>
    //    private int _color = 0; // grayscale

    //    /// <summary>
    //    /// Horizontal Cropping. 
    //    /// Default is 0.5 in
    //    /// </summary>
    //    private double _horizontalCrop = 0.5; // if cropping required it can be set in here for horizontal.

    //    /// <summary>
    //    /// Vertical Cropping
    //    /// Default is 0.5 in
    //    /// </summary>
    //    private double _verticalCrop = 0.5; // if cropping required it can be set in here for vertical.

    //    /// <summary>
    //    /// Standard scanning size
    //    /// </summary>
    //    private ScanningSize _size = ScanningSize.Letter;

    //    #endregion //Fields

    //    #region Constructors

    //    /// <summary>
    //    /// Default Constructor
    //    /// </summary>
    //    public ScannerSettings()
    //    {

    //    }

    //    /// <summary>
    //    /// Creates settings object for WIA scanner. 
    //    /// </summary>
    //    /// <param name="size">Standard paper size.</param>
    //    /// <param name="resolution">scanning resolution (e.g. for 300x300 pass 300).</param>
    //    /// <param name="color">Color setting, default is gray scale.</param>
    //    public ScannerSettings(ScanningSize size, int resolution, Color color)
    //    {

    //        Size = size;
    //        _color = (int)color;
    //        _resolution = resolution;
    //    }

    //    /// <summary>
    //    /// Creates settings object for WIA scanner and resolution of 150x150 pixels. 
    //    /// </summary>
    //    /// <param name="size">Standard paper size.</param>
    //    public ScannerSettings(ScanningSize size)
    //    {
    //        Size = size;
    //    }

    //    /// <summary>
    //    /// Creates customized settings for WIA scanner
    //    /// </summary>
    //    /// <param name="width">Scanner's sheet feed width.</param>
    //    /// <param name="height">Scanner's sheet feed height.</param>
    //    /// <param name="resolution">Optical resolution.</param>
    //    public ScannerSettings(double width, double height, int resolution, double horizontalCrop, double verticalCrop)
    //    {
    //        Width = width;
    //        Height = height;
    //        _resolution = resolution;
    //        _horizontalCrop = horizontalCrop;
    //        _verticalCrop = verticalCrop;
    //    }


    //    #endregion //Constructors

    //    #region Properties

    //    /// <summary>
    //    /// Color setting, default is 0 - grayscale. 
    //    /// </summary>
    //    public int Color
    //    {
    //        get
    //        {
    //            return _color;
    //        }
    //        set { _color = value; }
    //    }

    //    /// <summary>
    //    /// Height of the scanned image.
    //    /// Default is 11 in.
    //    /// </summary>
    //    public double Height
    //    {
    //        get
    //        {
    //            return _height;
    //        }
    //        set
    //        {
    //            _height = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Horizontal Cropping. 
    //    /// Default is 0.5 in.
    //    /// </summary>
    //    public double HorizontalCrop
    //    {
    //        get
    //        {
    //            return _horizontalCrop;
    //        }
    //        set
    //        {
    //            _horizontalCrop = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Optical Resolution. Default is 120 pixels per inch.
    //    /// </summary>
    //    public int Resolution
    //    {
    //        get
    //        {
    //            return _resolution;
    //        }
    //        set
    //        {
    //            _resolution = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Standard scanning size
    //    /// </summary>
    //    public ScanningSize Size
    //    {
    //        get
    //        {
    //            return _size;
    //        }
    //        set
    //        {
    //            _size = value;
    //            Width = GetWidth(_size);
    //            Height = GetHeight(_size);
    //        }
    //    }

    //    /// <summary>
    //    /// Vertical Cropping
    //    /// Default is 0.5 in.
    //    /// </summary>
    //    public double VerticalCrop
    //    {
    //        get
    //        {
    //            return _verticalCrop;
    //        }
    //        set
    //        {
    //            _verticalCrop = value;
    //        }
    //    }

    //    /// <summary>
    //    /// Width of the scanned image.
    //    /// Default is 8.5 in. 
    //    /// </summary>
    //    public double Width
    //    {
    //        get
    //        {
    //            return _width;
    //        }
    //        set
    //        {
    //            _width = value;
    //        }
    //    }
    //    #endregion //Properties

    //    #region Methods
    //    public static double GetWidth(ScanningSize size)
    //    {
    //        if (size == ScanningSize.Legal)
    //        {
    //            return 8.5;
    //        }
    //        else if (size == ScanningSize.Letter)
    //        {
    //            return 8.5;
    //        }
    //        else return 8.5;
    //    }

    //    public static double GetHeight(ScanningSize size)
    //    {
    //        if (size == ScanningSize.Legal)
    //        {
    //            return 14;
    //        }
    //        else if (size == ScanningSize.Letter)
    //        {
    //            return 11;
    //        }
    //        else return 11;
    //    }
    //    #endregion //Methods

    //    #region ISerializable Members

    //    /// <summary>
    //    /// Constructor for serializer.
    //    /// </summary>
    //    /// <param name="info">Serialization data.</param>
    //    /// <param name="context">Serialization streaming context.</param>
    //    public ScannerSettings(SerializationInfo info, StreamingContext context)
    //    {

    //        Color = info.GetInt32("Color");
    //        Height = info.GetDouble("Height");
    //        HorizontalCrop = info.GetDouble("HorizontalCrop");
    //        Resolution = info.GetInt32("Resolution");
    //        Nullable<ScanningSize> size = info.GetValue("Size", typeof(Nullable<ScanningSize>)) as Nullable<ScanningSize>;
    //        Size = ((size != null) ? size.Value : ScanningSize.Letter);
    //        VerticalCrop = info.GetDouble("VerticalCrop");
    //        Width = info.GetDouble("Width");
    //    }

    //    /// <summary>
    //    /// Implementation for ISerializable. 
    //    /// </summary>
    //    /// <param name="info">Serialization data.</param>
    //    /// <param name="context">Serialization streaming context.</param>
    //    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Color", Color);
    //        info.AddValue("Height", Height);
    //        info.AddValue("HorizontalCrop", HorizontalCrop);
    //        info.AddValue("Resolution", Resolution);
    //        Nullable<ScanningSize> size = Size;
    //        info.AddValue("Size", size);
    //        info.AddValue("VerticalCrop", VerticalCrop);
    //        info.AddValue("Width", Width);

    //    }

    //    #endregion
    //}

    //public class ImageScanner
    //{
    //    #region Fields 
    //    private Device _device = null;
    //    private ScannerSettings _scannerSettings;
    //    #endregion //Fields

    //    #region Constructors

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <exception cref="ImageScannerException">This exception can be thrown,
    //    /// if any errors are present while initializing scanner.</exception>
    //    public ImageScanner(ScannerSettings scannerSettings)
    //    {
    //        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

    //        if (scannerSettings == null)
    //            throw new ImageScannerException("Scanner Settings are not specified!");

    //        _scannerSettings = scannerSettings;

    //        Settings settings = new Settings();
    //        try
    //        {
    //            // try automatically select scanner.
    //            if (!String.IsNullOrEmpty(settings.DeviceId))
    //            {
    //                _device = GetDevice(settings.DeviceId);
    //            }

    //            // if didn't succeed try manually select scanner.
    //            if (_device == null)
    //            {
    //                _device = GetDevice(settings);
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            throw new ImageScannerException("Scanner was not selected or is not available!\n" + ex.Message);
    //        }

    //        // if device is still null, then throw an error. 
    //        if (_device == null)
    //            throw new ImageScannerException("Scanner was not selected or is not available!");

    //    }

    //    #endregion //Constructors

    //    #region Public Methods 

    //    public void SetDevice()
    //    {
    //        Settings settings = new Settings();
    //        _device = GetDevice(settings);
    //    }

    //    /// <summary>
    //    /// This will scan images, but everything must be ready before doing this. 
    //    /// If device (scanner) is not ready an ImageScannerException will be thrown. 
    //    /// </summary>
    //    /// <returns>Collection of scanned images.</returns>
    //    public IEnumerable<Bitmap> Scan()
    //    {
    //        List<Bitmap> images = new List<Bitmap>();

    //        if (_device == null)
    //            throw new ImageScannerException("Scanner is not available! Please select a scanner and try again.");

    //        WIA.Item item = null;
    //        try
    //        {
    //            foreach (DeviceCommand command in _device.Commands)
    //            {
    //                item = _device.ExecuteCommand(command.CommandID);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // skip this
    //        }

    //        try
    //        {
    //            // if item is still not initialized, we'll try a different approach
    //            if (item == null)
    //            {
    //                foreach (Item i in _device.Items)
    //                {
    //                    foreach (DeviceCommand command in i.Commands)
    //                    {
    //                        item = _device.ExecuteCommand(command.CommandID);
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            // skip this
    //        }

    //        try
    //        {
    //            // if item is still null, we'll pick the first available
    //            foreach (WIA.Item i in _device.Items)
    //            {
    //                item = i;
    //                break;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //skip this
    //        }

    //        if (item == null)
    //            throw new ImageScannerException("Scanner is not ready!\nPlease turn scanner on, feed paper into the scanner and try again.");
    //        try
    //        {
    //            // setting properties (dimensions and resolution of the scanning.)
    //            setItem(item, "6146", _scannerSettings.Color); // color setting (default is gray scale)
    //            setItem(item, "6147", _scannerSettings.Resolution); //horizontal resolution
    //            setItem(item, "6148", _scannerSettings.Resolution); // vertical resolution
    //            setItem(item, "6149", _scannerSettings.HorizontalCrop); // horizontal starting position
    //            setItem(item, "6150", _scannerSettings.VerticalCrop); // vertical starting position
    //            setItem(item, "6151", (int)((double)_scannerSettings.Resolution * (_scannerSettings.Width - _scannerSettings.HorizontalCrop)));  // width
    //            setItem(item, "6152", (int)((double)_scannerSettings.Resolution * (_scannerSettings.Height - _scannerSettings.VerticalCrop))); // height
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new ImageScannerException("Was not able to set scanning parameters.\n" + ex.Message);
    //        }

    //        // if we reached this point, then scanner is probably initialized. 
    //        bool isTransferring = true;
    //        foreach (string format in item.Formats)
    //        {
    //            while (isTransferring)
    //            {
    //                try
    //                {
    //                    WIA.ImageFile file = (item.Transfer(format)) as WIA.ImageFile;
    //                    if (file != null)
    //                    {
    //                        Stream stream = new MemoryStream();
    //                        stream.Write(file.FileData.get_BinaryData() as Byte[], 0, (file.FileData.get_BinaryData() as Byte[]).Length);

    //                        // resetting stream position to beginning after data was written into it. 
    //                        stream.Position = 0;
    //                        Bitmap bitmap = new Bitmap(stream);
    //                        images.Add(bitmap);
    //                    }
    //                    else
    //                        isTransferring = false; // something happend and we didn't get image
    //                }
    //                catch (Exception ex)
    //                {
    //                    // most likely done transferring
    //                    // I was not able to find a way to pole scanner for paper feed status. 
    //                    isTransferring = false;

    //                    // scanner's paper feeder was not loaded with paper.
    //                    if (images.Count() == 0)
    //                        throw new ImageScannerException("Scanner is not loaded with paper or not ready.");

    //                }
    //            }
    //        }

    //        return images;
    //    }

    //    #endregion //Public Methods

    //    #region Private Methods

    //    private void setItem(IItem item, object property, object value)
    //    {
    //        WIA.Property aProperty = item.Properties.get_Item(ref property);
    //        aProperty.set_Value(ref value);
    //    }

    //    private Device GetDevice(Settings settings)
    //    {
    //        Device device = null;
    //        CommonDialog dialog = new CommonDialog();
    //        if (String.IsNullOrEmpty(settings.DeviceId))
    //        {
    //            device = dialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, false);
    //            if (device != null)
    //            {
    //                settings.DeviceId = device.DeviceID;
    //                settings.Save();
    //            }
    //        }
    //        return device;
    //    }

    //    private Device GetDevice(string deviceId)
    //    {
    //        WIA.DeviceManager manager = new DeviceManager();
    //        Device device = null;
    //        foreach (DeviceInfo info in manager.DeviceInfos)
    //        {
    //            if (info.DeviceID == deviceId)
    //            {
    //                device = info.Connect();
    //                break;
    //            }
    //        }
    //        return device;
    //    }
    //    #endregion //Private Methods
    //}

    //public class ImageScannerException : Exception, ISerializable
    //{
    //    #region Properties

    //    public string UserFriendlyMessage { get; private set; }

    //    #endregion //Properties

    //    #region Constructors

    //    /// <summary>
    //    /// All messages are set to String.Empty.
    //    /// </summary>
    //    public ImageScannerException()
    //        : base(String.Empty)
    //    {
    //        UserFriendlyMessage = String.Empty;
    //    }

    //    /// <summary>
    //    /// UserFriendlyMessage is set to message.
    //    /// </summary>
    //    /// <param name="message">Error message.</param>
    //    public ImageScannerException(string message)
    //        : base(message)
    //    {
    //        UserFriendlyMessage = message;
    //    }

    //    /// <summary>
    //    /// UserFriendlyMessage is set to message. 
    //    /// </summary>
    //    /// <param name="message">Error Message</param>
    //    /// <param name="innerException">Inner Exception if any, null otherwise. </param>
    //    public ImageScannerException(string message, Exception innerException)
    //        : base(message, innerException)
    //    {
    //        UserFriendlyMessage = message;
    //    }

    //    /// <summary>
    //    /// Custom exception for ImageScanner.
    //    /// </summary>
    //    /// <param name="message">Detailed error message.</param>
    //    /// <param name="userFriendlyMessage">User friendly error message.</param>
    //    public ImageScannerException(string message, string userFriendlyMessage)
    //        : base(message)
    //    {
    //        UserFriendlyMessage = userFriendlyMessage;
    //    }

    //    /// <summary>
    //    /// Custom exception for ImageScanner.
    //    /// </summary>
    //    /// <param name="message">Detailed error message.</param>
    //    /// <param name="innerException">Inner Exception if any, null otherwise. 
    //    /// (If inner exception is null use different overloaded constructor)</param>
    //    /// <param name="userFriendlyMessage">User friendly error message.</param>
    //    public ImageScannerException(string message, Exception innerException, string userFriendlyMessage)
    //        : base(message, innerException)
    //    {
    //        UserFriendlyMessage = userFriendlyMessage;
    //    }

    //    /// <summary>
    //    /// Custom exception for ImageScanner.
    //    /// </summary>
    //    /// <param name="info">Serialization data.</param>
    //    /// <param name="context">Serialization streaming context.</param>
    //    public ImageScannerException(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //        UserFriendlyMessage = info.GetString("UserFriendlyMessage");
    //    }

    //    #endregion //Constructors

    //    #region Methods

    //    /// <summary>
    //    /// Implementation for ISerializable. 
    //    /// </summary>
    //    /// <param name="info">Serialization data.</param>
    //    /// <param name="context">Serialization streaming context.</param>
    //    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    //    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        base.GetObjectData(info, context);
    //        info.AddValue("UserFriendlyMessage", UserFriendlyMessage);
    //    }

    //    #endregion //Methods
    //}

    //public class ScannerHelper
    //{
    //    public ScannerSettings ScannerSettings { get; set; }
    //    public PdfSettings PdfSettings { get; set; }

    //    /// <summary>
    //    /// Constructor with default settings. 
    //    /// </summary>
    //    public ScannerHelper()
    //    {
    //        ScannerSettings = new ScannerSettings(ScanningSize.Letter, 120, Color.BlackWhite);
    //        PdfSettings = new PdfSettings(PdfOrientation.Portrait, PdfSize.Letter);
    //    }

    //    /// <summary>
    //    /// Customizable constructor
    //    /// </summary>
    //    /// <param name="scannerSettings">Settings for the scanner.</param>
    //    /// <param name="pdfSettings">Settings for PDF page(s).</param>
    //    public ScannerHelper(ScannerSettings scannerSettings, PdfSettings pdfSettings)
    //    {
    //        ScannerSettings = scannerSettings;
    //        PdfSettings = pdfSettings;
    //    }

    //    public void ScanToPdf(string newPdfFileName)
    //    {
    //        ImageScanner scanner = new ImageScanner(ScannerSettings);
    //        PdfConverter converter = new PdfConverter(PdfSettings);

    //        converter.SaveFrom(scanner.Scan(), newPdfFileName);
    //    }

    //    /// <summary>
    //    /// This method scans to Pdf Stream. 
    //    /// </summary>
    //    /// <returns>Return open stream with PDF binary data in it. The stream needs to be flushed and closed after use.</returns>
    //    public Stream ScanToPdf()
    //    {
    //        ImageScanner scanner = new ImageScanner(ScannerSettings);
    //        PdfConverter converter = new PdfConverter(PdfSettings);

    //        return converter.ConvertFrom(scanner.Scan());
    //    }
    //}
    //public class PdfConverter
    //{
    //    PdfSettings _settings;

    //    /// <summary>
    //    /// Default constructor. 
    //    /// </summary>
    //    public PdfConverter()
    //    {
    //        _settings = new PdfSettings(PdfOrientation.Portrait, PdfSize.Letter);
    //    }

    //    /// <summary>
    //    /// Creates instance for PdfConverter for various convert options. 
    //    /// </summary>
    //    /// <param name="settings">Pdf export settings, related to pages sizes.
    //    /// If settings is null, we use default settings.</param>
    //    public PdfConverter(PdfSettings settings)
    //    {
    //        if (settings == null)
    //            settings = new PdfSettings(PdfOrientation.Portrait, PdfSize.Letter);

    //        _settings = settings;
    //    }

    //    /// <summary>
    //    /// Convert to a Stream containing Pdf binary data from a list of images. 
    //    /// </summary>
    //    /// <param name="images">List of images.</param>
    //    /// <exception cref="PdfConverterException">This exception could be thrown if conversion fails.
    //    /// Usually due to file size is too large.</exception>
    //    /// <returns>Open stream with position set to 0 (beginning). 
    //    /// Stream can be read, but needs to be flushed and closed when done.</returns>
    //    public Stream ConvertFrom(IEnumerable<Bitmap> images)
    //    {
    //        Stream resultStream = new MemoryStream();
    //        Stream outStream = ConvertTo(images, resultStream);
    //        outStream.Position = 0;
    //        return outStream;
    //    }

    //    /// <summary>
    //    /// Convert to a Stream containing Pdf binary data from a single image. 
    //    /// </summary>
    //    /// <param name="image">Instance of Bitmap image.</param>
    //    /// <exception cref="PdfConverterException">This exception could be thrown if conversion fails.
    //    /// Usually due to file size is too large.</exception>
    //    /// <returns>Open stream with position set to 0 (beginning). 
    //    /// Stream can be read, but needs to be flushed and closed when done.</returns>
    //    public Stream ConvertFrom(Bitmap image)
    //    {
    //        Stream resultStream = new MemoryStream();
    //        List<Bitmap> images = new List<Bitmap>();
    //        images.Add(image);
    //        Stream outStream = ConvertTo(images, resultStream);
    //        outStream.Position = 0;
    //        return outStream;
    //    }

    //    /// <summary>
    //    /// Saves list of images into specified pdf file.
    //    /// If file already exists, it will be deleted. 
    //    /// </summary>
    //    /// <param name="images">List of images.</param>
    //    /// <param name="pdfFilePath">Pdf file path where images will be saved. If file exists it will be deleted.</param>
    //    public void SaveFrom(IEnumerable<Bitmap> images, string pdfFilePath)
    //    {
    //        if (File.Exists(pdfFilePath)) //--------> iam getting exception here
    //            File.Delete(pdfFilePath);

    //        Stream resultStream = new FileStream(pdfFilePath, FileMode.OpenOrCreate);
    //        Stream stream = ConvertTo(images, resultStream);
    //        stream.Flush();
    //        stream.Close();
    //    }

    //    /// <summary>
    //    /// Saves image into specified pdf file.
    //    /// If file already exists, it will be deleted. 
    //    /// </summary>
    //    /// <param name="image">Instance of Bitmap image.</param>
    //    /// <param name="pdfFilePath">Pdf file path where image will be saved. If file exists it will be deleted.</param>
    //    public void SaveFrom(Bitmap image, string pdfFilePath)
    //    {
    //        if (File.Exists(pdfFilePath))
    //            File.Delete(pdfFilePath);

    //        if (image == null)
    //            throw new PdfConverterException("No images to convert!");

    //        Stream resultStream = new FileStream(pdfFilePath, FileMode.OpenOrCreate);
    //        List<Bitmap> images = new List<Bitmap>();
    //        images.Add(image);
    //        Stream stream = ConvertTo(images, resultStream);
    //        stream.Flush();
    //        stream.Close();
    //    }

    //    private Stream ConvertTo(IEnumerable<Bitmap> images, Stream resultStream)
    //    {
    //        if (images == null && images.Count() == 0)
    //            throw new PdfConverterException("No images to convert!");

    //        // creating in-memory report
    //        XDocument reportXML = CreateRDLC(images);
    //        Stream stream = new MemoryStream();
    //        XmlWriter writer = XmlWriter.Create(stream);
    //        reportXML.Save(writer);

    //        //disposing
    //        writer.Flush();
    //        writer.Close();

    //        LocalReport report = new LocalReport();
    //        stream.Position = 0;
    //        report.LoadReportDefinition(stream);

    //        //disposing
    //        stream.Flush();
    //        stream.Close();

    //        String mimeType = "";
    //        String encoding = "";
    //        String[] streams;
    //        Warning[] warnings;
    //        Byte[] renderedBytes;
    //        StringBuilder deviceInfo = new StringBuilder();
    //        String fileExtension;
    //        deviceInfo.Append("<DeviceInfo>");
    //        deviceInfo.Append("  <OutputFormat>PDF</OutputFormat>");
    //        deviceInfo.Append("</DeviceInfo>");

    //        report.Refresh();
    //        renderedBytes = report.Render("PDF", deviceInfo.ToString(), out mimeType, out encoding, out fileExtension, out streams, out warnings);

    //        resultStream.Write(renderedBytes, 0, renderedBytes.Length);
    //        return resultStream;
    //    }

    //    private XDocument CreateRDLC(IEnumerable<Bitmap> images)
    //    {
    //        int i = 0;
    //        XNamespace rd = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";
    //        XNamespace xmlns = "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition";
    //        XDocument doc = new XDocument(
    //            new XDeclaration("1.0", "utf-8", "no"),
    //            new XElement(xmlns + "Report",
    //                new XAttribute(XNamespace.Xmlns + "rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner"),
    //                new XElement(xmlns + "InteractiveHeight", _settings.HeightLabel),
    //                new XElement(xmlns + "InteractiveWidth", _settings.WidthLabel),
    //                new XElement(xmlns + "RightMargin", _settings.RightMarginLabel),
    //                new XElement(xmlns + "LeftMargin", _settings.LeftMarginLabel),
    //                new XElement(xmlns + "BottomMargin", _settings.BottomMarginLabel),
    //                new XElement(xmlns + "TopMargin", _settings.TopMarginLabel),
    //                new XElement(xmlns + "Width", _settings.BodyWidthLabel),
    //                new XElement(rd + "SnapToGrid", "true"),
    //                new XElement(rd + "DrawGrid", "true"),
    //                new XElement(rd + "ReportId", (new Guid()).ToString()),
    //                new XElement(xmlns + "EmbeddedImages",
    //                    from Bitmap image in images
    //                    select new XElement(xmlns + "EmbeddedImage",
    //                        new XAttribute("Name", "i" + image.GetHashCode().ToString()),
    //                        new XElement(xmlns + "MIMEType", "image/jpeg"),
    //                        new XElement(xmlns + "ImageData", BitmapToByte(image)))

    //                    ),
    //                new XElement(xmlns + "Body",
    //                    new XElement(xmlns + "ReportItems",
    //                        from Bitmap image in images
    //                        select
    //                            new XElement(xmlns + "Image",
    //                                new XAttribute("Name", "ImageName" + image.GetHashCode().ToString()),
    //                                new XElement(xmlns + "Sizing", "FitProportional"),
    //                                new XElement(xmlns + "Height", _settings.BodyHeightLabel),
    //                                new XElement(xmlns + "Top", ((i++) * _settings.BodyHeight).ToString() + "in"),
    //                                new XElement(xmlns + "MIMEType", "image/jpeg"),
    //                                new XElement(xmlns + "Source", "Embedded"),
    //                                new XElement(xmlns + "Style"),
    //                                new XElement(xmlns + "ZIndex", 1),
    //                                new XElement(xmlns + "Value", "i" + image.GetHashCode().ToString()))
    //                    ),
    //                    new XElement(xmlns + "Height", _settings.BodyHeightLabel)
    //                ),
    //                new XElement(xmlns + "Language", "en-US")
    //            )
    //        );
    //        return doc;
    //    }

    //    private String BitmapToByte(Bitmap image)
    //    {
    //        String result = String.Empty;

    //        // the file size is limited here to .NET 128 MB per array per ApplicationDomain. 
    //        // so if image file is close or greater than 128 MB this will fail. 
    //        try
    //        {
    //            Stream str = new MemoryStream();
    //            image.Save(str, ImageFormat.Jpeg);
    //            Byte[] output = new Byte[str.Length];
    //            str.Position = 0;
    //            str.Read(output, 0, (int)str.Length);
    //            result = Convert.ToBase64String(output, Base64FormattingOptions.None);
    //            str.Flush();
    //            str.Close();
    //        }
    //        catch (OutOfMemoryException ex)
    //        {
    //            throw new PdfConverterException(ex.Message, ex, "The file size is too large. It is limited to 128 MB. Try smaller image.");
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new PdfConverterException(ex.Message, ex);
    //        }
    //        return result;
    //    }
    //}

    //public class PdfConverterException : Exception, ISerializable
    //{
    //    #region Properties

    //    public string UserFriendlyMessage { get; private set; }

    //    #endregion //Properties 

    //    #region Constructors

    //    /// <summary>
    //    /// All messages are set to String.Empty.
    //    /// </summary>
    //    public PdfConverterException()
    //        : base(String.Empty)
    //    {
    //        UserFriendlyMessage = String.Empty;
    //    }

    //    /// <summary>
    //    /// UserFriendlyMessage is set to message.
    //    /// </summary>
    //    /// <param name="message">Error message.</param>
    //    public PdfConverterException(string message)
    //        : base(message)
    //    {
    //        UserFriendlyMessage = message;
    //    }

    //    /// <summary>
    //    /// UserFriendlyMessage is set to message. 
    //    /// </summary>
    //    /// <param name="message">Error Message</param>
    //    /// <param name="innerException">Inner Exception if any, null otherwise. </param>
    //    public PdfConverterException(string message, Exception innerException)
    //        : base(message, innerException)
    //    {
    //        UserFriendlyMessage = message;
    //    }

    //    /// <summary>
    //    /// Custom exception for PdfConverter.
    //    /// </summary>
    //    /// <param name="message">Detailed error message.</param>
    //    /// <param name="userFriendlyMessage">User friendly error message.</param>
    //    public PdfConverterException(string message, string userFriendlyMessage)
    //        : base(message)
    //    {
    //        UserFriendlyMessage = userFriendlyMessage;
    //    }

    //    /// <summary>
    //    /// Custom exception for PdfConverter.
    //    /// </summary>
    //    /// <param name="message">Detailed error message.</param>
    //    /// <param name="innerException">Inner Exception if any, null otherwise. 
    //    /// (If inner exception is null use different overloaded constructor)</param>
    //    /// <param name="userFriendlyMessage">User friendly error message.</param>
    //    public PdfConverterException(string message, Exception innerException, string userFriendlyMessage)
    //        : base(message, innerException)
    //    {
    //        UserFriendlyMessage = userFriendlyMessage;
    //    }

    //    /// <summary>
    //    /// Custom exception for PdfConverter.
    //    /// </summary>
    //    /// <param name="info">Serialization data.</param>
    //    /// <param name="context">Serialization streaming context.</param>
    //    public PdfConverterException(SerializationInfo info, StreamingContext context)
    //        : base(info, context)
    //    {
    //        UserFriendlyMessage = info.GetString("UserFriendlyMessage");
    //    }

    //    #endregion //Constructors 

    //    #region Methods

    //    /// <summary>
    //    /// Implementation for ISerializable. 
    //    /// </summary>
    //    /// <param name="info">Serialization data.</param>
    //    /// <param name="context">Serialization streaming context.</param>
    //    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    //    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        base.GetObjectData(info, context);
    //        info.AddValue("UserFriendlyMessage", UserFriendlyMessage);
    //    }

    //    #endregion //Methods 

    //}