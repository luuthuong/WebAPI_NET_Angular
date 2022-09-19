using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class FileTransfer
    {
        public static async Task<byte[]> ConvertFileToByte(IFormFile file)
        {
            if(file == null) return Array.Empty<byte>();
            using(var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                byte[] bytes = ms.ToArray();
                return bytes;
            }
        }

        public static async Task<string> WriteFileToFolder(IFormFile file, string path)
        {
            try
            {
                var extension = "." + file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
                string fileName = DateTime.Now.Ticks.ToString() + extension;
                var pathBuild = Path.Combine(Directory.GetCurrentDirectory(), path);
                if (!Directory.Exists(pathBuild))
                {
                    Directory.CreateDirectory(pathBuild);
                }
                var pathFile = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
                using(var stream = new FileStream(pathFile, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool DeleteFileFromFolder(string fileName , string folder)
        {
            try
            {
                var checkExist = File.Exists(Path.Combine(folder, fileName));
                if (checkExist)
                {
                    File.Delete(Path.Combine(folder, fileName));
                }
                return checkExist;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static async File ReadFileFromFolder(string fileName, string path)
        //{
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), path,fileName);
        //    var provider = new FileExtensionContentTypeProvider();
        //    if(provider.TryGetContentType(filePath,out string contentType))
        //    {
        //        contentType = "application/octet-stream";
        //    }
        //    var bytes = await File.ReadAllBytesAsync(filePath);
        //    return File()

        //}
    }
}
