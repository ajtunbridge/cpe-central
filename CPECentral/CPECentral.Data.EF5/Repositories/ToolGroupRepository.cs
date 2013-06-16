namespace CPECentral.Data.EF5.Repositories
{
    public sealed class ToolGroupRepository : RepositoryBase<ToolGroup>
    {
        public ToolGroupRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}