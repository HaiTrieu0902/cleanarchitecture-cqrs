using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Commands.Delete
{
    public class DeleteAccountCommand : IRequest<DeleteAccountViewModel>
    {
        public string Id { get; set; }
        public DeleteAccountCommand(string id)
        {
            Id = id;
        }
    }
}
