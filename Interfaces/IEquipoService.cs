// Interfaces/IEquipoService.cs
using MyApi.Models;

namespace MyApi.Interfaces
{
    public interface IEquipoService
    {
        IEnumerable<Equipo> GetEquipos();
        Equipo GetEquipo(int id);
        Equipo AddEquipo(Equipo equipo);
        Equipo UpdateEquipo(int id, Equipo updatedEquipo);
        void DeleteEquipo(int id);
        Equipo AddIntegrante(int equipoId, Participante integrante);
        Equipo RemoveIntegrante(int equipoId, int participanteId);
    }
}
