# ContaCorrenteAPI
Passos para executar o projeto:

1 - Selecionar o projeto ContaCorrente.API como "Start Up Project" e executar o mesmo;
2 - Via Postman, testar a requisição com a seguinte URL: http://localhost:51139/contacorrente

Abaixo, os exemplos de queries do GraphQL utilizados:

query {
  saldo(conta: 54321){
      saldo
  }
}

mutation{
    sacar(conta: 54321, valor:800){
        conta,
        saldo
    }
}

mutation{
    depositar(conta: 54321, valor:700){
        conta,
        saldo
    }
}


