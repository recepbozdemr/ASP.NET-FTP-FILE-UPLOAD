using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
namespace Ftp_Upload
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void FTPUpload(object sender, EventArgs e)
        {
            //FTP Server Adresi
            string ftp = "ftp://testsite.com/";

            //FTP Klasör adı.Kök klasöre yüklemek istiyorsan boş bırak
            string ftpFolder = "httpdocs/demo/";

            byte[] fileBytes = null;

           // Dosyayı okuyup Byte dizinine dönüştür
            string fileName = Path.GetFileName(FileUpload1.FileName);
            using (StreamReader fileStream = new StreamReader(FileUpload1.PostedFile.InputStream))
            {
                fileBytes = Encoding.UTF8.GetBytes(fileStream.ReadToEnd());
                fileStream.Close();
            }

            try
            {
                //FTP Request oluşturuluyor
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                //Ftp Kimlik Bilgileri
                request.Credentials = new NetworkCredential("kullanıcı adı", "şifre");
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;   //SSL varsa True Mode

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                lblMessage.Text += fileName + " uploaded.<br />";
                response.Close();
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
        }
    }

}
