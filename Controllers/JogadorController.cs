using System;
using System.Collections.Generic;
using Eplayers_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers_AspNet.Controllers
{
    [Route("Jogador")]
    public class JogadorController: Controller
    {
        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();
        public IActionResult Index(){
            ViewBag.Jogadores = jogadorModel.ReadAll();
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            List<Equipe> equipes = equipeModel.ReadAll();
            List<Jogador> jogadores = jogadorModel.ReadAll();
            Random random = new Random();
            Jogador novoJogador = new Jogador();
            int numero;
            while (true)
            {
                numero = random.Next(100000);
                if(!jogadores.Exists(x=>x.IdJogador == numero))
                {
                    novoJogador.IdJogador = numero;
                    break;
                }
            }
            novoJogador.NomeJogador = form["NomeJogador"];
            novoJogador.IdEquipe = form["IdEquipe"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];
            jogadorModel.Create(novoJogador);
            ViewBag.Jogadores = jogadorModel.ReadAll();
            return LocalRedirect("~/Jogador");
        }
    }
}