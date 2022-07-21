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

        SignoVital IRepositorioSigno.AddSignoVital(SignoVital signosVitales,)
        {
            var signoAdicionado = _appContext.SignoVitales.Add(signosVitales);
            _appContext.SaveChanges();
            return signoAdicionado.Entity;
        }
         void IRepositorioSigno.DeleteSigno(int idSignoVital)
         {
            var signoEncontrado = _appContext.SignoVitales.FirstOrDefault(s => s.Id == idSignoVital);
            if(signoEncontrado == null)
            {
                return;
            }
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
        SignoVital IRepositorioSigno.UpdateSigno(SignoVital signosVitales)
        {
            var signoEncontrado = _appContext.SignoVitales.FirstOrDefault(s => s.Id == signosVitales.Id);
            /*if (signoEncontrado != null)
            {
                signoEncontrado.tensionArterial = SignoVitales.tensionArterial;
                signoEncontrado.frecuenciaCardiaca = SignoVitales.frecuenciaCardiaca;
                signoEncontrado.frecuenciaRespiratoria = SignoVitales.frecuenciaRespiratoria;
                _appContext.SaveChanges();

            }*/
            return signoEncontrado;
        }


    }
}