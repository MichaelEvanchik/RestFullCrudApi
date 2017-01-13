using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestService
{
    public class Photo
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public virtual int iPhotoID { get; set; }
        public string sPhotoDescription { get; set; }
        public string sPhotoTitle { get; set; }
        public byte[] Image { get; set; }
    }
}