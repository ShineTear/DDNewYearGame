using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace DeaDXoxoton;

public class ConfigureMvcOptions : IConfigureOptions<MvcOptions>
{
    public void Configure(MvcOptions options)
    {
        options.ReturnHttpNotAcceptable = true;
        options.OutputFormatters.RemoveType<StringOutputFormatter>();
        options.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
        options.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
    }
}