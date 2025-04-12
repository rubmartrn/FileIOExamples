using AuthTest.Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel model)
        {

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (!VerifyPassword(model.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid password");
            }

            var role = user.Role ?? "user";

            var claim1 = new Claim("usertype", "student");
            var claim2 = new Claim("UrishRoleType", role);
            var claimIdentity = new ClaimsIdentity(
                new List<Claim>() { claim1, claim2 },
                "Cookie",
                ClaimsIdentity.DefaultNameClaimType,
                roleType: "UrishRoleType"
                );
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
            return SignIn(claimsPrincipal, "Cookie");
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserModel model)
        {
            var user = new User()
            {
                Email = model.Email,
                PasswordHash = HashPassword(model.Password)
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok();
        }

        public static string HashPassword(string password)
        {
            //պատահական թվերով array
            var salt = new byte[16];//010100100
            //Կեղծ պատահական կամ pseudorandom թիվ
            using (var rgn = RandomNumberGenerator.Create())
            {
                rgn.GetBytes(salt);
            }

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 350000,
                outputLength: 32,
                hashAlgorithm: HashAlgorithmName.SHA512);

            var hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            byte[] hashBytes = Convert.FromBase64String(hash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var newHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations: 350000,
                outputLength: 32,
                hashAlgorithm: HashAlgorithmName.SHA512);


            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != newHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        public class UserModel
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;
        }
    }
}
