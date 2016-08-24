using System.Reflection;

namespace Ada.Framework.Util.Object.InfoScope
{
    /// <summary>
    /// Contrato de el utilitario de reflexión con alcance de Info.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public interface IObjeto
    {
        /// <summary>
        /// Comprueba si una propiedad es de tipo bool.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esBooleano(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo colección.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esColeccion(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo decimal.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esDecimal(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo <see cref="System.Collections.IDictionary"/>.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esDiccionario(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo Enum.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esEnumeracion(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo numérico.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esNumero(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo creado por el usuario (no primitivo) o de C#(primitivo).
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
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esPrimitivo(PropertyInfo _propiedad);

        /// <summary>
        /// Comprueba si una propiedad es de tipo string. Opcionalmente ofrece que interprete un char como string o no.
        /// Por defecto no se toma un char como string.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <param name="_incluirChar">Indica si se debe tratar a un char como un string. [Opcional]</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        bool esString(PropertyInfo _propiedad, bool _incluirChar = false);

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
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns>AssemblyQualifiedName del tipo en singular.</returns>
        string TipoSingular(PropertyInfo _propiedad);

        /// <summary>
        /// Obtiene la propiedad de un objeto mediante reflexión. Además es válido enviar la propiedad de una propiedad
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
        PropertyInfo GetPropiedad(object objeto, string propiedad);

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
        /// Cambia el valor de la propiedad de un objeto, especificado, mediante reflexión.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 13/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="objeto">Objeto.</param>
        /// <param name="propiedad">Nombre de la propiedad.</param>
        /// <param name="valor">Valor de la propiead.</param>
        /// <returns></returns>
        void SetValorPropiedad(object objeto, PropertyInfo propiedad, object valor);

        /// <summary>
        /// Obtiene el valor de la propiedad de un objeto, especificado, mediante reflexión.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 13/10/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="objeto">Objeto.</param>
        /// <param name="propiedad">Nombre de la propiedad.</param>
        /// <returns></returns>
        object GetValorPropiedad(object objeto, PropertyInfo propiedad);
    }
}
