using Backend.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Entities
{
    [Table("FileCategory",Schema = SchemaConstants.Media)]
    public class FileCategory
    {
        public Guid FileId { get; set; }
        public virtual FileMedia File { get; set; }
        public Guid CategoryId { get;set; }
        public virtual CategoryMedia Category { get; set; }
    }
}
