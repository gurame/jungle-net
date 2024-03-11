namespace Users;

public interface IApplicationUserRepository
{
  Task<ApplicationUser> GetUserCartByEmailAsync(string emailAddress);
  Task SaveChangesAsync();
}
