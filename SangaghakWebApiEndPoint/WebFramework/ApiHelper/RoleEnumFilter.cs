using App.Domain.Core.Sangaghak.Enum;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

public class RoleEnumFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(RoleEnum))
        {
            schema.Enum = schema.Enum
                            .Where(e => e is not OpenApiInteger integer || integer.Value != (int)RoleEnum.Admin)
                            .ToList();
        }
    }
}