using System.Text.Json;
using System.Text.Json.Serialization;
using ProjectMVC.Data;
using ProjectMVC.Models;


namespace ProjectMVC.Repository
{
    public class Sessions : ISessions
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessions(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext= httpContextAccessor;
        }
        public UserModel SearchSession()
        {
            string? userId = _httpContext.HttpContext?.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(userId)) return null;

            return JsonSerializer.Deserialize<UserModel>(userId);
        }

        public void CreateSession(UserModel usuario)
        {
            string sessionUser = JsonSerializer.Serialize(usuario);
            _httpContext.HttpContext?.Session.SetString("UserSession", sessionUser);

        }

        public void RemoveSession()
        {
            _httpContext.HttpContext?.Session.Remove("UserSession");
        }


    }
}
