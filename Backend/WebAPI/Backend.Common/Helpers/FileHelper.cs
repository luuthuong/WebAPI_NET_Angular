using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Helpers
{
    public static class FileHelper
    {
        public static async Task<byte[]> ConvertToByte(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException();
            using(var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                return stream.ToArray();
            }
        }
    }
}
