using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Reporting.WinForms;

namespace Policem.UI.Core.Peripheral.PoliceScan
{
    public enum PdfOrientation
    {
        Portrait,
        Landscape
    }

    public enum PdfSize
    {
        Letter,
        Legal
    }

    public class PdfSettings
    {

        #region Fields

        /// <summary>
        /// width for pdf export in inches
        /// </summary>
        private double _width = 8.5;

        /// <summary>
        /// height for pdf export in inches
        /// </summary>
        private double _height = 11;

        /// <summary>
        /// Left margin.
        /// by default we set it to 0.5 inches
        /// </summary>
        private double _leftMargin = 0.5;

        /// <summary>
        /// Right margin.
        /// by default we set it to 0.5 inches
        /// </summary>
        private double _rightMargin = 0.5;

        /// <summary>
        /// Top margin.
        /// by default we set it to 0.5 inches
        /// </summary>
        private double _topMargin = 0.5;

        /// <summary>
        /// Bottom margin.
        /// by default we set it to 0.5 inches
        /// </summary>
        private double _bottomMargin = 0.5;

        /// <summary>
        /// Size of PDF output pages. 
        /// </summary>
        private PdfSize _size;

        /// <summary>
        /// Orientation of PDF output pages. 
        /// </summary>
        private PdfOrientation _orientation;

        #endregion //Fields

        #region Constructors

        /// <summary>
        /// Constructor which creates custom settings. 
        /// Margins can be set separate in Properties. 
        /// Default margins are 0.5 in. 
        /// </summary>
        /// <param name="width">Width in inches.</param>
        /// <param name="height">Height in inches.</param>
        public PdfSettings(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor accepts standard settings. 
        /// </summary>
        /// <param name="orientation">Page orientation.</param>
        /// <param name="size">Page size. </param>
        public PdfSettings(PdfOrientation orientation, PdfSize size)
        {
            Orientation = orientation;
            Size = size;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PdfSettings()
        {
        }

        #endregion //Constructors

        #region Properties


        /// <summary>
        /// Bottom margin.
        /// by default it is set to 0.5 inches.
        /// If bottom and top margins are greater then height, then they are set to default.
        /// </summary>
        public double BottomMargin
        {
            get
            {
                return _bottomMargin;
            }
            set
            {
                if (value + _topMargin > Height)
                {
                    _bottomMargin = 0.5;
                    _topMargin = 0.5;
                }
                else
                    _bottomMargin = value;
            }
        }

        /// <summary>
        /// Formatted label for Margin value;
        /// </summary>
        public string BottomMarginLabel
        {
            get { return BottomMargin.ToString("00.00") + "in"; }
        }

        /// <summary>
        /// height for pdf export in inches
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Left margin.
        /// by default it is set to 0.5 inches.
        /// If Right and Left margins are greater then width, then they are set to default.
        /// </summary>
        public double LeftMargin
        {
            get
            {
                return _leftMargin;
            }
            set
            {
                if (value + _rightMargin > Width)
                {
                    _leftMargin = 0.5;
                    _rightMargin = 0.5;
                }
                else
                    _leftMargin = value;
            }
        }

        /// <summary>
        /// Formatted label for Margin value;
        /// </summary>
        public string LeftMarginLabel
        {
            get { return LeftMargin.ToString("00.00") + "in"; }
        }

        /// <summary>
        /// Orientation of PDF output pages. 
        /// </summary>
        public PdfOrientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;

                if (_orientation == PdfOrientation.Landscape)
                {
                    if (Size == PdfSize.Legal)
                    {
                        Height = 8.5;
                        Width = 14;
                    }
                    else if (Size == PdfSize.Letter)
                    {
                        Height = 8.5;
                        Width = 11;
                    }
                }
                else
                {
                    if (Size == PdfSize.Legal)
                    {
                        Height = 14;
                        Width = 8.5;
                    }
                    else if (Size == PdfSize.Letter)
                    {
                        Height = 11;
                        Width = 8.5;
                    }
                }
            }
        }

        /// <summary>
        /// Right margin.
        /// by default it is set to 0.5 inches.
        /// If Right and Left margins are greater then width, then they are set to default.
        /// </summary>
        public double RightMargin
        {
            get
            {
                return _rightMargin;
            }
            set
            {
                if (value + _leftMargin > Width)
                {
                    _leftMargin = 0.5;
                    _rightMargin = 0.5;
                }
                else
                    _rightMargin = value;
            }
        }

