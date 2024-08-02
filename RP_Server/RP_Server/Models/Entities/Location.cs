namespace RP_Server.Models.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
