﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Model.SearchObjects
{
    public class ProizvodiSearchObject
    { // fts - full text search
        public string? FTS { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set;} 
    }
}
