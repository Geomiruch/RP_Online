namespace RP_Server.Models.Entities
{
    public class HumanoidCharacter : Character
    {
        public int InventoryId { get; set; }
        // TODO public Inventory Inventory { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
