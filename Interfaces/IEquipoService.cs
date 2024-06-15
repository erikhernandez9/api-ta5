using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Interfaces
{
    public interface IEquipoService
    {
        IEnumerable<Equipo> GetEquipos();
        Equipo GetEquipo(int id);
        Equipo AddEquipo(Equipo equipo);
    }
}