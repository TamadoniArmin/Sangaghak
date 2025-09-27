using App.Domain.Core.Sangaghak.DTOs.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class IFormFileFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(UserForRegisterDTO))
        {
            if (schema.Properties.ContainsKey("profileImgFile"))
            {
                schema.Properties.Remove("profileImgFile");
            }
        }
    }
}