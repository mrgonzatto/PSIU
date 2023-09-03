using PSIUWeb.Models;

namespace PSIUWeb.Data.Interface
{
    public interface IPacientRepository
    {        
        public Pacient? GetPacientById(int id);

        public IQueryable<Pacient>? GetPacients();

        public Pacient? Update(Pacient p);

        public Pacient? Delete(int id);

        public Pacient? Create(Pacient p);
    }
}
