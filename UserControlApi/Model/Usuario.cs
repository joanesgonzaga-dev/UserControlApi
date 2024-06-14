namespace UserControlApi.Model
{
    public class Usuario
    {
        public Usuario()
        {
                Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
