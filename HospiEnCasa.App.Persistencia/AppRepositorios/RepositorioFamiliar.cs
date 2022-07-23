using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioFamiliar:IRepositorioFamiliarDesignado

    {
        private readonly AppContext _appContext;

        public RepositorioFamiliar(AppContext appContext)
        {
            _appContext = appContext;
        }

        FamiliarDesignado IRepositorioFamiliarDesignado.AddFamiliar(FamiliarDesignado Familiar, int idPaciente)
        {
            var FamiliarAdicionado = _appContext.FamiliarDesignados.Add(Familiar);
            _appContext.SaveChanges();
            var pacienteEncontrado =_appContext.Pacientes.Single(p=>p.Documento == idPaciente);
            pacienteEncontrado.FamiliarDesignado=FamiliarAdicionado.Entity;
            _appContext.SaveChanges();
            return FamiliarAdicionado.Entity;
        }
        void IRepositorioFamiliarDesignado.DeleteFamiliar(int idFamiliar)
        {
            var FamiliarEncontrado = _appContext.FamiliarDesignados.FirstOrDefault(p => p.Id == idFamiliar);
            if (FamiliarEncontrado == null)
                return;
            _appContext.FamiliarDesignados.Remove(FamiliarEncontrado);
            _appContext.SaveChanges();

        }
       IEnumerable<FamiliarDesignado> IRepositorioFamiliarDesignado.GetAllfamiliar()
         {
            return _appContext.FamiliarDesignados;
         }
         
        FamiliarDesignado IRepositorioFamiliarDesignado.GetFamiliar(int idFamiliar)
        {
            return _appContext.FamiliarDesignados.FirstOrDefault(p => p.Id == idFamiliar);

        }
        
        FamiliarDesignado IRepositorioFamiliarDesignado.UpdateFamiliar(FamiliarDesignado familiarDesignado)
        {
            var FamiliarEncontrado = _appContext.FamiliarDesignados.Single(p => p.Id == familiarDesignado.Id);
            if (FamiliarEncontrado != null)
            {
                //FamiliarEncontrado.Documento = FamiliarDesignado.Documento;
                FamiliarEncontrado.Nombre = familiarDesignado.Nombre;
                FamiliarEncontrado.Apellidos = familiarDesignado.Apellidos;
                FamiliarEncontrado.Telefono = familiarDesignado.Telefono;
                FamiliarEncontrado.Genero = familiarDesignado.Genero;
                FamiliarEncontrado.Parentesco = familiarDesignado.Parentesco;
                FamiliarEncontrado.Correo = familiarDesignado.Correo;
              

            }
             _appContext.SaveChanges();

            return FamiliarEncontrado;
        }
    }
}
