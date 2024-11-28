namespace AutomatizacionApi.Entities.User
{
    public class Driver : BaseUser
    {

        public string? License { get; set; }
        // Navigation Properties
        public ICollection<Bus>? Bus { get; set; }
    }
}
