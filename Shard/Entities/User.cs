namespace Shard.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            return Id.Equals((obj as User).Id);
        }
    }
}
