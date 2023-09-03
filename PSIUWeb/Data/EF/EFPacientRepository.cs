using PSIUWeb.Data.Interface;
using PSIUWeb.Models;
using System.Linq;

namespace PSIUWeb.Data.EF
{
    public class EFPacientRepository : IPacientRepository
    {
        private AppDbContext context;

        public EFPacientRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Pacient? Create(Pacient p)
        {
            try
            {
                context.Pacients?.Add(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }

        public Pacient? Delete(int id)
        {
            Pacient? p = GetPacientById(id);
            
            if (p == null)            
                return null;

            context.Pacients?.Remove(p);
            context.SaveChanges();

            return p;
            

        }

        public Pacient? GetPacientById(int id)
        {
            Pacient? p = 
                context
                    .Pacients?
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

            return p;

        }

        public IQueryable<Pacient>? GetPacients()
        {
            return context.Pacients;
        }

        public Pacient? Update(Pacient p)
        {
            try
            {
                context.Pacients?.Update(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }
    }
}
