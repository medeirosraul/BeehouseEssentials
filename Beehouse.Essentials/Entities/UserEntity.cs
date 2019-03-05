namespace Beehouse.Essentials.Entities
{
    public class UserEntity:Entity
    {
        public string CreatedBy { get; set; }
        public string CreatorName { get; set; }
        public string OwnedBy { get; set; }
    }
}