using AutoMapper;
using CleanMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Queries.Search
{
    public class SearchAccountQueryHandler : IRequestHandler<SearchAccountQuery, List<SearchAccountViewModel>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public SearchAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }   

        public async Task<List<SearchAccountViewModel>> Handle(SearchAccountQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.SearchAccountsync();
            var accountList = _mapper.Map<List<SearchAccountViewModel>>(accounts);
            return accountList;
        }

    }
}
