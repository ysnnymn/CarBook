﻿using CarBook.Application.Features.Mediator.Queries.GetCheckAppUserQueries;
using CarBook.Application.Features.Mediator.Results.AppUserResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepository;
		private readonly IRepository<AppRole> _appRoleRepository;

		public GetCheckAppUserQueryHandler(IRepository<AppRole> appRoleRepository, IRepository<AppUser> appUserRepository)
		{
			_appRoleRepository = appRoleRepository;
			_appUserRepository = appUserRepository;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user=await _appUserRepository.GetByFilterAsync(x=>x.Username==request.Username&& x.Password==request.Password);
			if (user==null)
			{
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.UserName = user.Username;
				values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;

			}
			return values;
		}
	}
}
