using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class FamiliarDesignadoModel : PageModel
    {
        private readonly ILogger<FamiliarDesignadoModel> _logger;

        public FamiliarDesignadoModel(ILogger<FamiliarDesignadoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
