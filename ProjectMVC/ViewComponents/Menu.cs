using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;

namespace ProjectMVC.ViewComponents
{
    public class Menu :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? sessionName = HttpContext.Session.GetString("UserSession");

            if (string.IsNullOrEmpty(sessionName)) return null;

            UserModel user = JsonSerializer.Deserialize<UserModel>(sessionName)!;
            return View(user);
        }
    }
}
