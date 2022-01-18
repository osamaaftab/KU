using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.GenericModel {
    public class ResponseType<T> : ValidationResult {
        public ResponseType() : base("response") {
        }
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public T Data { get; set; }
    }
}
