using PlanningPersonal.Models;

namespace PlanningPersonal.Interfaces
{
    public interface IRotationRepository
    {
        Task<Rotation?> GetByIdAsync(int id);
        Task<IEnumerable<Rotation>> GetByEmployeeAsync(int idEmployee);
        Task<IEnumerable<Rotation>> GetByDateAndEmployee(int idEmployee, DateTime From, DateTime To);
        Task<IEnumerable<Rotation>> GetByDate(DateTime from, DateTime to);
        bool Add(Rotation rotation);
        bool Update(Rotation rotation);
        bool Delete(Rotation rotation);
        bool Save();
    }
}
