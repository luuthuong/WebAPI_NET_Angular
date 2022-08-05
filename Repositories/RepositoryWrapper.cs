using Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private UserRepository _repository;
        private readonly IdentityUserContext _userContext;
        private readonly RepositoryContext _repositoryContext;
        public RepositoryWrapper(
            IdentityUserContext userContext,
            RepositoryContext repositoryContext
            )
        {
            _userContext = userContext;
            _repositoryContext = repositoryContext;
        }
        public UserRepository UserRepository
        {
            get
            {
                if (_repository == null)
                {
                    _repository = new UserRepository(_userContext);
                }
                return _repository;
            }
        }
    }
}
