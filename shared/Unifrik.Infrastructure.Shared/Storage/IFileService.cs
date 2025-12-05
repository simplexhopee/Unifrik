using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unifrik.Infrastructure.Shared.Storage
{
    public interface IFileService
    {
        Task UploadAsync(Stream fileStream, string key, string contentType);
        Task<Stream> DownloadAsync(string key);
        Task DeleteAsync(string key);
    }

}
