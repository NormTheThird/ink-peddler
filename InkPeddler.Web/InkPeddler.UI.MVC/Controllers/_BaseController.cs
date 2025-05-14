using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace InkPeddler.UI.MVC.Controllers
{
    public class BaseController<T> : Controller
    {
        internal readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}