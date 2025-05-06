using WebApiPeliculas.Data;
using WebApiPeliculas.Modelos;
using WebApiPeliculas.Repositorio.IRepositorio;

// [CAT-REPO] Implementación del repositorio de Categoría
namespace WebApiPeliculas.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            var categoriaExiste = _db.Categorias.Find(categoria.Id);
            if (categoriaExiste != null)
            {
                _db.Entry(categoriaExiste).CurrentValues.SetValues(categoria);
            }
            else
            {
                _db.Categorias.Update(categoria);
            }

            return Guardar();
        }

        public bool BorrarCategoria(Categoria categoria)
        {
            _db.Categorias.Remove(categoria);
            return Guardar();
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _db.Categorias.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(string nombre)
        {
            return _db.Categorias.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
        }

        public bool ExisteCategoria(int id)
        {
            return _db.Categorias.Any(c => c.Id == id);
        }

        public Categoria GetCategoria(int id)
        {
            return _db.Categorias.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _db.Categorias.OrderBy(c => c.Nombre).ToList();
        }

        public bool Guardar()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
