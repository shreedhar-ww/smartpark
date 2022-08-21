using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;


namespace SmartPark.Helper
{
    public static class UploadImageDirectoryManager
    {
        public static string ConstructAndReturnFullUrlFromBasicUrl(string basicUrl)
        {
            var photoUrl = new StringBuilder("http://", 100);
            photoUrl.Append(HttpContext.Current.Request.Url.Host);
            if (!HttpContext.Current.Request.Url.IsDefaultPort)
            {
                photoUrl.Append(":");
                photoUrl.Append(HttpContext.Current.Request.Url.Port);
            }
            photoUrl.Append("/");
            photoUrl.Append(basicUrl.Replace("\\", "/"));

            return photoUrl.ToString();
        }

        public static string GetDefaultImage()
        {
            return "../Content/themes/base/images/DefaultLogo.png";
        }

        public static string GetUrlOfAgentLogo(int systemUserId,string fileName)
        {
            string basicUrl = ConfigurationManager.AppSettings["PermanentAgentLogoUrl"] + systemUserId + "\\" + fileName+".jpg";
            return ConstructAndReturnFullUrlFromBasicUrl(basicUrl);
        }

        public static string GetUrlOfBannerImage(int systemUserId, string fileName)
        {
            string basicUrl = ConfigurationManager.AppSettings["PermanentBannerUrl"] + systemUserId + "\\" + fileName + ".jpg";
            return ConstructAndReturnFullUrlFromBasicUrl(basicUrl);
        }

        public static string GetBaseUrlForTemporayAgentLogo(int userId)
        {
            string url = Path.Combine(HttpContext.Current.Server.MapPath("/"),
                ConfigurationManager.AppSettings["TemporaryAgentLogoUrl"] + userId);
            return url;
        }

        public static string GetBaseUrlForTemporayBanner(int userId)
        {
            string url = Path.Combine(HttpContext.Current.Server.MapPath("/"),
                ConfigurationManager.AppSettings["TemporaryBannerUrl"] + userId);
            return url;
        }

        public static bool CreateDirectory(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                return true;
            }

            return false;
        }

        public static void UploadFile(string directoryPath, HttpPostedFileBase file)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            if (file != null)
            {
                HttpPostedFileBase httpPostedFileBase = file;
                var combine = Path.Combine(directoryPath, file.FileName);
                httpPostedFileBase.SaveAs(combine);
            }
        }

        public static string AppendTimeStamp(this string fileName)
        {
            return string.Concat(
                Path.GetFileNameWithoutExtension(fileName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(fileName)
                );
        }

        public static void DeleteDirectoryContentsLeavingDirectoryIntact(string directoryPath)
        {
            if (directoryPath != null)
            {
                if (Directory.Exists(directoryPath))
                {
                    string[] files = Directory.GetFiles(directoryPath);
                    foreach (string file in files)
                    {
                        File.Delete(file);
                    }
                }
            }
        }
    }
}