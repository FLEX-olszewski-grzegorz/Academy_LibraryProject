﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_LibraryProject.Model
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author}";
        }
    }
}