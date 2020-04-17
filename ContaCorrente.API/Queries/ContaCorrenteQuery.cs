using ContaCorrente.Business;
using ContaCorrente.Entity;
using ContaCorrente.API.Models.GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaCorrente.API.Queries
{
    public class ContaCorrenteQuery : ObjectGraphType
    {
        private ContaBusiness _business;
        
        public ContaCorrenteQuery(ContaBusiness business)
        {
            _business = business;
            
            Field<ListGraphType<ContaCorrenteType>>("saldo",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IntGraphType>{Name="conta"}
                }),
                resolve: contexto =>
                {
                    int numeroConta = contexto.GetArgument<int>("conta");
                    return _business.RetornaConta(numeroConta);
                }
            );
        }
    }
}
