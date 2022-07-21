using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente:IRepositorioPaciente

    {
        private readonly AppContext _appContext;

        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }
        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();

        }
        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return _appContext.Pacientes;
        }
        Paciente IRepositorioPaciente.GetPaciente(int idPaciente)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);

        }
        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (pacienteEncontrado != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.Telefono = paciente.Telefono;
                pacienteEncontrado.Genero = paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Latitud = paciente.Latitud;
                pacienteEncontrado.Longitud = paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.FamiliarDesignado = paciente.FamiliarDesignado;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                _appContext.SaveChanges();

            }
            return pacienteEncontrado;
        }

        bool IRepositorioPaciente.AddMedico(int idPaciente, int idMedico)
        { 
            try
            {
                var paciente = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
                var medico = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                paciente.Medico = medico;
                _appContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            

        }
    }
}
