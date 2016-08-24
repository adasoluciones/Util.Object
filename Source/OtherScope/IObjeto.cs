
namespace Ada.Framework.Util.Object.OtherScope
{
    /// <summary>
    /// Contrato de el utilitario de reflexión con alcance de Other.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public interface IObjeto
    {
        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular del nombre completo del ensamblado de un tipo(AssemblyQualifiedName). 
        /// <example>
        ///     string tS = TipoSingular("IList<UsuarioTO/>;v1.0;publicKeyToken=065djhkg645;a.dll");
        ///         - ts es entonces "UsuarioTO;v1.0;publicKeyToken=065djhkg645;a.dll".
        ///     NOTA: El AssemblyQualifiedName de ejemplo, no es fielmente correcto. Sólo es para hacerse una idea.
        /// </example>
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_assemblyQualifiedName">AssemblyQualifiedName de la colección.</param>
        /// <returns>AssemblyQualifiedName del tipo en singular.</returns>
        string TipoSingular(string _assemblyQualifiedName);
    }
}
