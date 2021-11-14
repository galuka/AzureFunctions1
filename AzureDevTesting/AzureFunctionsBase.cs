using Microsoft.AspNetCore.Http;
using System;

namespace AzureDevTesting.Functions
{
    public abstract class AzureFunctionsBase
    {
        protected int GetIdFromRequest(HttpRequest req)
        {
            var idParamValue = req.Query["id"];
            int.TryParse(idParamValue, out int id);
            if (id == 0)
            {
                throw new Exception($"Cannot parse id from '{idParamValue}' value.");
            }

            return id;
        }
    }
}
