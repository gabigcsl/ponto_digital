using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pontoDigitalFinal.Repositorio;
using pontoDigitalFinal.Models;


namespace pontoDigitalFinal.Controllers
{
    public class EntrarController : Controller
    {

        private const string SESSION_EMAIL = "_EMAIL";
        private const string SESSION_USUARIOS = "_USUARIOS";
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
       public IActionResult Index()
        {
            ViewData["NomeTela"] = "Entrar"; 
            return View();
        }

        [HttpPost]

        public IActionResult Login(IFormCollection form)
        {
            var usuario = form ["email"];
            var senha = form ["senha"];
            var usuarios = usuarioRepositorio.ObterPor(usuario);

            if (usuarios != null && usuarios.Senha.Equals(senha))
            {
                HttpContext.Session.SetString(SESSION_EMAIL, usuario);
                HttpContext.Session.SetString(SESSION_USUARIOS, usuarios.Nome);
                System.Console.WriteLine("usuario logado");
            }else if(usuarios != null && usuarios.Senha != senha){
                return View("Falha");
            }

            return RedirectToAction("Index", "Home");
        }

    }
}