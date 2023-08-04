using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shortener.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Shortener.Models
{
    public class UrlModel
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string LongUrl { get; set; }
        [DataType(DataType.Url)]
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public virtual ShortenerUser CreatedBy { get; set; }

    }
}
