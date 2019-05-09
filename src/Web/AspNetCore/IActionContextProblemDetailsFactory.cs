﻿using Microsoft.AspNetCore.Mvc;

namespace Optivem.Web.AspNetCore
{
    public interface IActionContextProblemDetailsFactory<TProblemDetails> where TProblemDetails : ProblemDetails
    {
        TProblemDetails Create(ActionContext actionContext);
    }
}