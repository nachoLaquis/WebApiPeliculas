﻿using WebApiPeliculas.Data;
using WebApiPeliculas.Modelos;
using WebApiPeliculas.Repositorio.IRepositorio;

namespace WebApiPeliculas.Repositorio
{
    public class CategoriaRepositorio: ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _db.Categoria.Update(categoria);
            return Guardar();
        }

        public bool BorrarCategoria(Categoria categoria)
        {
            _db.Categoria.Remove(categoria);
            return Guardar();
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _db.Categoria.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(string nombre)
        {
            return _db.Categoria.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
        }

        public bool ExisteCategoria(int id)
        {
            return _db.Categoria.Any(c => c.Id == id);
        }

        public Categoria GetCategoria(int id)
        {
            return _db.Categoria.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _db.Categoria.OrderBy(c => c.Nombre).ToList();
        }

        public bool Guardar()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
