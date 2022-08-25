using E_CommenceAPI.CommenceRepository;

namespace E_CommenceAPI.CommenceService
{
    public class UserEmailService
    {
        private UserRepository _userRepository;
        public UserEmailService()
        {
            _userRepository = new UserRepository();
        }

        public string GetEmailAddressByUserId(Guid userId)
        {
            try
            {
                return _userRepository.GetEmailAddressByUserId(userId);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
