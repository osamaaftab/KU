using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model {
    public interface IAPIResponse {

        public ApiResponse Success(string message, object data);

        public ApiResponse Fail(string message, object data);

        public ApiResponse InternalFailure(string message, object data);
        public ApiResponse PrepareApiResponse(int statusCode, HttpStatusCode httpStatusCode, string message, object data);
    }
}
