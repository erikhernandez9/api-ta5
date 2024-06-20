using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Interfaces
{
    public interface IDivisionService
    {
        IEnumerable<Division> GetDivisiones();
        Division GetDivision(int id);
        Division AddDivision(Division division);
        Division UpdateDivision(int id, Division updatedDivision);
        void DeleteDivision(int id);
    }
}
