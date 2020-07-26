using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintService.Infra.Utils
{
    public static class Configuracao
    {
        public static T ObterConfiguracao<T>(string nomeConfiguracao)
        {
            var configuracao = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            return configuracao.GetValue<T>(nomeConfiguracao);
        }

        public static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();

            var connectionString = configuracao.GetConnectionString("Default");
            return Criptografia.Descritografar(connectionString);
        }
    }
}
