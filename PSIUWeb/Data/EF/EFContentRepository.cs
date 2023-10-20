using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Data.EF
{
    public class EFContentRepository : IContentRepository
    {
        private AppDbContext context;

        public EFContentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Content? Create(Content c)
        {
            try
            {
                context.Contents?.Add(c);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return c;
        }

        public Content? Delete(int id)
        {
            Content? c = GetContentById(id);

            if (c == null)
                return null;

            context.Contents?.Remove(c);
            context.SaveChanges();

            return c;
        }

        public Content? GetContentById(int id)
        {
            Content? c =
                context
                    .Contents?
                    .Where(c => c.Id == id)
                    .FirstOrDefault();

            return c;
        }

        public IQueryable<Content>? GetContents()
        {
            return context.Contents;
        }

        public Content? Update(Content c)
        {
            try
            {
                context.Contents?.Update(c);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return c;
        }
    }
}
