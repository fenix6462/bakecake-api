using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Models
{
    public class Base
    {
        public Boolean IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Base()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}