using ContaCorrente.API.Models.GraphQL;
using ContaCorrente.Business;
using ContaCorrente.Entity;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaCorrente.API.Mutations
{
    public class ContaCorrenteMutation : ObjectGraphType<object>
    {
        private ContaBusiness _business;

        public ContaCorrenteMutation(ContaBusiness business)
        {
            _business = business;

            Name = "Mutation";
            Field<ContaCorrenteType>("sacar",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IntGraphType>{Name="conta"},
                    new QueryArgument<FloatGraphType>{Name="valor"}
                }),
                resolve: contexto =>
                {
                    int numeroConta = contexto.GetArgument<int>("conta");
                    double valor = contexto.GetArgument<int>("valor");

                    Conta conta = _business.ObtemContaPorNumero(numeroConta);
                    if (conta.Saldo > valor)
                    {
                        conta.Saldo -= valor;
                        _business.AtualizarConta(conta);
                        return conta;
                    }
                    else
                    {
                        contexto.Errors.Add(new ExecutionError("Saldo insuficiente"));
                        return null;
                    }
                }
            );

            Field<ContaCorrenteType>("depositar",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IntGraphType>{Name="conta"},
                    new QueryArgument<FloatGraphType>{Name="valor"}
                }),
                resolve: contexto =>
                {
                    int numeroConta = contexto.GetArgument<int>("conta");
                    double valor = contexto.GetArgument<int>("valor");

                    Conta conta = _business.ObtemContaPorNumero(numeroConta);

                    conta.Saldo += valor;
                    _business.AtualizarConta(conta);
                    return conta;
                }
            );
        }
    }
}
