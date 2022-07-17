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

        FamiliarDesignado IRepositorioFamiliarDesignado.AddFamiliar(FamiliarDesignado Familiar)
        {
            var FamiliarAdicionado = _appContext.FamiliarDesignados.Add(Familiar);
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
      
        FamiliarDesignado IRepositorioFamiliarDesignado.GetFamiliar(int idFamiliar)
        {
            return _appContext.FamiliarDesignados.FirstOrDefault(p => p.Id == idFamiliar);

        }
        FamiliarDesignado IRepositorioFamiliarDesignado.UpdateFamiliar(FamiliarDesignado FamiliarDesignado)
        {
            var FamiliarEncontrado = _appContext.FamiliarDesignados.FirstOrDefault(p => p.Id == FamiliarDesignado.Id);
            if (FamiliarEncontrado != null)
            {
                FamiliarEncontrado.Nombre = FamiliarDesignado.Nombre;
                FamiliarEncontrado.Apellidos = FamiliarDesignado.Apellidos;
                FamiliarEncontrado.Telefono = FamiliarDesignado.Telefono;
                FamiliarEncontrado.Genero = FamiliarDesignado.Genero;
                FamiliarEncontrado.Parentesco = FamiliarDesignado.Parentesco;
                FamiliarEncontrado.Correo = FamiliarDesignado.Correo;
              
                _appContext.SaveChanges();

            }
            return FamiliarEncontrado;
        }
    }
}
