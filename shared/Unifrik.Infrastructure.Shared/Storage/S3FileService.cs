using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;

namespace Unifrik.Infrastructure.Shared.Storage
{
    

    public class S3FileService : IFileService
    {
        private readonly IAmazonS3 _s3;
        private readonly string _bucket;

        public S3FileService(IAmazonS3 s3, IConfiguration config)
        {
            _s3 = s3;
            _bucket = config["S3:BucketName"]!;
        }

        public async Task UploadAsync(Stream fileStream, string key, string contentType)
        {
            var request = new PutObjectRequest
            {
                BucketName = _bucket,
                Key = key,
                InputStream = fileStream,
                ContentType = contentType,
                ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256
            };

            await _s3.PutObjectAsync(request);
        }

        public async Task<Stream> DownloadAsync(string key)
        {
            var response = await _s3.GetObjectAsync(_bucket, key);
            MemoryStream ms = new();
            await response.ResponseStream.CopyToAsync(ms);
            ms.Position = 0;
            return ms;
        }

        public async Task DeleteAsync(string key)
        {
            await _s3.DeleteObjectAsync(_bucket, key);
        }
    }

}
