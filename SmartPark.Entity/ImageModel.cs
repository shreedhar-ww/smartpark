using System.Web;

namespace SmartPark.Entity
{
    public class ImageModel
    {
        public HttpPostedFileBase Image { get; set; }
        public string FileName { get; set; }
        public string ImageId { get; set; }
        public int UserId { get; set; }
    }
}
