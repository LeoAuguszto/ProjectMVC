using System.Text.Json;
using System.Text.Json.Serialization;
using ProjectMVC.Data;
using ProjectMVC.Models;

namespace ProjectMVC.Repository
{
    public class Sessions : ISessions
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Sessions(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateSession(UserModel usuario)
        {
            _httpContextAccessor.HttpContext?.Session.SetString("UserSession", usuario.id.ToString());
        }

        public void RemoveSession()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("UserSession");
        }

        public UserModel SearchSession()
        {
            string? userId = _httpContextAccessor.HttpContext?.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userId)) return null;

            try
            {
                return JsonSerializer.Deserialize<UserModel>(userId);
            }
            catch (JsonException)
            {
                // Log the error or handle it as needed
                return null;
            }
        }
    }
}
