using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pontoDigitalFinal.Models;
using pontoDigitalFinal.Repositorio;
using pontoDigitalFinal.ViewModels;

namespace pontoDigitalFinal.Controllers
{
    public class CadastroController :Controller
    {
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        
        UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
        public IActionResult Index()
        {
            ViewData["NomeTela"] = "Cadastrar"; 
            return View();
        }

        [HttpPost]

        public IActionResult Cadastrar (IFormCollection form)
        {
            UsuarioModel usuario = new UsuarioModel();
            usuario.Nome = form ["nome"];
            usuario.Senha = form ["senha"];
            usuario.Telefone = form ["telefone"];
            usuario.Empresa = form ["empresa"];
            usuario.Email = form ["email"];
            
            usuarioRepositorio.Inserir(usuario);

            ViewData["Action"] = "Cadastro";
            return RedirectToAction("Index","Home");
            

        }

        public IActionResult ListarUsuarios(){
            usuarioViewModel.cadastros = usuarioRepositorio.Listar();

            return View(usuarioViewModel);
        }
    }
}