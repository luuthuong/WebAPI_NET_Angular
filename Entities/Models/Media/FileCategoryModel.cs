﻿using Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Media
{
    [Table("FileCategory", Schema = Schema.Media)]
    public class FileCategoryModel
    {
        public string? FileId { get; set; }
        public virtual FileModel? File { get; set; }

        public string? CategoryId { get; set; }
        public virtual MediaCategoryModel? MediaCategory { get; set; }
    }
}