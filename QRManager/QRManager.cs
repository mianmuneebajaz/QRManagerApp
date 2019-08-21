using IronBarCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRManager
{
    class QRManager
    {
        public void ToQR(string content, string path)
        {
            var r = BarcodeWriter
                 .CreateBarcode(
                     Value: content,
                     BarcodeType: BarcodeWriterEncoding.QRCode)
                         .SaveAsJpeg(path);
        }
        public Image ToQR(string content)
        {
            return BarcodeWriter
                 .CreateBarcode(
                     Value: content,
                     BarcodeType: BarcodeWriterEncoding.QRCode)
                         .ToImage();
        }
        public string Read(string path)
        {
            BarcodeResult Result = BarcodeReader.QuicklyReadOneBarcode(path);
            return Result.Text;
        }
    }
}
