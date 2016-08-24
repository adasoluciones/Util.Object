using Ada.Framework.Util.Core.Exceptions;
using System;
using System.Reflection;

namespace Ada.Framework.Util.Object
{
    /// <summary>
    /// Utilitario de reflexión.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    internal class Objeto : IObjeto
    {
        /// <summary>
        /// Obtiene la representación de un objeto, tipo o propiedad en string.
        /// Llama a ObjectScope con el objeto.
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
        public string ToStr(object _objeto, bool _esRecursivo = false, bool _representaNoPrimitivos = false, bool _representaColecciones = false, bool tipoCompleto = false)
        {
            try
            {
                return ObjectScope.ObjetoFactory.ObtenerObjeto().ToStr(_objeto, _esRecursivo, _representaNoPrimitivos, _representaColecciones, tipoCompleto);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene la representación del tipo de un objeto, tipo o propiedad.
        /// Llama a ObjectScope con el objeto.
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
        public string ToStrType(object _objeto, bool _recursivo = true, bool tipoCompleto = false)
        {
            try
            {
                return ObjectScope.ObjetoFactory.ObtenerObjeto().ToStrType(_objeto, _recursivo, tipoCompleto);
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es creado por el usuario (no primitivo) o de C#(primitivo).
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
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
        public bool esPrimitivo(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return TypeScope.ObjetoFactory.ObtenerObjeto().esPrimitivo(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return InfoScope.ObjetoFactory.ObtenerObjeto().esPrimitivo(_objeto as PropertyInfo);
                }
                else
                {
                    return ObjectScope.ObjetoFactory.ObtenerObjeto().esPrimitivo(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo colección.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esColeccion(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esColeccion(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esColeccion(_objeto as PropertyInfo);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esColeccion(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo Enum.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esEnumeracion(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esEnumeracion(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esEnumeracion(_objeto as PropertyInfo);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esEnumeracion(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo <see cref="System.Collections.IDictionary"/>.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDiccionario(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esDiccionario(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esDiccionario(_objeto as PropertyInfo);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esDiccionario(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo decimal.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto, tipo o propiedad a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDecimal(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esDecimal(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esDecimal(_objeto as PropertyInfo);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esDecimal(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo creado por el usuario (no primitivo) o de C#(primitivo).
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
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
        public bool esNumero(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esNumero(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esNumero(_objeto as PropertyInfo);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esNumero(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo bool.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esBooleano(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esBooleano(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esBooleano(_objeto as PropertyInfo);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esBooleano(_objeto);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto, tipo o propiedad es de tipo string. Opcionalmente ofrece que interprete un char como string o no.
        /// Por defecto no se toma un char como string.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
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
        public bool esString(object _objeto, bool _incluirChar = false)
        {
            try
            {
                if (_objeto is Type)
                {
                    return  TypeScope.ObjetoFactory.ObtenerObjeto().esString(_objeto as Type, _incluirChar);
                }
                else if (_objeto is PropertyInfo)
                {
                    return  InfoScope.ObjetoFactory.ObtenerObjeto().esString(_objeto as PropertyInfo, _incluirChar);
                }
                else
                {
                    return  ObjectScope.ObjetoFactory.ObtenerObjeto().esString(_objeto, _incluirChar);
                }
            }
            catch (Exception e)
            {
                throw  new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular de una colección.
        /// De ser un tipo, llama a TypeScope con _objeto as Type. Si es una propiedad, llama a InfoScope con _objeto as PropertyInfo.
        /// De lo contrario, llama a ObjectScope con el objeto.
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
        public string TipoSingular(object _objeto)
        {
            try
            {
                if (_objeto is Type)
                {
                    return TypeScope.ObjetoFactory.ObtenerObjeto().TipoSingular(_objeto as Type);
                }
                else if (_objeto is PropertyInfo)
                {
                    return InfoScope.ObjetoFactory.ObtenerObjeto().TipoSingular(_objeto as PropertyInfo);
                }
                else
                {
                    return ObjectScope.ObjetoFactory.ObtenerObjeto().TipoSingular(_objeto);
                }
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

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
        public void SetValorPropiedad(object objeto, string propiedad, object valor)
        {
            ObjectScope.ObjetoFactory.ObtenerObjeto().SetValorPropiedad(objeto, propiedad, valor);
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
            return InfoScope.ObjetoFactory.ObtenerObjeto().GetValorPropiedad(objeto, propiedad);
        }

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
        public object ObtenerInstancia(string tipo, object[] parametros = null)
        {
            return ObjectScope.ObjetoFactory.ObtenerObjeto().ObtenerInstancia(tipo, parametros);
        }
    }
}