        /// <summary>
        /// Formatted label for Margin value;
        /// </summary>
        public string RightMarginLabel
        {
            get { return RightMargin.ToString("00.00") + "in"; }
        }

        /// <summary>
        /// Size of PDF output pages. 
        /// </summary>
        public PdfSize Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;

                if (_orientation == PdfOrientation.Landscape)
                {
                    if (Size == PdfSize.Legal)
                    {
                        Height = 8.5;
                        Width = 14;
                    }
                    else if (Size == PdfSize.Letter)
                    {
                        Height = 8.5;
                        Width = 11;
                    }
                }
                else
                {
                    if (Size == PdfSize.Legal)
                    {
                        Height = 14;
                        Width = 8.5;
                    }
                    else if (Size == PdfSize.Letter)
                    {
                        Height = 11;
                        Width = 8.5;
                    }
                }
            }
        }

        /// <summary>
        /// Top margin.
        /// by default it is set to 0.5 inches.
        /// If bottom and top margins are greater then height, then they are set to default.
        /// </summary>
        public double TopMargin
        {
            get
            {
                return _topMargin;
            }
            set
            {
                if (value + _bottomMargin > Height)
                {
                    _bottomMargin = 0.5;
                    _topMargin = 0.5;
                }
                else
                    _topMargin = value;
            }
        }

        /// <summary>
        /// Formatted label for Margin value;
        /// </summary>
        public string TopMarginLabel
        {
            get { return TopMargin.ToString("00.00") + "in"; }
        }

        /// <summary>
        /// width for pdf export in inches
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// width for pdf export in inches
        /// </summary>
        public string WidthLabel
        {
            get
            {
                return Width.ToString("00.00") + "in";
            }
        }

        /// <summary>
        /// height for pdf export in inches
        /// </summary>
        public string HeightLabel
        {
            get
            {
                return Height.ToString("00.00") + "in";
            }
        }

        /// <summary>
        /// Returns formatted height of the pdf body = (height - top and bottom margins).
        /// </summary>
        public string BodyHeightLabel
        {
            get { return (Height - _topMargin - _bottomMargin).ToString("00.00") + "in"; }
        }

        /// <summary>
        /// Returns height of the pdf body = (height - top and bottom margins).
        /// </summary>
        public double BodyHeight
        {
            get { return (Height - _topMargin - _bottomMargin); }
        }

        /// <summary>
        /// Returns formatted width of the pdf body = (width - left and right margins).
        /// </summary>
        public string BodyWidthLabel
        {
            get { return (Width - _leftMargin - _rightMargin).ToString("00.00") + "in"; }
        }

        /// <summary>
        /// Returns width of the pdf body = (width - left and right margins).
        /// </summary>
        public double BodyWidth
        {
            get { return (Width - _leftMargin - _rightMargin); }
        }


        #endregion //Properties
    }
    public class PdfConverterException : Exception, ISerializable
    {
        #region Properties

        public string UserFriendlyMessage { get; private set; }

        #endregion //Properties 

        #region Constructors

        /// <summary>
        /// All messages are set to String.Empty.
        /// </summary>
        public PdfConverterException()
            : base(String.Empty)
        {
            UserFriendlyMessage = String.Empty;
        }

        /// <summary>
        /// UserFriendlyMessage is set to message.
        /// </summary>
        /// <param name="message">Error message.</param>
        public PdfConverterException(string message)
            : base(message)
        {
            UserFriendlyMessage = message;
        }

        /// <summary>
        /// UserFriendlyMessage is set to message. 
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="innerException">Inner Exception if any, null otherwise. </param>
        public PdfConverterException(string message, Exception innerException)
            : base(message, innerException)
        {
            UserFriendlyMessage = message;
        }

        /// <summary>
        /// Custom exception for PdfConverter.
        /// </summary>
        /// <param name="message">Detailed error message.</param>
        /// <param name="userFriendlyMessage">User friendly error message.</param>
        public PdfConverterException(string message, string userFriendlyMessage)
            : base(message)
        {
            UserFriendlyMessage = userFriendlyMessage;
        }

        /// <summary>
        /// Custom exception for PdfConverter.
        /// </summary>
        /// <param name="message">Detailed error message.</param>
        /// <param name="innerException">Inner Exception if any, null otherwise. 
        /// (If inner exception is null use different overloaded constructor)</param>
        /// <param name="userFriendlyMessage">User friendly error message.</param>
        public PdfConverterException(string message, Exception innerException, string userFriendlyMessage)
            : base(message, innerException)
        {
            UserFriendlyMessage = userFriendlyMessage;
        }

        /// <summary>
        /// Custom exception for PdfConverter.
        /// </summary>
        /// <param name="info">Serialization data.</param>
        /// <param name="context">Serialization streaming context.</param>
        public PdfConverterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            UserFriendlyMessage = info.GetString("UserFriendlyMessage");
        }

        #endregion //Constructors 

        #region Methods

        /// <summary>
        /// Implementation for ISerializable. 
        /// </summary>
        /// <param name="info">Serialization data.</param>
        /// <param name="context">Serialization streaming context.</param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("UserFriendlyMessage", UserFriendlyMessage);
        }

        #endregion //Methods 

    }
    public class PdfConverter
    {
        PdfSettings _settings;

        /// <summary>
        /// Default constructor. 
        /// </summary>
        public PdfConverter()
        {
            _settings = new PdfSettings(PdfOrientation.Portrait, PdfSize.Letter);
        }

        /// <summary>
        /// Creates instance for PdfConverter for various convert options. 
        /// </summary>
        /// <param name="settings">Pdf export settings, related to pages sizes.
        /// If settings is null, we use default settings.</param>
        public PdfConverter(PdfSettings settings)
        {
            if (settings == null)
                settings = new PdfSettings(PdfOrientation.Portrait, PdfSize.Letter);

            _settings = settings;
        }

        /// <summary>
        /// Convert to a Stream containing Pdf binary data from a list of images. 
        /// </summary>
        /// <param name="images">List of images.</param>
        /// <exception cref="PdfConverterException">This exception could be thrown if conversion fails.
        /// Usually due to file size is too large.</exception>
        /// <returns>Open stream with position set to 0 (beginning). 
        /// Stream can be read, but needs to be flushed and closed when done.</returns>
        public Stream ConvertFrom(IEnumerable<Bitmap> images)
        {
            Stream resultStream = new MemoryStream();
            Stream outStream = ConvertTo(images, resultStream);
            outStream.Position = 0;
            return outStream;
        }

        /// <summary>
        /// Convert to a Stream containing Pdf binary data from a single image. 
        /// </summary>
        /// <param name="image">Instance of Bitmap image.</param>
        /// <exception cref="PdfConverterException">This exception could be thrown if conversion fails.
        /// Usually due to file size is too large.</exception>
        /// <returns>Open stream with position set to 0 (beginning). 
        /// Stream can be read, but needs to be flushed and closed when done.</returns>
        public Stream ConvertFrom(Bitmap image)
        {
            Stream resultStream = new MemoryStream();
            List<Bitmap> images = new List<Bitmap>();
            images.Add(image);
            Stream outStream = ConvertTo(images, resultStream);
            outStream.Position = 0;
            return outStream;
        }

        /// <summary>
        /// Saves list of images into specified pdf file.
        /// If file already exists, it will be deleted. 
        /// </summary>
        /// <param name="images">List of images.</param>
        /// <param name="pdfFilePath">Pdf file path where images will be saved. If file exists it will be deleted.</param>
        public void SaveFrom(IEnumerable<Bitmap> images, string pdfFilePath)
        {
            if (File.Exists(pdfFilePath))
                File.Delete(pdfFilePath);

            Stream resultStream = new FileStream(pdfFilePath, FileMode.OpenOrCreate);
            Stream stream = ConvertTo(images, resultStream);
            stream.Flush();
            stream.Close();
        }

        /// <summary>
        /// Saves image into specified pdf file.
        /// If file already exists, it will be deleted. 
        /// </summary>
        /// <param name="image">Instance of Bitmap image.</param>
        /// <param name="pdfFilePath">Pdf file path where image will be saved. If file exists it will be deleted.</param>
        public void SaveFrom(Bitmap image, string pdfFilePath)
        {
            if (File.Exists(pdfFilePath))
                File.Delete(pdfFilePath);

            if (image == null)
                throw new PdfConverterException("No images to convert!");

            Stream resultStream = new FileStream(pdfFilePath, FileMode.OpenOrCreate);
            List<Bitmap> images = new List<Bitmap>();
            images.Add(image);
            Stream stream = ConvertTo(images, resultStream);
            stream.Flush();
            stream.Close();
        }

        private Stream ConvertTo(IEnumerable<Bitmap> images, Stream resultStream)
        {
            if (images == null || images.Count() == 0)
                throw new PdfConverterException("No images to convert!");

            // creating in-memory report
            XDocument reportXML = CreateRDLC(images);
            Stream stream = new MemoryStream();
            XmlWriter writer = XmlWriter.Create(stream);
            reportXML.Save(writer);

            //disposing
            writer.Flush();
            writer.Close();

            LocalReport report = new LocalReport();
            stream.Position = 0;
            report.LoadReportDefinition(stream);

            //disposing
            stream.Flush();
            stream.Close();

            String mimeType = "";
            String encoding = "";
            String[] streams;
            Warning[] warnings;
            Byte[] renderedBytes;
            StringBuilder deviceInfo = new StringBuilder();
            String fileExtension;
            deviceInfo.Append("<DeviceInfo>");
            deviceInfo.Append("  <OutputFormat>PDF</OutputFormat>");
            deviceInfo.Append("</DeviceInfo>");

            report.Refresh();
            renderedBytes = report.Render("PDF", deviceInfo.ToString(), out mimeType, out encoding, out fileExtension, out streams, out warnings);

            resultStream.Write(renderedBytes, 0, renderedBytes.Length);
            return resultStream;
        }

        private XDocument CreateRDLC(IEnumerable<Bitmap> images)
        {
            int i = 0;
            XNamespace rd = "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner";
            XNamespace xmlns = "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition";
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XElement(xmlns + "Report",
                    new XAttribute(XNamespace.Xmlns + "rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner"),
                    new XElement(xmlns + "InteractiveHeight", _settings.HeightLabel),
                    new XElement(xmlns + "InteractiveWidth", _settings.WidthLabel),
                    new XElement(xmlns + "RightMargin", _settings.RightMarginLabel),
                    new XElement(xmlns + "LeftMargin", _settings.LeftMarginLabel),
                    new XElement(xmlns + "BottomMargin", _settings.BottomMarginLabel),
                    new XElement(xmlns + "TopMargin", _settings.TopMarginLabel),
                    new XElement(xmlns + "Width", _settings.BodyWidthLabel),
                    new XElement(rd + "SnapToGrid", "true"),
                    new XElement(rd + "DrawGrid", "true"),
                    new XElement(rd + "ReportId", (new Guid()).ToString()),
                    new XElement(xmlns + "EmbeddedImages",
                        from Bitmap image in images
                        select new XElement(xmlns + "EmbeddedImage",
                            new XAttribute("Name", "i" + image.GetHashCode().ToString()),
                            new XElement(xmlns + "MIMEType", "image/jpeg"),
                            new XElement(xmlns + "ImageData", BitmapToByte(image)))

                        ),
                    new XElement(xmlns + "Body",
                        new XElement(xmlns + "ReportItems",
                            from Bitmap image in images
                            select
                                new XElement(xmlns + "Image",
                                    new XAttribute("Name", "ImageName" + image.GetHashCode().ToString()),
                                    new XElement(xmlns + "Sizing", "FitProportional"),
                                    new XElement(xmlns + "Height", _settings.BodyHeightLabel),
                                    new XElement(xmlns + "Top", ((i++) * _settings.BodyHeight).ToString() + "in"),
                                    new XElement(xmlns + "MIMEType", "image/jpeg"),
                                    new XElement(xmlns + "Source", "Embedded"),
                                    new XElement(xmlns + "Style"),
                                    new XElement(xmlns + "ZIndex", 1),
                                    new XElement(xmlns + "Value", "i" + image.GetHashCode().ToString()))
                        ),
                        new XElement(xmlns + "Height", _settings.BodyHeightLabel)
                    ),
                    new XElement(xmlns + "Language", "en-US")
                )
            );
            return doc;
        }

        private String BitmapToByte(Bitmap image)
        {
            String result = String.Empty;

            // the file size is limited here to .NET 128 MB per array per ApplicationDomain. 
            // so if image file is close or greater than 128 MB this will fail. 
            try
            {
                Stream str = new MemoryStream();
                image.Save(str, ImageFormat.Jpeg);
                Byte[] output = new Byte[str.Length];
                str.Position = 0;
                str.Read(output, 0, (int)str.Length);
                result = Convert.ToBase64String(output, Base64FormattingOptions.None);
                str.Flush();
                str.Close();
            }
            catch (OutOfMemoryException ex)
            {
                throw new PdfConverterException(ex.Message, ex, "The file size is too large. It is limited to 128 MB. Try smaller image.");
            }
            catch (Exception ex)
            {
                throw new PdfConverterException(ex.Message, ex);
            }
            return result;
        }
    }
}