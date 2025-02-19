namespace WebApplication1
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Console.WriteLine($"Запрос отработал корректно!");
                await this._next.Invoke(context);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка, тип {e.GetType()} : ({e.Message})");
                //throw;
            }
        }
    }
}