using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Models
{
    public class UpdateFileModel
    {
        public Guid? Id { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }

    public class FileModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get;set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set;}
        public byte[] FileContent { get; set; }
        public string Extension { get; set; }
        public double Size { get; set; }
    }
    
    public class FileFilterModel
    {
        public string SearchText { get; set; }
    }
}
