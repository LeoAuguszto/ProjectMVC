using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using ProjectMVC.Models;
using ProjectMVC.Repository;

namespace ProjectMVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public IActionResult Index()
        {
            List<ContactModel> TdContatos = _contactRepository.BuscarTodos();
            return View(TdContatos);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListarId(id);
            return View(contact);
        }
        public IActionResult Delete(int id)
        {
            try {
                _contactRepository.RemoveRegistro(id);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao tentar apagar!, Detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Adicionar(contact);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao tentar cadastrar!, Detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alter(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.AtualizarRegistro(contact);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Edit", contact);
            }
            catch (System.Exception e)
            {
                TempData["MensagemErro"] = $"Erro ao tentar atualizar!, Detalhe do erro:{e.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}
