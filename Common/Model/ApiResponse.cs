using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model {
    public class ApiResponse : IAPIResponse {
        public int ResponseCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ResponseMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ResponseMessages { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        [JsonIgnore]
        public HttpStatusCode HttpResponse { get; set; }

        public ApiResponse InternalFailure(string message, object data) {
            ApiResponse apiResponse = new ApiResponse() {
                ResponseCode = (int)HttpStatusCode.InternalServerError,
                HttpResponse = HttpStatusCode.InternalServerError,
                ResponseMessage = message,
                Data = data
            };

            return apiResponse;
        }

        public ApiResponse Success(string message, object data) {
            ApiResponse apiResponse = new ApiResponse() {
                ResponseCode = (int)HttpStatusCode.OK,
                HttpResponse = HttpStatusCode.OK,
                ResponseMessage = message,
                Data = data
            };
            return apiResponse;
        }

        public ApiResponse Fail(string message, object data) {
            ApiResponse apiResponse = new ApiResponse() {
                ResponseCode = (int)HttpStatusCode.BadRequest,
                HttpResponse = HttpStatusCode.BadRequest,
                ResponseMessage = message,
                Data = data
            };
            return apiResponse;
        }

        public ApiResponse PrepareApiResponse(int statusCode, HttpStatusCode httpStatusCode, string message, object data) {
            ApiResponse apiResponse = new ApiResponse() {
                ResponseCode = statusCode,
                HttpResponse = httpStatusCode,
                ResponseMessage = message,
                Data = data
            };
            return apiResponse;
        }
    }
}
