using ContaCorrente.Business;
using ContaCorrente.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContaCorrente.Api.Tests
{
    public class Util
    {
        public void CadastraContas()
        {
            Dictionary<int, double> dictContas = new Dictionary<int, double>();

            dictContas.Add(54321, 800.00);
            dictContas.Add(12345, 600.00);
            dictContas.Add(11111, 700.00);

            foreach (KeyValuePair<int, double> kvp in dictContas)
            {
                Conta conta = new Conta()
                {
                    NumeroConta = kvp.Key,
                    Saldo = kvp.Value
                };

                ContaBusiness business = new ContaBusiness();
                business.CadastrarConta(conta);
            }
        }
    }
}
