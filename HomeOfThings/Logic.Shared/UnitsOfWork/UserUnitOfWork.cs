using Data.Interfaces.Interfaces.Repositories;
using Database.HotContext;
using Date.Models.Entities.User;

namespace Logic.Shared.UnitsOfWork
{
    public class UserUnitOfWork : AUnitOfWork
    {
        private IRepositoryBase<UserEntity>? _userRepository;
        private IRepositoryBase<UserRoleEntity>? _userRoleRepository;
        private IRepositoryBase<UserRolesEntity>? _userRolesRepository;
        private IRepositoryBase<UserRightEntity>? _userRightRepository;
        private IRepositoryBase<UserAccessRightEntity>? _userAccessRightRepository;

        public IRepositoryBase<UserEntity> UserRepository { get => _userRepository ?? new RepositoryBase<UserEntity>(DatabaseContext); }
        public IRepositoryBase<UserRoleEntity> UserRoleRepository { get => _userRoleRepository ?? new RepositoryBase<UserRoleEntity>(DatabaseContext); }
        public IRepositoryBase<UserRolesEntity> UserRolesRepository { get => _userRolesRepository ?? new RepositoryBase<UserRolesEntity>(DatabaseContext); }
        public IRepositoryBase<UserRightEntity> UserRightRepository { get => _userRightRepository ?? new RepositoryBase<UserRightEntity>(DatabaseContext); }
        public IRepositoryBase<UserAccessRightEntity> UserAccessRightRepository { get => _userAccessRightRepository ?? new RepositoryBase<UserAccessRightEntity>(DatabaseContext); }

        public UserUnitOfWork(DatabaseContext context) : base(context)
        {
            
        }

    }
}
