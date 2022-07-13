using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HospiEnCasa.App.Presentacion.Pages
{
    public class MedicoModel : PageModel
    {
        private readonly ILogger<MedicoModel> _logger;

        public MedicoModel(ILogger<MedicoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}