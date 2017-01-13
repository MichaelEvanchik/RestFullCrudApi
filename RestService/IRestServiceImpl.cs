using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestService
{
    
    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "GET",ResponseFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Wrapped,UriTemplate = "api/GetPhotos/{id}")]
        IEnumerable<Photo> GetPhotos(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",ResponseFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Wrapped,UriTemplate = "api/DeletePhoto/{id}")]
        int DeletePhoto(string id);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "api/CreatePhoto/")]
        UploadedFile CreatePhoto(Stream Uploading);

        [OperationContract(Name = "Transform")]
        [DataContractFormat]
        [WebInvoke(Method = "POST",UriTemplate = "Transform", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Transform(UploadedFile Uploading, string FileName, string FileDescription, string FileTitle);

        [OperationContract]
        [DataContractFormat]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "api/EditPhotoDescription/{id}")]
        int EditPhotoDescription(string id, string sDescription);

    }

    [DataContract]
    public class UploadedFile
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public string FileTitle { get; set; }

        [DataMember]
        public string FileLength
        { get; set;}

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string FileDescription { get; set; }

        [DataMember]
        public string optionalID { get; set; }

    }
}