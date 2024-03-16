using System.ComponentModel.DataAnnotations;

namespace Date.Models.Entities.Family
{
    public class FamilyEntity: AEntityBase, IEntityBase
    {
        public int Id => FamilyId;
        [Key]
        public int FamilyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid FamilyGuid { get; set; }
        public bool IsActive { get; set; }
       
    }
}
