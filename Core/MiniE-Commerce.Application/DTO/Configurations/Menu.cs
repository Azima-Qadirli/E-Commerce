namespace MiniE_Commerce.Application.DTO.Configurations
{
    public class Menu
    {
        public string Name { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
