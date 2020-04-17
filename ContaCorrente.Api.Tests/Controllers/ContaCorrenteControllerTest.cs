using ContaCorrente.API.Queries;
using ContaCorrente.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.Api.Tests.Controllers
{
    [TestClass]
    public class ContaCorrenteControllerTest
    {
        [TestMethod]
        public async Task PostSaldoAsync()
        {
            // Arrange
            ContaCorrenteController controller = new ContaCorrenteController();
            Util util = new Util();
            util.CadastraContas();

            GraphQLQuery query = new GraphQLQuery
            {
                Query = @"
                    query {
                      saldo(conta: 54321){
                          saldo
                      }
                    }
                "
            };

            // Act
            IActionResult result = await controller.Post(query);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task PostSacarAsync()
        {
            // Arrange
            ContaCorrenteController controller = new ContaCorrenteController();
            Util util = new Util();
            util.CadastraContas();

            GraphQLQuery query = new GraphQLQuery
            {
                Query = @"
                    mutation{
                        sacar(conta: 54321, valor:200){
                            conta,
                            saldo
                        }
                    }
                "
            };

            // Act
            IActionResult result = await controller.Post(query);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task PostSacarSaldoInsuficienteAsync()
        {
            // Arrange
            ContaCorrenteController controller = new ContaCorrenteController();
            Util util = new Util();
            util.CadastraContas();

            GraphQLQuery query = new GraphQLQuery
            {
                Query = @"
                    mutation{
                        sacar(conta: 54321, valor:2500){
                            conta,
                            saldo
                        }
                    }
                "
            };

            // Act
            IActionResult result = await controller.Post(query);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PostDepositarAsync()
        {
            // Arrange
            ContaCorrenteController controller = new ContaCorrenteController();
            Util util = new Util();
            util.CadastraContas();

            GraphQLQuery query = new GraphQLQuery
            {
                Query = @"
                    mutation{
                        depositar(conta: 54321, valor:300){
                            conta,
                            saldo
                        }
                    }
                "
            };

            // Act
            IActionResult result = await controller.Post(query);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
