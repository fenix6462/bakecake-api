﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeCakeApi.Models
{
    public class ImageRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}