using AutoMapper;
using CleanMediator.Domain.Entities;
using CleanMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Commands.Create
{
    public class CreateAccountCommnandHandler : IRequestHandler<CreateAccountCommnad, CreateAccountViewModel>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public CreateAccountCommnandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<CreateAccountViewModel> Handle(CreateAccountCommnad request, CancellationToken cancellationToken)
        {
            try
            {
                //var account = new Domain.Entities.Account()
                //{
                //    Id = request.Id,
                //    Name = request.Name,
                //    Email = request.Email,
                //    Password = request.Password,
                //    PhoneNumber = request.PhoneNumber

                //};
                var account = _mapper.Map<Domain.Entities.Account>(request);
                // Lưu Entity vào cơ sở dữ liệu
                var createdAccount = await _accountRepository.CreateAccountAsync(account);

                // Ánh xạ từ Entity sang ViewModel
                return _mapper.Map<CreateAccountViewModel>(createdAccount);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the account.", ex);
            }
        }


    }
}
