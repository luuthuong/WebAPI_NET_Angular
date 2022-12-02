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
        private IUserRepository? _repository;
        private readonly  AppDbContext _userContext;
        public RepositoryWrapper(
             AppDbContext userContext
            )
        {
            _userContext = userContext;
        }
        public IUserRepository UserRepository
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
