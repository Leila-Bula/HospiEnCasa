using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioSigno
    {
        IEnumerable<SignoVital> GetAllSigno();
        SignoVital AddSignoVital(SignoVital SignosVitales, int idPaciente);
        SignoVital UpdateSigno(SignoVital SignosVitales);
        void DeleteSigno(int idSignoVitales);
        SignoVital GetSigno(int idSignoVitales);
    }
}