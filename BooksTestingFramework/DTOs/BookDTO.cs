using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksTestingFramework.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override bool Equals(Object obj)
        {
            if (null == obj as BookDTO)
            {
                return false;
            }
            BookDTO tempObj = (BookDTO)obj;
            return (tempObj.Id.Equals(this.Id));
        }
    }
}
