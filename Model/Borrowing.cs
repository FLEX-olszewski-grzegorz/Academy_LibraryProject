using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_LibraryProject.Model
{
    internal class Borrowing
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Reader Reader { get; set; }
    }
}
