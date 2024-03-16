using Data.Interfaces.Interfaces.Repositories;
using Database.HotContext;
using Date.Models.Entities.Family;

namespace Logic.Shared.UnitsOfWork
{
    public class FamilyUnitOfWork : AUnitOfWork
    {
        
        private IRepositoryBase<FamilyEntity>? _familyRepository;
        public IRepositoryBase<FamilyEntity> FamilyRepository { get => _familyRepository ?? new RepositoryBase<FamilyEntity>(DatabaseContext); }

        public FamilyUnitOfWork(DatabaseContext context):base(context) 
        {
            
        }
    }
}
