using ContaCorrente.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.Business
{
    public class ContaBusiness : Business
    {
        public ContaBusiness() : base() { }

        public Conta CadastrarConta(Conta conta)
        {
            try
            {
                _contexto.Contas.Add(conta);
                _contexto.SaveChanges();
                return conta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Conta AtualizarConta(Conta conta)
        {
            _contexto.Entry(conta).State = EntityState.Modified;
            _contexto.SaveChanges();
            return conta;
        }

        public async Task<List<Conta>> RetornaConta(int numeroConta)
        {
            return await _contexto.Contas.Where(x => x.NumeroConta == numeroConta).ToListAsync();
        }

        public Conta ObtemContaPorNumero(int numeroConta)
        {
            return _contexto.Contas.Where(x => x.NumeroConta == numeroConta).FirstOrDefault();
        }
    }
}
