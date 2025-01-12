using AutoMapper;
using CleanMediator.Domain.Entities;
using CleanMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Commands.Update
{
    public class UpdateAccountCommnandHandler : IRequestHandler<UpdateAccountCommnad, UpdateAccountViewModel>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountCommnandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<UpdateAccountViewModel> Handle(UpdateAccountCommnad request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Ánh xạ từ UpdateAccountCommand sang Account (Entity)
                var accountEntity = _mapper.Map<Domain.Entities.Account>(request);
                // 2. Gọi Repository để thực hiện cập nhật
                var resultMessage = await _accountRepository.UpdateAccountAsync( accountEntity);
                if (resultMessage != "Update successful.")
                {
                    throw new ApplicationException($"Failed to update account: {resultMessage}");
                }
                // 3. Ánh xạ lại sang ViewModel và trả về kết quả
                return _mapper.Map<UpdateAccountViewModel>(accountEntity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the account.", ex);
            }
        }


    }
}
