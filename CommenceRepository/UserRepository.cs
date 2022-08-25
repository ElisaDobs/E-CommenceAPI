using E_CommenceAPI.Models;
using E_CommenceAPI.DAL;

namespace E_CommenceAPI.CommenceRepository
{
    public class UserRepository
    {
        public UserRepository()
        {
        }
        public void RegisterUser(SignIn signIn)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                if (signIn != null && !eCommenceDBContext.Users.Any(a => a.UserEmail == signIn.EmailAddress))
                {
                    User user = new User()
                    {
                        UserEmail = signIn.EmailAddress,
                        UserPassword = signIn.Password,
                        DateCreated = DateTime.Now,
                        UserGuid = Guid.NewGuid(),
                        IsActive = true
                    };
                    eCommenceDBContext.Users.Add(user);
                    eCommenceDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User already exist in the system.");
                }
            }
        }
        public Guid ValidateUser(LogIn logIn)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                var user = eCommenceDBContext.Users.FirstOrDefault(a => a.UserEmail == logIn.EmailAddress
                                                                    && 
                                                             a.UserPassword == logIn.Password
                                                                    && 
                                                             a.IsActive);
                if (user == null)
                    return Guid.Empty;

                return user.UserGuid;
            }
        }
        public int? GetUserByUserGuid(Guid userGuid)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                var user = eCommenceDBContext.Users.First(a => a.UserGuid == userGuid);
                if (user == null) 
                    return null;
                return user.UserId;
            }
        }

        public string GetEmailAddressByUserId(Guid userId)
        {
            using (ECommenceDBContext eCommenceDBContext = new ECommenceDBContext())
            {
                var user = eCommenceDBContext.Users.First(a => a.UserGuid == userId);

                if (user == null)
                    return string.Empty;
                return user.UserEmail;
            }
        }
    }
}
