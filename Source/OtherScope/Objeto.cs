using Ada.Framework.Util.Core.Exceptions;
using System;

namespace Ada.Framework.Util.Object.OtherScope
{
    /// <summary>
    /// Utilitario de reflexión con alcance de Other.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    internal class Objeto : IObjeto
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
        public string TipoSingular(string _assemblyQualifiedName)
        {
            try
            {
                string retorno = _assemblyQualifiedName;
                string assemblyName = _assemblyQualifiedName.Replace("[", "").Replace("]", "");
                if (assemblyName.Contains("List"))
                {
                    assemblyName = assemblyName.Substring(assemblyName.IndexOf("List") + 6);
                    assemblyName = assemblyName.Replace(_assemblyQualifiedName, "");
                    _assemblyQualifiedName = _assemblyQualifiedName.Substring(0, _assemblyQualifiedName.IndexOf("]"));
                }

                int largo = assemblyName.IndexOf(",");

                if (largo != -1)
                {
                    assemblyName = assemblyName.Substring(0, largo);
                }

                string typeName = assemblyName.Substring(assemblyName.IndexOf(".") + 1);
                assemblyName = assemblyName.Substring(0, assemblyName.IndexOf("."));

                retorno = assemblyName + "." + typeName + _assemblyQualifiedName.Substring(_assemblyQualifiedName.IndexOf(","));
                return retorno;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }
    }
}
