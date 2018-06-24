using BooksTestingFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksTesting.Spec.Helpers
{
    public class HttpClientContext
    {
        public HttpClientContext()
        {
            this.Client = new BooksClient();
        }

        public BooksClient Client { get; }
    }
}
