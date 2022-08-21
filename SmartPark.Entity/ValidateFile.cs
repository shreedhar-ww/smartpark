using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace SmartPark
{
    public class ValidateFile  : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var img = System.Drawing.Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Png);
                }
            }
            catch { }
            return false;
        }
    }
}