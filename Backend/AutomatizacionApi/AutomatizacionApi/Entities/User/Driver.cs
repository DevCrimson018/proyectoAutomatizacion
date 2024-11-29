namespace AutomatizacionApi.Entities.User
{
    public class Driver : ApplicationUser
    {

        public string? License { get; set; }
        // Navigation Properties
        public ICollection<Bus>? Bus { get; set; }
    }
}
