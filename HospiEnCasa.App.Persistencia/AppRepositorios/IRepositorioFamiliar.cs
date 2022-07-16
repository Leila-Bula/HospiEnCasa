using System.Collections.Generic;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioFamiliarDesignado
    {
        FamiliarDesignado AddFamiliar(FamiliarDesignado Familiar);
        FamiliarDesignado UpdateFamiliar(FamiliarDesignado Familiar);
        void DeleteFamiliar(int idFamiliar);
        FamiliarDesignado GetFamiliar(int idFamiliar);
    }   
    }