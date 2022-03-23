using API.Context;
using API.Requests;
using API.Utilities;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly TasksDbContext _context;

        public UserService(TasksDbContext context)
        {
            _context = context;
        }
        public async Task<string> SignUpAsync(SignupRequest request)
        {
            var user = _context.Users
                .Where(x => x.Email == request.Email && x.Password == request.Password)
                .FirstOrDefault();

            if (user != null)
            {
                return await Task.FromResult("user exists");
            }
            else
            {
                var salt = PasswordHelper.RenderSecureSalt();
                var passwordHash = PasswordHelper.CreatePasswordHash(request.Password, salt);

                var newUser = new API.Entities.User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = passwordHash,
                    PasswordSalt = Convert.ToBase64String(salt),
                    Active = true,
                    TimeStamp = DateTime.UtcNow
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                return newUser.Email;
            }
        }
    }
}
