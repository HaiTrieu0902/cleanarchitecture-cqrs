using AutoMapper;
using CleanMediator.Application.Common.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMediator.Application.Account.Commands.Create
{
    public class CreateAccountCommnad : IRequest<CreateAccountViewModel> , IMapForm<Domain.Entities.Account>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAccountCommnad, Domain.Entities.Account>();
        }
    }
}
