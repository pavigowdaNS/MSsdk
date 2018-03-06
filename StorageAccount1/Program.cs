
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure;

namespace StorageAccount1
{
    public class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAc = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
           CloudBlobClient blobClient= storageAc.CreateCloudBlobClient();
           CloudBlobContainer blobcontainer= blobClient.GetContainerReference("mycontainer");
            blobcontainer.CreateIfNotExists();
           
            CloudBlockBlob blockblob = blobcontainer.GetBlockBlobReference("myblob");
            blobcontainer.SetPermissions(
           new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
       
                using (var fileStream = System.IO.File.OpenRead(@"C:\Users\AGSPL14\Desktop\pa.jpg"))
            {
                blockblob.UploadFromStream(fileStream);
            }

        }
    }
}
