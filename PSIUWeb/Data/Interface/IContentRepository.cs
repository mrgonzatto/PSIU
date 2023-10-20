using PSIUWeb.Models;

namespace PSIUWeb.Data.Interface
{
    public interface IContentRepository
    {
        public Content? GetContentById(int id);

        public IQueryable<Content>? GetContents();

        public Content? Update(Content c);

        public Content? Delete(int id);

        public Content? Create(Content c);
    }
}
