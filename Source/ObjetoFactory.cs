using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ada.Framework.Util.Object
{
    /// <summary>
    /// Factoría del utilitario de reflexión.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public static class ObjetoFactory
    {
        /// <summary>
        /// Obtiene la instancia de una implementación de <see cref="Ada.Framework.Util.Object.IObjeto"/>.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <returns></returns>
        public static IObjeto ObtenerObjeto()
        {
            return new Objeto();
        }
    }
}
