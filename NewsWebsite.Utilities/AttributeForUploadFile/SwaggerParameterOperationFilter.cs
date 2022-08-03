using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Http;

namespace NewsWebsite.Utilities.AttributeForUploadFile
{
    public class SwaggerParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            var fileTypeParameters = context.MethodInfo.GetParameters().Where(c => c.ParameterType == typeof(IFormFile));
            if (!fileTypeParameters.Any()) return;

            var uploadFileMediaType = new OpenApiMediaType()
            {
                Schema = new OpenApiSchema()
                {
                    Type = "object",
                }
            };

            foreach (var fileTypeParameter in fileTypeParameters)
            {
                var operationParameter = operation.Parameters.SingleOrDefault(c => c.Name == fileTypeParameter.Name);
                if (operationParameter != null) operation.Parameters.Remove(operationParameter);

                uploadFileMediaType.Schema.Properties.Add(fileTypeParameter.Name, new OpenApiSchema()
                {
                    Description = "Upload File",
                    Type = "file",
                    Format = "formData"
                });
            }

            operation.RequestBody = new OpenApiRequestBody
            {
                Content = { ["multipart/form-data"] = uploadFileMediaType }
            };
        }
    }
}
