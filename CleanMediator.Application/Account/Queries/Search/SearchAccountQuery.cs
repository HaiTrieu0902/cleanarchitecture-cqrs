using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Queries.Search
{
    public class SearchAccountQuery :  IRequest<List<SearchAccountViewModel>>
    {
        public string? Id { get; set; }
        public string? Name { get; set; } 
        public string? Email { get; set; } 
    }
}
