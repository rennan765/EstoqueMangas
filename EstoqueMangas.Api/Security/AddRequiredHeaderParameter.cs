using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace EstoqueMangas.Api.Security
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        #region Classes internas
        class HeaderParameter : NonBodyParameter
        {

        }
        #endregion 

        #region Métodos
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter()
            {
                Name = "Authorization",
                In = "header",
                Type = "string",
                Required = false
            });
        }
        #endregion 
    }
}
