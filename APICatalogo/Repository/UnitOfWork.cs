﻿using APICatalogo.Contexto;

namespace APICatalogo.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository _produtoRepo;
        private CategoriaRepository _categoriaRepo;
        public AppDbContext _context;

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepsitory CategoriaRepository
        {
            get
            {
                return _categoriaRepo = _categoriaRepo ?? new CategoriaRepository(_context);
            }
        }

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }

       

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        void IUnitOfWork.Commit()
        {
            throw new System.NotImplementedException();
        }
    }
}


