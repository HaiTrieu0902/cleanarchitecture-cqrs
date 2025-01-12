using CleanMediator.Application.Account.Commands.Create;
using CleanMediator.Application.Account.Commands.Delete;
using CleanMediator.Application.Account.Commands.Update;
using CleanMediator.Application.Account.Queries.Detail;
using CleanMediator.Application.Account.Queries.Search;
using Microsoft.AspNetCore.Mvc;

namespace CleanMediator.API.Controllers.v1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ApiControllerBase
    {
        [HttpGet("search")]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await Mediator.Send(new SearchAccountQuery());
            return Ok(accounts);
        }


        [HttpGet("detail")]
        public async Task<IActionResult> GetDetail(string id)
        {
            var account = await Mediator.Send(new  DetailAccountQuery { Id = id });
            if (account == null)
                return NotFound($"Account with ID '{id}' not found.");
            return Ok(account);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommnad command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAccount = await Mediator.Send(command);
            return Ok( createdAccount);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAccountCommnad command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedAccount = await Mediator.Send(command);
            return Ok(updatedAccount);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await Mediator.Send(new DeleteAccountCommand(id));
            if (result.Status != "Deleted successfully")
                return NotFound($"Account with ID '{id}' not found.");

            return Ok(result);
        }

    }
}
