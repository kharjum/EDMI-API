using System;
using System.Linq;
using Xunit;

namespace EDMI.API.Tests
{
    /// <summary>
    /// Clase base para los tests unitarios
    /// </summary>
    public class BaseTest : IClassFixture<CompositionRootFixture>
    {
        protected readonly CompositionRootFixture Fixture;

        public BaseTest(CompositionRootFixture fixture)
        {
            this.Fixture = fixture;
        }

        /// <summary>
        /// Creación de una cadena de caracteres aleatoria de una longitud determinada
        /// </summary>
        /// <param name="length">Longitud de la cadena que deseamos generar</param>
        /// <returns>Cadena de caracteres de longitud dada</returns>
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Creación de un entero aleatorio
        /// </summary>
        /// <param name="min">Valor mínimo que deseamos que nos devuelva</param>
        /// <param name="max">Valor máximo que deseamos que nos devuelva</param>
        /// <returns>Valor entero aleatorio</returns>
        public int RandomInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
