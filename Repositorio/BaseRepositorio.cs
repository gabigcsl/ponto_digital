using System;
using System.IO;
using pontoDigitalFinal.Models;

namespace pontoDigitalFinal.Repositorio
{
    public class BaseRepositorio
    {
        public string PATH = "Database/Usuario.csv";

        public string[] ObterRegistrosCSV(string PATH)
        {
            return File.ReadAllLines(PATH);
        }
        
        public string ExtrairCampo(string nomeCampo, string linha)
        {
           var chave = nomeCampo;
           var indiceChave = linha.IndexOf(chave);
           var indiceTerminal = linha .IndexOf(";", indiceChave);
           var valor = "";

           if (indiceTerminal != -1)
           {
               valor = linha.Substring(indiceChave, indiceTerminal - indiceChave);
           }else{
               valor = linha.Substring(indiceChave);
           }

           Console.WriteLine($"Campo[{nomeCampo}] e valor {valor}");
           return valor.Replace(nomeCampo + "=", "");

        }

    }
}