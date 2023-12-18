using Microsoft.Extensions.Configuration;
using SistemaVenda.Forms;
using SistemaVenda.View.Painel;

namespace SistemaVenda
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuLogin());
            //Application.Run(new PainelPrincipalGerente());
            //Application.Run(new PainelPrincipalGerente());
        }
    }
}   