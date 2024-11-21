using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Dto
{
    public class BookViewModel
    {
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public BookViewModel() { }
    }
}
