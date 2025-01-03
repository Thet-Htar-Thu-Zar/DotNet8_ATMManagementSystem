using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class FileResponseDTOs
    {
        public Stream? Content { get; set; }
        public string? File_Name { get; set; }
        public string? Content_Type { get; set; }
    }
}
