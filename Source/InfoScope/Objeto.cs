using Ada.Framework.Util.Core.Exceptions;
using System;
using System.Reflection;

namespace Ada.Framework.Util.Object.InfoScope
{
    /// <summary>
    /// Utilitario de reflexión con alcance de Info.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    internal class Objeto : IObjeto
    {
        /// <summary>
        /// Comprueba si una propiedad es de tipo creado por el usuario (no primitivo) o de C#(primitivo).
        /// Llama a TypeScope con la PropertyType de la propiedad.
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
        public bool esPrimitivo(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esPrimitivo(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo Enum.
        /// Llama a TypeScope con la PropertyType de la propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esEnumeracion(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esEnumeracion(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            } 
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo <see cref="System.Collections.IDictionary"/>.
        /// Llama a TypeScope con la PropertyType de la propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDiccionario(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esDiccionario(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo colección.
        /// Llama a TypeScope con la PropertyType de la propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esColeccion(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esColeccion(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo string. Opcionalmente ofrece que interprete un char como string o no.
        /// Por defecto no se toma un char como string.
        /// Llama a TypeScope con la PropertyType de la propiedad.
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
        public bool esString(PropertyInfo _propiedad, bool _incluirChar = false)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esString(_propiedad.PropertyType, _incluirChar);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo decimal.
        /// Llama a TypeScope con la PropertyType de la propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDecimal(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esDecimal(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo bool.
        /// Llama a TypeScope con la PropertyType de la propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esBooleano(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esBooleano(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si una propiedad es de tipo numérico.
        /// Llama a TypeScope con la PropertyType de la propiedad.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_propiedad">Propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esNumero(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esNumero(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular de una colección.
        /// Llama a TypeScope con la PropertyType de la propiedad.
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
        public string TipoSingular(PropertyInfo _propiedad)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().TipoSingular(_propiedad.PropertyType);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }
        
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
        public PropertyInfo GetPropiedad(object objeto, string propiedad)
        {
            string[] propiedades = propiedad.Split('.');
            PropertyInfo retorno = null;

            object obj = objeto;

            foreach (string prop in propiedades)
            {
                retorno = obj.GetType().GetProperty(prop);
                obj = retorno.GetValue(obj, null);
            }

            return retorno;
        }

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
        public object GetValorPropiedad(object objeto, string propiedad)
        {
            return GetPropiedad(objeto, propiedad).GetValue(objeto, null);
        }

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
        public void SetValorPropiedad(object objeto, PropertyInfo propiedad, object valor)
        {
            propiedad.SetValue(objeto, valor, null);
        }

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
        public object GetValorPropiedad(object objeto, PropertyInfo propiedad)
        {
            return propiedad.GetValue(objeto, null);
        }
    }
}
