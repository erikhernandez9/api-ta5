using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Interfaces
{
    public interface IPuntajeService
    {
        IEnumerable<Puntaje> GetPuntajes();
        Puntaje GetPuntaje(int id);
        Puntaje AddPuntaje(Puntaje puntaje);
        Puntaje UpdatePuntaje(int id, Puntaje updatedPuntaje);
        void DeletePuntaje(int id);
    }
}