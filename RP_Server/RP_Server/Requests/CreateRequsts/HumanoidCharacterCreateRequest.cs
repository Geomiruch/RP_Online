namespace RP_Server.Requests.CreateRequsts
{
    public class HumanoidCharacterCreateRequest 
    {
        public string? Name { get; set; }
        public string OwnerId { get; set; }
        public string Race { get; set; }
        public int InventoryId { get; set; }
        public int GroupId { get; set; }
    }
}
