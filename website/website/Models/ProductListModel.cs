﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace website.Models
{
    public class ProductListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Bought { get; set; }
    }
}