
using System;
namespace Ada.Framework.Util.Object
{
    /// <summary>
    /// Contrato de el utilitario de reflexión.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public interface IObjeto
    {
        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo bool.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esBooleano(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo colección.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esColeccion(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo decimal.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esDecimal(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo <see cref="System.Collections.IDictionary"/>.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esDiccionario(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo Enum.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esEnumeracion(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo creado por el usuario (no primitivo) o de C#(primitivo).
        /// <example>
        ///     bool a = false;                 --> Primitivo
        ///     string a = "Hola Mundo";                 --> Primitivo
        ///     String a = String.Empty;                 --> Primitivo
        ///     UsuarioTO a = new UsuarioTO();  --> No primitivo.
        /// </example>
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esNumero(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es creado por el usuario (no primitivo) o de C#(primitivo).
        /// <example>
        ///     bool a = false;                 --> Primitivo
        ///     string a = "Hola Mundo";        --> Primitivo
        ///     String a = String.Empty;        --> Primitivo
        ///     UsuarioTO a = new UsuarioTO();  --> No primitivo.
        /// </example>
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esPrimitivo(object _objeto);

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo string. Opcionalmente ofrece que interprete un char como string o no.
        /// Por defecto no se toma un char como string.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <param name="_incluirChar">Indica si se debe tratar a un char como un string. [Opcional]</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esString(object _objeto, bool _incluirChar = false);

        /// <summary>
        /// Obtiene la representación de un objeto, tipo o propiedad en string.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objet, tipo o propiedado a representar.</param>
        /// <param name="_esRecursivo">Permite desplazarse mediente las propiedades del objeto.</param>
        /// <param name="_representaNoPrimitivos">Permite representar el tipo de los valores no primitivos propiedad por propiedad, o sólo indicar su nombre.</param>
        /// <param name="_representaColecciones">Permite representar colecciones. Itera por cada elemento.</param>
        /// <param name="tipoCompleto">Indica si se debe incluir el tipo completo de cada objeto (Name o FullName)</param>
        /// <returns></returns>
        [Obsolete("En su lugar utilice Data.Json.dll y conviértalo a JSON.")]
        string ToStr(object _objeto, bool _esRecursivo = false, bool _representaNoPrimitivos = false, bool _representaColecciones = false, bool tipoCompleto = false);

        /// <summary>
        /// Obtiene la representación del tipo de un objeto, tipo o propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a representar.</param>
        /// <param name="_recursivo">Permite desplazarse mediente las propiedades del objeto.</param>
        /// <param name="tipoCompleto">Indica si se debe incluir el tipo completo de cada objeto (Name o FullName).</param>
        /// <returns></returns>
        [Obsolete("En su lugar utilice Data.Json.dll y conviértalo a JSON incluyendo los tipos.")]
        string ToStrType(object _objeto, bool _recursivo = true, bool tipoCompleto = false);

        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular de una colección.
        /// <example>
        ///     string tS = TipoSingular(IList of UsuarioTO);
        ///         - ts es entonces UsuarioTO.
        /// </example>
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns>AssemblyQualifiedName del tipo en singular.</returns>
        string TipoSingular(object _objeto);

       /// <summary>
        /// Cambia el valor de la propiedad de un objeto, mediante reflexión.Además es válido enviar la propiedad de una propiedad
        /// del modo "Direccion.NumeroCasa". 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 13/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="objeto">Objeto.</param>
        /// <param name="propiedad">Nombre de la propiedad.</param>
        /// <param name="valor">Valor de la propiedad.</param>
        void SetValorPropiedad(object objeto, string propiedad, object valor);

        /// <summary>
        /// Obtiene el valor de la propiedad de un objeto, especificado, mediante reflexión. Además es válido enviar la propiedad de una propiedad
        /// del modo "Direccion.NumeroCasa". 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 13/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="objeto">Objeto.</param>
        /// <param name="propiedad">Nombre de la propiedad.</param>
        /// <returns></returns>
        object GetValorPropiedad(object objeto, string propiedad);

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
        object ObtenerInstancia(string tipo, object[] parametros = null);
    }
}
