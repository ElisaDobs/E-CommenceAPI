using E_CommenceAPI.CommenceRepository;
using E_CommenceAPI.Models;

namespace E_CommenceAPI.CommenceService
{
    //Single Responsibility Implementation
    public class RegisterUserService
    {
        private UserRepository _userRepository;
        public RegisterUserService()
        {
            _userRepository = new UserRepository();
        }
        public void CreateUser(SignIn signIn)
        {
            try
            {
                _userRepository.RegisterUser(signIn);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
