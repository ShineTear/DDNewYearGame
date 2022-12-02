public class DefaultFileMiddleware
{
    public DefaultFileMiddleware(RequestDelegate next)
    {
        this.next = next ?? throw new ArgumentNullException(nameof(next));
    }

    public Task Invoke(HttpContext context)
    {
        if (context.GetEndpoint() == null && IsGetOrHeadMethod(context.Request.Method) && !Path.HasExtension(context.Request.Path))
        {
            context.Request.Path = defaultFilePath;
        }

        return next(context);
    }

    private static bool IsGetOrHeadMethod(string method)
    {
        return HttpMethods.IsGet(method) || HttpMethods.IsHead(method);
    }

    private readonly RequestDelegate next;
    private readonly PathString defaultFilePath = new PathString("/index.html");
}