using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ErcasCollect.Domain.Interfaces
{
    public interface IWebCallService
    {
        public Task<string> NIBSSWebCall(string url, string parameter);

        public Task<string> NIBSSWebCall2(string url, string parameter);

        public Task<HttpStatusCode> PostWebCall(string url, string parameter);

        public Task<string> GetWebCall(string url);

        public Task<string> PostDataCall(string url, string parameter);

        public Task<string> PostXmlDataCall(string url, string parameter);
    }
}
