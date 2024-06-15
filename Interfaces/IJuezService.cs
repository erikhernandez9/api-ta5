using MyApi.Models;

namespace MyApi.Interfaces
{
    public interface IJuezService
    {
        IEnumerable<Juez> GetJueces();
        Juez GetJuez(int id);
        Juez AddJuez(Juez juez);
        Juez UpdateJuez(int id, Juez updatedJuez);
        void DeleteJuez(int id);
    }
}