/*namespace AuthAPI.Services;

using AuthAPI.Data;
using AuthAPI.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


    public class UserService
{
    private readonly MVCDemoDbContext _dbContext;

    public UserService(MVCDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User Authenticate(string email, string password)
    {
        var user = _dbContext.Users.SingleOrDefault(u => u.Email == email);

        if (user == null)
        {
            return null;
        }

        if (!VerifyPasswordHash(password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }

    public Session CreateSession(int userId, string role)
    {
        var sessionToken = GenerateSessionToken();
        var expirationTime = DateTime.UtcNow.AddMinutes(30);

        var session = new Session
        {
            UserId = userId,
            SessionToken = sessionToken,
            Role = role,
            ExpirationTime = expirationTime
        };

        _dbContext.Sessions.Add(session);
        _dbContext.SaveChanges();

        return session;
    }

    public Session GetSessionByToken(string sessionToken)
    {
        return _dbContext.Sessions.SingleOrDefault(s => s.SessionToken == sessionToken && s.ExpirationTime > DateTime.UtcNow);
    }

    public void DeleteSession(Session session)
    {
        _dbContext.Sessions.Remove(session);
        _dbContext.SaveChanges();
    }

    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    private bool VerifyPasswordHash(string password, string passwordHash)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return hashedPassword == passwordHash;
        }
    }

    private string GenerateSessionToken()
    {
        var bytes = new byte[32];
        using (var random = RandomNumberGenerator.Create())
        {
            random.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
*/