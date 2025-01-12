using AutoMapper;
using CleanMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Queries.Detail
{
    public class DetailAccountQueryHandler : IRequestHandler<DetailAccountQuery, DetailAccountViewModel>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public DetailAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }   

        public async Task<DetailAccountViewModel> Handle(DetailAccountQuery request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.DetailAccountAsync(request.Id);
            if (account == null)
            {
                throw new KeyNotFoundException($"Account with ID '{request.Id}' not found.");
            }

            // AutoMapper sẽ thực hiện ánh xạ từ Account sang DetailAccountViewModel
            return _mapper.Map<DetailAccountViewModel>(account);
        }

    }
}
