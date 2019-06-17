using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Primitives;
using pontoDigitalFinal.Models;

namespace pontoDigitalFinal.Repositorio {
    public class UsuarioRepositorio : BaseRepositorio
    {
        

        public const string PATH_INDEX = "Database/Usuario.csv";

        public static uint CONT = 0;

        public UsuarioRepositorio()
        {
            if (!File.Exists(PATH_INDEX))
            {
                File.Create(PATH_INDEX).Close();
            }
        }
        public bool Inserir (UsuarioModel usuario) {
            CONT++;
            File.WriteAllText(PATH_INDEX, CONT.ToString());

            string linha = PrepararRegistrosCSV(usuario);
            File.AppendAllText (PATH,linha);

            return true;
        }

        public List<UsuarioModel> Listar(){
            List<UsuarioModel> listaDeUsuarios = new List<UsuarioModel>();

            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }//fim do if
                string[] dados = item.Split(";");
                UsuarioModel usuario = new UsuarioModel();
                usuario.Id = int.Parse(dados[0]);
                usuario.Nome = dados[1];
                usuario.Empresa = dados[2];
                usuario.Email = dados[3];
                usuario.Telefone = dados[4];
                usuario.Senha = dados[5];
                
                listaDeUsuarios.Add(usuario);

            }//fim fo foreach
            return listaDeUsuarios;

        }

        public UsuarioModel ObterPor(string Email)
        {
            foreach (var item in ObterRegistrosCSV (PATH)) 
            {
                if (Email.Equals(ExtrairCampo (Email.ToString(), item))) 
                {
                    return TransformarObjeto (item);
                }
            }
            return null;
        }

        private UsuarioModel TransformarObjeto (string registro){

            UsuarioModel usuarios = new UsuarioModel();
            Console.WriteLine("REGISTRO: " + registro);
            usuarios.Id = int.Parse(ExtrairCampo("id", registro));
            usuarios.Nome =ExtrairCampo("nome", registro);
            usuarios.Senha = ExtrairCampo("senha", registro);
            usuarios.Telefone = ExtrairCampo ("telefone", registro);
            usuarios.Empresa= ExtrairCampo("empresa", registro);
            usuarios.Email = ExtrairCampo ("email", registro);

            return usuarios;
        }
        private string PrepararRegistrosCSV(UsuarioModel usuario){

        return $"id={CONT};nome={usuario.Nome};empresa={usuario.Empresa};telefone={usuario.Telefone};email={usuario.Email};senha={usuario.Senha}\n";
        }


    }
}