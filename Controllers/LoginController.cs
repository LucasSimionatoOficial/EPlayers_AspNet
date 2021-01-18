using System.Collections.Generic;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNet.Controllers
{
    
    

    [Route("Login")]
    public class LoginController: Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Jogador jogadorModel = new Jogador();
        public IActionResult Index(){
            return View();
        }
        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            List<string> csv = jogadorModel.ReadAllLinesCSV("Database/jogador.csv");
            var logado = csv.Find(x=>
            x.Split(";")[3] == form["Email"] &&
            x.Split(";")[4] == form["Senha"]
            );
            if(logado != null){
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                return LocalRedirect("~/"); 
            }
            Mensagem = "Dados incorretos, tente novamente";
            return LocalRedirect("~/Login");
        }
        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}