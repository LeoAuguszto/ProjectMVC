using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;
using ProjectMVC.Repository;

namespace ProjectMVC.Controllers
{
   
public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessions _session;

        public LoginController(IUserRepository userRepository, ISessions sessions)
        {
            _userRepository = userRepository;
            _session = sessions;
        }

        public IActionResult Index()
        {
            if (_session.SearchSession()!= null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Logar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuario = _userRepository.BuscarLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _session.CreateSession(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha inválida!";
                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário incorreto";
                    }
                }
                else
                {
                    TempData["MensagemErro"] = $"Erro ao logar!";
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro: {ex.Message}";
            }

            return View("Index");
        }

    }
}
