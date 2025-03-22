using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Models;
using ProjectMVC.Repository;

namespace ProjectMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> TdUsers = _userRepository.BuscarTodos();
            return View(TdUsers);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.ListarId(id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.RemoveRegistro(id);
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao tentar apagar!, Detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Adicionar(user);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao tentar cadastrar!, Detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alter(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.AtualizarRegistro(user);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", user);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao tentar atualizar!, Detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}