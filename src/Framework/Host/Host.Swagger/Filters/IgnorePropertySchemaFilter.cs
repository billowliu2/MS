﻿using Microsoft.OpenApi.Models;
using MS.Lib.Utils.Core.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace MS.Lib.Host.Swagger.Filters
{
    public class IgnorePropertySchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var ignoreProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<IgnorePropertyAttribute>() != null);

            foreach (var ignorePropertyInfo in ignoreProperties)
            {
                var propertyToRemove = schema.Properties.Keys.SingleOrDefault(x => x.ToLower() == ignorePropertyInfo.Name.ToLower());

                if (propertyToRemove != null)
                {
                    schema.Properties.Remove(propertyToRemove);
                }
            }
        }
    }
}