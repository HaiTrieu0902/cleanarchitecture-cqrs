using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Commands.Delete
{
    public class DeleteAccountViewModel
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public DeleteAccountViewModel(string id, string status)
        {
            Id = id;
            Status = status;
        }
    }
}
