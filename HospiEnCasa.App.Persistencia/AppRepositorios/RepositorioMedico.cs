using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Persistencia 
{
    public class RepositorioMedico:IRepositorioMedico
    {
        private readonly AppContext _appContext;
        
        public RepositorioMedico(AppContext appContext)
        {
           
            _appContext = appContext;
        }

        Medico IRepositorioMedico.AddMedico(Medico medico)
        {
            var medicoAdicionado = _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity;
        }
         void IRepositorioMedico.DeleteMedico(int idMedico)
         {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
            if(medicoEncontrado == null)
                return;
                _appContext.Medicos.Remove(medicoEncontrado);
                _appContext.SaveChanges();
         }
         IEnumerable<Medico> IRepositorioMedico.GetAllMedico()
         {
            return _appContext.Medicos;
         }
        Medico IRepositorioMedico.GetMedico(int idMedico)
        {
            return _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
        }
        Medico IRepositorioMedico.UpdateMedico(Medico medico)
        {
            var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == medico.Id);
            if (medicoEncontrado != null)
            {
                medicoEncontrado.Nombre = medico.Nombre;
                medicoEncontrado.Apellidos = medico.Apellidos;
                medicoEncontrado.Telefono = medico.Telefono;
                medicoEncontrado.Genero = medico.Genero;
                medicoEncontrado.Documento = medico.Documento;
                medico.Especialidad = medico.Especialidad;
                medico.RegistroRethus = medico.RegistroRethus;
                _appContext.SaveChanges();

            }
            return medicoEncontrado;
        }


    }
}