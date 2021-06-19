using System;

namespace KitProjects.EnterpriseLibrary.Core.Models
{
    public class Image
    {
        public string Base64 { get; set; }
        public Uri Link { get; set; }
        public string ContentType { get; set; }
    }
}
