namespace CPECentral.Data.EF5.Repositories
{
    public sealed class HolderGroupRepository : RepositoryBase<HolderGroup>
    {
        public HolderGroupRepository(CPEUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}