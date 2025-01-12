using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Queries.Detail
{
    public class DetailAccountQuery :  IRequest<DetailAccountViewModel>
    {
        public string Id { get; set; }
    }
}
