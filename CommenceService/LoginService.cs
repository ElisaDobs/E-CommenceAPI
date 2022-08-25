using E_CommenceAPI.CommenceRepository;
using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    public class LoginService
    {
        private UserRepository _userRepository;
        public LoginService()
        {
            _userRepository = new UserRepository();
        }

        public Guid ValidateUser(LogIn logIn)
        {
            try
            {
                return _userRepository.ValidateUser(logIn);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
