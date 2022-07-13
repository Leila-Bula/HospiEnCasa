using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class PacienteModel : PageModel
    {
        private readonly ILogger<PacienteModel> _logger;

        public PacienteModel(ILogger<PacienteModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
