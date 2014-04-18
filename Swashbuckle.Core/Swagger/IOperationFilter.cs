﻿using System.Web.Http.Description;

namespace Swashbuckle.Swagger
{
    public interface IOperationFilter
    {
        void Apply(Operation operation, DataTypeRegistry dataTypeRegistry, ApiDescription apiDescription);
    }
}