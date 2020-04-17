using ContaCorrente.Entity;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaCorrente.API.Models.GraphQL
{
    public class ContaCorrenteType : ObjectGraphType<Conta>
    {
        public ContaCorrenteType()
        {
            Name = "Conta Corrente";
            Field(x => x.NumeroConta).Description("Número da conta").Name("Conta");
            Field(x => x.Saldo).Description("Saldo do usuário");
        }
    }
}
