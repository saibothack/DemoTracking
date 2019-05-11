using System;
using System.ComponentModel.DataAnnotations;

namespace DemoTracking.Models
{
    public class DefaultData
    {
        [Key]
        public string id { get; set; }

        [ScaffoldColumn(false)]
        public string OwnerId { get; set; }

        [ScaffoldColumn(false)]
        public string EditionOwnerId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreationDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? EditionDate { get; set; }

        public DefaultData()
        {
            if (string.IsNullOrEmpty(id))
            {
                CreationDate = new DateTime();
            }
            else
            {
                EditionDate = new DateTime();
            }

        }
    }
}
