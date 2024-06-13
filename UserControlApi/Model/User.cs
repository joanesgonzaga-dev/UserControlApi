namespace UserControlApi.Model
{
    public class User
    {
        public User()
        {
                Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

    }
}
