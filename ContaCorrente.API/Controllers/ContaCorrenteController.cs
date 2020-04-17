using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ContaCorrente.Business;
using ContaCorrente.Entity;
using ContaCorrente.API.Queries;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContaCorrente.API.Mutations;
//using ContaCorrente.WebAPI.Models;

namespace ContaCorrente.WebAPI.Controllers
{
    [Route("contacorrente")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            ContaBusiness business = new ContaBusiness();
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new ContaCorrenteQuery(business),
                Mutation = new ContaCorrenteMutation(business)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }
    }
}
