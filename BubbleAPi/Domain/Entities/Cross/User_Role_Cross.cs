namespace BubbleAPi.Domain.Entities.Cross
{
    public class User_Role_Cross
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
