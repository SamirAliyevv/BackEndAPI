using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Exceptions
{
    public class RestExceptions:Exception
    {

        public RestExceptions(HttpStatusCode code, string message):base(message)
        {
            Code = code;
            
        }
        public RestExceptions(HttpStatusCode code, string key, string errorMessage, string message=null):base(message)
        {
            Code = code;
            Errors = new List<RestExceptionsErrorItem> { new RestExceptionsErrorItem(key, errorMessage) };

        }

        public RestExceptions(HttpStatusCode code, string message,List<RestExceptionsErrorItem> errors):base(message)
        {
            Code = code;
            Errors = errors;

        }



        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public List<RestExceptionsErrorItem> Errors { get; set; }
    }

    public class RestExceptionsErrorItem
    {

        public string Key { get; set; }
        public string ErrorMessage { get; set; }
        public RestExceptionsErrorItem(string key,string errormessage)
        {
            Key = key;
          ErrorMessage = errormessage;
            
        }
    }
}
