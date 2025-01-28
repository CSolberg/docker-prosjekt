namespace MyApi.Models // Sørg for at namespace matcher `MyApi.Data`
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
