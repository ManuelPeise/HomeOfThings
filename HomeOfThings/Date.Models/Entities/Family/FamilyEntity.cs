namespace Date.Models.Entities.Family
{
    public class FamilyEntity: AEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid FamilyGuid { get; set; }
        public bool IsActive { get; set; }
    }
}
