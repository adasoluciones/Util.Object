using Ada.Framework.Util.Core.Exceptions;
using System;
using System.Collections;
using System.Reflection;

namespace Ada.Framework.Util.Object.ObjectScope
{
    /// <summary>
    /// Utilitario de reflexión con alcance de Object.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    internal class Objeto : IObjeto
    {
        /// <summary>
        /// Obtiene la representación de un objeto en string.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a representar.</param>
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
                if (_objeto == null)
                {
                    return "null";
                }
                
                //Primitivos no colecciones y enum.
                if (esPrimitivo(_objeto) && !esColeccion(_objeto))
                {
                    return _objeto.ToString();
                }

                //Primicia: No es primitivo (un enum también es un valor primitivo).

                string retorno = string.Empty;

                if (esDiccionario(_objeto))
                {
                    retorno = (tipoCompleto ? _objeto.GetType().FullName : _objeto.GetType().Name) + "{ ";
                    IDictionary dic = (_objeto as IDictionary);

                    if (_esRecursivo)
                    {
                        foreach (object clave in dic.Keys)
                        {
                            retorno += ToStr(clave, _esRecursivo, _representaNoPrimitivos, _representaColecciones, tipoCompleto) + " : " +
                                ToStr(dic[clave], _esRecursivo, _representaNoPrimitivos, _representaColecciones, tipoCompleto) + ", ";
                        }
                    }
                    else
                    {
                        retorno += "<" + dic.Keys.Count + " pares>";
                    }

                    if (retorno.Length > 2)
                    {
                        retorno = retorno.Substring(0, retorno.Length - 2);
                    }
                    retorno += " }";

                    return retorno;
                }

                //Primicia: No es primitivo ni un diccionario.

                retorno = (tipoCompleto ? _objeto.GetType().FullName : _objeto.GetType().Name);
                if (esColeccion(_objeto) && !tipoCompleto)
                {
                    retorno += "<" + Type.GetType(TipoSingular(_objeto)).Name + ">";
                }

                if (_representaNoPrimitivos)
                {
                    retorno += " { ";

                    if (esColeccion(_objeto))
                    {
                        if (_representaColecciones)
                        {
                            if (_esRecursivo)
                            {
                                IEnumerable enumeracion = _objeto as IEnumerable;

                                //Primicia: Es colección y se debe representar recursivamente.

                                foreach (object elemento in enumeracion)
                                {
                                    retorno += "[ " + ToStr(elemento, _esRecursivo, _representaNoPrimitivos, _representaColecciones, tipoCompleto) + " ], ";
                                }
                            }
                            else
                            {
                                retorno += "[ <No permite recursividad> ]";
                            }
                        }
                        else
                        {
                            IList coleccion = _objeto as IList;
                            retorno += "< " + coleccion.Count.ToString() + " elementos. >";
                        }
                    }
                    else
                    {
                        Type tipo = _objeto.GetType();

                        retorno = (tipoCompleto ? tipo.FullName : tipo.Name);
                        Type[] tipos = tipo.GetGenericArguments();

                        if (tipos.Length > 0)
                        {
                            retorno += "<";
                        }

                        foreach (Type tipoGenerico in tipos)
                        {
                            retorno += (tipoCompleto ? tipoGenerico.FullName : tipoGenerico.Name) + ",";
                        }

                        if (tipos.Length > 0)
                        {
                            retorno = retorno.Substring(0, retorno.Length - 1);
                            retorno += ">";
                        }

                        retorno += "{ ";

                        foreach (PropertyInfo propiedad in _objeto.GetType().GetProperties())
                        {
                            object valor = propiedad.GetValue(_objeto, null);

                            bool overFlow = (valor == _objeto);

                            if (!overFlow)
                            {
                                if (valor == null) valor = "null";
                                if (esPrimitivo(valor))
                                {
                                    retorno += propiedad.Name + " = " + valor.ToString() + " , ";
                                }
                                else
                                {
                                    if (_esRecursivo)
                                    {
                                        retorno += propiedad.Name + " = " + ToStr(valor, _esRecursivo, _representaNoPrimitivos, _representaColecciones, tipoCompleto) + " , ";
                                    }
                                }
                            }
                        }
                    }

                    if (_objeto.GetType().GetProperties().Length > 0)
                    {
                        retorno = retorno.Substring(0, retorno.Length - 2);
                    }
                    retorno += " }";
                }
                else
                {
                    retorno += "{ <No permite representar valores no primitivos> }";
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene la representación del tipo de un objeto.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a representar.</param>
        /// <param name="_recursivo">Permite desplazarse mediente las propiedades del objeto.</param>
        /// <param name="tipoCompleto">Indica si se debe incluir el tipo completo de cada objeto (Name o FullName).</param>
        /// <returns></returns>
        [Obsolete("En su lugar utilice Data.Json.dll y conviértalo a JSON incluyendo los tipos.")]
        public string ToStrType(object _objeto, bool _recursivo = true, bool tipoCompleto = false)
        {
            try
            {
                if (_objeto == null) return "null";
                return TypeScope.ObjetoFactory.ObtenerObjeto().ToStrType(_objeto.GetType(), _recursivo, tipoCompleto);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo creado por el usuario (no primitivo) o de C#(primitivo).
        /// Llama a TypeScope con GetType() del objeto.
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
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esPrimitivo(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esPrimitivo(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo colección.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esColeccion(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esColeccion(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo Enum.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esEnumeracion(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esEnumeracion(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo decimal.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDecimal(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esDecimal(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo numérico.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esNumero(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esNumero(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo bool.
        /// Llama a TypeScope con GetType() del objeto.
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
                return TypeScope.ObjetoFactory.ObtenerObjeto().esBooleano(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo string. Opcionalmente ofrece que interprete un char como string o no.
        /// Por defecto no se toma un char como string.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <param name="_incluirChar">Indica si se debe tratar a un char como un string. [Opcional]</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esString(object _objeto, bool _incluirChar = false)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esString(_objeto.GetType(), _incluirChar);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un objeto es de tipo <see cref="System.Collections.IDictionary"/>.
        /// Llama a TypeScope con GetType() del objeto.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDiccionario(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().esDiccionario(_objeto.GetType());
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular de una colección.
        /// Llama a TypeScope con GetType() del objeto.
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
        /// <param name="_objeto">Objeto a comprobar.</param>
        /// <returns>AssemblyQualifiedName del tipo en singular.</returns>
        public string TipoSingular(object _objeto)
        {
            try
            {
                return TypeScope.ObjetoFactory.ObtenerObjeto().TipoSingular(_objeto.GetType());
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
            InfoScope.IObjeto objetoInfo = InfoScope.ObjetoFactory.ObtenerObjeto();

            string[] propiedades = propiedad.Split('.');
            foreach (string prop in propiedades)
            {
                PropertyInfo xprop = objetoInfo.GetPropiedad(objeto, prop);

                if (objetoInfo.GetValorPropiedad(objeto, xprop) == null)
                {
                    if (Util.Object.ObjetoFactory.ObtenerObjeto().esPrimitivo(xprop))
                    {
                        objetoInfo.SetValorPropiedad(objeto, xprop, valor);
                    }
                    else
                    {
                        objetoInfo.SetValorPropiedad(objeto, xprop, ObtenerInstancia(xprop.PropertyType.Name));
                    }
                }
            }
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
            return InfoScope.ObjetoFactory.ObtenerObjeto().GetPropiedad(objeto, propiedad);
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
            return TypeScope.ObjetoFactory.ObtenerObjeto().ObtenerInstancia(Type.GetType(tipo), parametros);
        }
    }
}
