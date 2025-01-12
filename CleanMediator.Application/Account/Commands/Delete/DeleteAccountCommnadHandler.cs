using MediatR;
using CleanMediator.Domain.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Commands.Delete
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountViewModel>
    {
        private readonly IAccountRepository _accountRepository;

        public DeleteAccountCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<DeleteAccountViewModel> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Gọi Repository để xóa tài khoản
                var result = await _accountRepository.DeleteAccountAsync(request.Id);

                // Xây dựng ViewModel dựa trên kết quả trả về
                return new DeleteAccountViewModel(
                    request.Id,
                    result == "Success" ? "Deleted successfully" : "Failed to delete account"
                );
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the account with ID: {request.Id}.", ex);
            }
        }
    }
}
