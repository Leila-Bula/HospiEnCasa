using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Persistencia 
{
    public class RepositorioSigno:IRepositorioSigno
    {
        private readonly AppContext _appContext;
        
        public RepositorioSigno(AppContext appContext)
        {
           
            _appContext = appContext;
        }

        SignoVital IRepositorioSigno.AddSignoVital(SignoVital SignosVitales, int idPaciente)
        {
            var signoAdicionado = _appContext.SignoVitales.Add(SignosVitales);
            _appContext.SaveChanges();
            return signoAdicionado.Entity;
        }
         void IRepositorioSigno.DeleteSigno(int idSignoVital)
         {
            var signoEncontrado = _appContext.SignoVitales.FirstOrDefault(s => s.Id == idSignoVital);
            if(signoEncontrado == null)
                return;
                _appContext.SignoVitales.Remove(signoEncontrado);
                _appContext.SaveChanges();
         }
         IEnumerable<SignoVital> IRepositorioSigno.GetAllSigno()
         {
            return _appContext.SignoVitales;
         }
        SignoVital IRepositorioSigno.GetSigno(int idSignoVitales)
        {
            return _appContext.SignoVitales.FirstOrDefault(s => s.Id == idSignoVitales);
        }
        SignoVital IRepositorioSigno.UpdateSigno(SignoVital SignosVitales)
        {
            var signoEncontrado = _appContext.SignoVitales.FirstOrDefault(s => s.Id == SignoVital.Id);
            if (signoEncontrado != null)
            {
              signoEncontrado.Valor = signoEncontrado.Valor;
              
               

            }
            return signoEncontrado;
        }


    }
}