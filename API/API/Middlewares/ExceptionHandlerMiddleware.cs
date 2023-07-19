using ShopApp.Service.Exceptions;

namespace API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware( RequestDelegate next) 
        {
          _next = next;
        
        }

        public async Task Invoked (HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception e)
            {


                var response = context.Response;
                response.ContentType = "application/json"; 
                List<RestExceptionsErrorItem> errors = new List<RestExceptionsErrorItem>();
                string message = e.Message;
                switch (e)
                {

                    case RestExceptions re:
                        response.StatusCode = (int)re.Code;
                        errors = re.Errors;
                        message = re.Message;
                        break;
                    default:    
                        break;
                }
                  await  response.WriteAsJsonAsync( new  { message,errors = errors   });

            }
        }
    }
}
