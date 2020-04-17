using ContaCorrente.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContaCorrente.Business
{
    public class Business
    {
        protected readonly Contexto _contexto;

        public Business()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseInMemoryDatabase("ContaCorrente");
            _contexto = new Contexto(optionsBuilder.Options);
        }

    }
}
