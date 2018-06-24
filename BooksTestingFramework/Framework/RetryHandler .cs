using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BooksTestingFramework.Framework
{
    public class RetryHandler : DelegatingHandler
    {
        private int maxRetries;

        public RetryHandler(HttpMessageHandler innerHandler, int retries)
            : base(innerHandler)
        {
            this.maxRetries = retries;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < maxRetries; i++)
            {
                response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
            }

            return response;
        }
    }
}
