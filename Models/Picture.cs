using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pic
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public byte[] PictureImage { get; set; }
        public string PictureImageType { get; set; }
    }
}
