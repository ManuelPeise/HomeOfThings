using Date.Models.Enums;

namespace Date.Models.Entities
{
    public class AppModuleEntity: AEntityBase, IEntityBase
    {
        public int Id { get; set; }
        public int AppModule => Id;
        public string ModuleName { get; set; } = string.Empty;
        public AppModuleEnum ModuleKey { get; set; }
    }
}
