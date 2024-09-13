﻿using APP.ACCESODATOS.Data.Repository.IRepository;
using System;
using APP.MODELO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data;
using APP.ACCESODATOS;

namespace APP.ACCESODATOS.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
        }
        public ICategoriaRepository Categoria { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save() { _db.SaveChanges(); }
    }
}
