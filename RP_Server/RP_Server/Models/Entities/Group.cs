namespace RP_Server.Models.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public ICollection<HumanoidCharacter> Characters { get; set; }
    }
}
