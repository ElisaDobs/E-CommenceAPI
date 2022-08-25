using E_CommenceAPI.CommenceRepository;

namespace E_CommenceAPI.CommenceService
{
    public class UserService
    {
        private UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }
        public int? GetUserByUserGuid(Guid userGuid)
        {
            try
            {
                return _userRepository.GetUserByUserGuid(userGuid);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
