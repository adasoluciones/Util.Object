using System;

namespace Ada.Framework.Util.Object.TypeScope
{
    /// <summary>
    /// Contrato de el utilitario de reflexión con alcance de Type.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public interface IObjeto
    {
        /// <summary>
        /// Comprueba si un tipo es bool.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esBooleano(Type _tipo);

        /// <summary>
        /// Comprueba si un tipo es una colección.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esColeccion(Type _tipo);

        /// <summary>
        /// Comprueba si un tipo es un decimal.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esDecimal(Type _tipo);

        /// <summary>
        /// Comprueba si un tipo es <see cref="System.Collections.IDictionary"/>.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esDiccionario(Type _tipo);

        /// <summary>
        /// Comprueba si un tipo es un Enum.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esEnumeracion(Type _tipo);

        /// <summary>
        /// Comprueba si un tipo es numérico.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esNumero(Type _tipo);

        /// <summary>
        /// Comprueba si tipo es creado por el usuario (no primitivo) o de C#(primitivo).
        /// <example>
        ///     typeof(bool)                 --> Primitivo
        ///     typeof(string)               --> Primitivo
        ///     typeof(String)               --> Primitivo
        ///     typeof(UsuarioTO)            --> No primitivo.
        /// </example>
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esPrimitivo(Type _tipo);

        /// <summary>
        /// Comprueba si un tipo es string. Opcionalmente ofrece que interprete un char como string o no.
        /// Por defecto no se toma un char como string.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <param name="_incluirChar">Indica si se debe tratar a un char como un string. [Opcional]</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esString(Type _tipo, bool _incluirChar = false);

        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular de un tipo que sea una colección.
        /// <example>
        ///     string tS = TipoSingular(typeof(IList of UsuarioTO));
        ///         - ts es entonces UsuarioTO.
        /// </example>
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns>AssemblyQualifiedName del tipo en singular.</returns>
        string TipoSingular(Type _tipo);

        /// <summary>
        /// Obtiene la representación de un tipo.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="tipo">Tipo a representar.</param>
        /// <param name="_recursivo">Permite desplazarse mediente las propiedades del tipo.</param>
        /// <param name="tipoCompleto">Indica si se debe incluir el tipo completo (Name o FullName).</param>
        /// <returns></returns>
        [Obsolete("En su lugar utilice Data.Json.dll y conviértalo a JSON incluyendo los tipos.")]
        string ToStrType(Type tipo, bool _recursivo = true, bool tipoCompleto = false);

         /// <summary>
        /// Obtiene una nueva instancia del tipo especificado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 13/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="tipo">Tipo de la instancia.</param>
        /// <param name="parametros">Array de parametros del contructor de ese tipo.</param>
        /// <returns></returns>
        object ObtenerInstancia(Type tipo, object[] parametros = null);
    }
}
