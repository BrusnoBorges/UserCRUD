namespace User.Model
{
    public class UserModel
    {
        public UserModel(string name, string lastName, string email)
        {
            Name = name;
            LastName = lastName;
            Id = Guid.NewGuid().ToString();
            Email = email;
            Active = true;
        } 

        public string Id { get; init; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Birthday { get; private set; } = DateTime.Today.Date.ToShortDateString();
        public bool Active { get; private set; }

        internal void Ativa()
        {
            Active = true;
        }

        internal void Desativa()
        {
            Active = false;
        }

        internal void PutActive(bool active)
        {
            Active = active;
        }
    }
}
 