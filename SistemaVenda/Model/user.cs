using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.Classes
{
    internal class user
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string papel { get; set; }
    }

    internal static class Sessao
    {
        private static User usuarioLogado;

        public static User UsuarioLogado
        {
            get { return usuarioLogado; }
            set { usuarioLogado = value; }
        }

        public static bool UsuarioEstaLogado
        {
            get { return usuarioLogado != null; }
        }
    }
}
