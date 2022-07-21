using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSigno
    {
        IEnumerable<SignoVital> GetAllSigno();
        SignoVital AddSignoVital(SignoVital signosVitales, int idPaciente);
        SignoVital UpdateSigno(SignoVital signosVitales);
        void DeleteSigno(int idSignoVitales);
        SignoVital GetSigno(int idSignoVitales);
    }
}