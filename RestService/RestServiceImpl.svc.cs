using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace RestService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                 InstanceContextMode = InstanceContextMode.PerCall,
                 IgnoreExtensionDataObject = true,
                 IncludeExceptionDetailInFaults = true)]
    public class RestServiceImpl : IRestServiceImpl
    {
     
        public IEnumerable<Photo> GetPhotos(string id)
        {
            var db = new PhotoDbContext();
        
            var data = from i in db.Photos
                       where i.iPhotoID == Convert.ToInt32(id)
                       select i;

            return data.ToList();
        }

        public int DeletePhoto(string id)
        {
            try
            {
                var db = new PhotoDbContext();
                Photo photo = new Photo() { iPhotoID = Convert.ToInt32(id) };
                db.Photos.Attach(photo);
                db.Photos.Remove(photo);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
            return 1;
        }

        public UploadedFile CreatePhoto(Stream strm)
        {

            var p = new Photo();

            UploadedFile upload = new UploadedFile
            {
                FilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
            };


            int length = 0;

            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = strm.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                p.Image = ms.ToArray();
            }


            p.sPhotoTitle = upload.FileTitle;
            p.sPhotoDescription = upload.FileDescription;

            upload.FileLength = length.ToString();

            var db = new PhotoDbContext();
            db.Photos.Add(p);
            db.SaveChanges();
            

            return upload;
        }

        public UploadedFile Transform(UploadedFile Uploading, string FileName, string FileDescription, string FileTitle)
        {
            Uploading.FileName = FileName;
            Uploading.FileDescription = FileDescription;
            return Uploading;
        }

        public int UpdatePhoto(string id, string sDescription)
        {
            var p = new Photo();

            using (var db = new PhotoDbContext())
            {
                var result = db.Photos.SingleOrDefault(b => b.iPhotoID == Convert.ToInt32(id));
                {
                    db.Photos.Attach(result);
                    result.sPhotoDescription = sDescription;
                    db.SaveChanges();
                }
            }
            return 1;
        }
    }
}