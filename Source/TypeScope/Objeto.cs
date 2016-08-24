using Ada.Framework.Util.Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Ada.Framework.Util.Object.TypeScope
{
    /// <summary>
    /// Utilitario de reflexión con alcance de Type.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    internal class Objeto : IObjeto
    {
        /// <summary>
        /// Comprueba si tipo es creado por el usuario (no primitivo) o de C#(primitivo).
        /// Para ello utiliza el <see cref="System.TypeCode"/> (TypeCode.Object) del tipo y de los argumentos genéricos.
        /// De ser colección comprueba que el tipo de la colección, sea primitiva también.
        /// Si se trata de un diccionario comprueba ambos tipos genéricos recursivamente.
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
        public bool esPrimitivo(Type _tipo)
        {
            try
            {
                TypeCode codigoTipo = Type.GetTypeCode(_tipo);

                if (esDiccionario(_tipo))
                {
                    Type[] argumentos = _tipo.GetGenericArguments();

                    return esPrimitivo(argumentos[0]) && esPrimitivo(argumentos[1]);
                }

                if (esColeccion(_tipo))
                {
                    Type tipoSingular = Type.GetType(TipoSingular(_tipo));
                    return esPrimitivo(tipoSingular);
                }

                if (codigoTipo == TypeCode.Object)
                {
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un tipo es <see cref="System.Collections.IDictionary"/>.
        /// Para ello comprueba si el tipo es asignable a <see cref="System.Collections.IDictionary"/>, si contiene 2 argumentos genéricos
        /// y si el nombre del tipo contiene "dictionary";
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDiccionario(Type _tipo)
        {
            try
            {
                bool retorno = typeof(IDictionary).IsAssignableFrom(_tipo);

                if (!retorno)
                {
                    return _tipo.GetGenericArguments().Length == 2 && _tipo.Name.ToLower().Contains("dictionary");
                }

                return retorno;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un tipo es un Enum.
        /// Para ello comprueba que el tipo sea <see cref="System.Enum"/> o el tipo base de éste, lo sea.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esEnumeracion(Type _tipo)
        {
            try
            {
                return _tipo == typeof(Enum) || _tipo.BaseType == typeof(Enum);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }
        
        /// <summary>
        /// Comprueba si un tipo es una colección.
        /// Descartando a un string, comprueba si el tipo es asignable a <see cref="System.Collections.IEnumerable"/>.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esColeccion(Type _tipo)
        {
            try
            {
                if (_tipo.Name.Contains("String") && !_tipo.Name.Contains("List") && !_tipo.Name.Contains("[") && !_tipo.Name.Contains("]"))
                {
                    return false;
                }

                bool retorno = typeof(IEnumerable).IsAssignableFrom(_tipo);

                if (!retorno)
                {
                    if (_tipo.IsGenericTypeDefinition)
                    {
                        retorno = typeof(IEnumerable).IsAssignableFrom(_tipo.GetGenericTypeDefinition())
                                    || typeof(IEnumerable<>).IsAssignableFrom(_tipo.GetGenericTypeDefinition());
                    }
                }

                return typeof(IEnumerable).IsAssignableFrom(_tipo);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

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
        public bool esString(Type _tipo, bool _incluirChar = false)
        {
            try
            {
                if (_incluirChar)
                {
                    return typeof(string) == _tipo || typeof(char) == _tipo;
                }
                return typeof(string) == _tipo;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un tipo es un decimal.
        /// Para ello recurre al <see cref="System.TypeCode"/> en cuyo caso considera como decimales:
        ///     - TypeCode.Decimal
        ///     - TypeCode.Double
        ///     - TypeCode.Single.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esDecimal(Type _tipo)
        {
            try
            {
                switch (Type.GetTypeCode(_tipo))
                {
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

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
        public bool esBooleano(Type _tipo)
        {
            try
            {
                return typeof(bool) == _tipo;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Comprueba si un tipo es numérico.
        /// Para ello recurre al <see cref="System.TypeCode"/> en cuyo caso considera como números:
        ///     - TypeCode.Byte
        ///     - TypeCode.SByte
        ///     - TypeCode.UInt16
        ///     - TypeCode.UInt32
        ///     - TypeCode.UInt64
        ///     - TypeCode.Int16
        ///     - TypeCode.Int32
        ///     - TypeCode.Int64
        ///     - TypeCode.Decimal
        ///     - TypeCode.Double
        ///     - TypeCode.Single 
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <exception cref="Ada.Framework.Util.Core.Exceptions.UtilException">Es lanzado al ocurrir una excepción en tiempo de ejecución de cualquier tipo.</exception>
        /// <param name="_tipo">Tipo a comprobar.</param>
        /// <returns><value>true</value> en caso de serlo, o <value>false</value> de lo contrario.</returns>
        public bool esNumero(Type _tipo)
        {
            try
            {
                switch (Type.GetTypeCode(_tipo))
                {
                    case TypeCode.Byte:
                    case TypeCode.SByte:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene el tipo (AssemblyQualifiedName) en singular de un tipo que sea una colección.
        /// Llama a OtherScope con la AssemblyQualifiedName del tipo.
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
        public string TipoSingular(Type _tipo)
        {
            try
            {
                return new OtherScope.Objeto().TipoSingular(_tipo.AssemblyQualifiedName);
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
        }

        /// <summary>
        /// Obtiene la representación de un tipo.
        /// Llama a ToStrType(Type, IList of Type, bool, bool).
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
        public string ToStrType(Type tipo, bool _recursivo = true, bool tipoCompleto = false) 
        {
            IList<Type> tipos = new List<Type>();
            return ToStrType(tipo, tipos, _recursivo, tipoCompleto);
        }

        /// <summary>
        /// Obtiene la representación de un tipo, acumulando los tipos ya descritos. (Privado)
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="tipo">Tipo a representar.</param>
        /// <param name="tiposDescritos">Lista de tipos descritos anteriormente.</param>
        /// <param name="_recursivo">Permite desplazarse mediente las propiedades del tipo.</param>
        /// <param name="tipoCompleto">Indica si se debe incluir el tipo completo (Name o FullName).</param>
        /// <returns></returns>
        [Obsolete("En su lugar utilice Data.Json.dll y conviértalo a JSON incluyendo los tipos.")]
        private string ToStrType(Type tipo, IList<Type> tiposDescritos, bool _recursivo = true, bool tipoCompleto = false)
        {
            try
            {
                if (tipo == null)
                {
                    return "null";
                }

                if (tiposDescritos.Contains(tipo))
                {
                    return tipo.Name;
                }
                
                //Primitivos no colecciones y enum.
                if (esPrimitivo(tipo) && !esColeccion(tipo))
                {
                    return tipoCompleto ? tipo.FullName : tipo.Name;
                }

                //Primicia: No es primitivo (un enum también es un valor primitivo).

                string retorno = string.Empty;

                if (esDiccionario(tipo))
                {
                    retorno = (tipoCompleto ? tipo.FullName : tipo.Name) + "<";
                    Type[] argumentos = tipo.GetGenericArguments();

                    foreach (Type argumento in argumentos)
                    {
                        tiposDescritos.Add(argumento);
                        retorno += ToStrType(argumento, tiposDescritos, _recursivo, tipoCompleto) + ",";
                    }

                    return retorno;
                }

                if (esColeccion(tipo))
                {
                    retorno = (tipoCompleto ? tipo.FullName : tipo.Name);

                    if (esPrimitivo(tipo))
                    {
                        retorno += "[" + Type.GetType(TipoSingular(tipo)).Name + "]";

                        return retorno;
                    }
                    else
                    {
                        if (_recursivo)
                        {
                            tiposDescritos.Add(Type.GetType(TipoSingular(tipo)));
                            retorno += "[" + ToStrType(Type.GetType(TipoSingular(tipo)), tiposDescritos, _recursivo, tipoCompleto) + "]";

                            return retorno;
                        }
                        else
                        {
                            if (!tipoCompleto)
                            {
                                tiposDescritos.Add(Type.GetType(TipoSingular(tipo)));
                                retorno += "[" + Type.GetType(TipoSingular(tipo)).Name + " { <No se permite la recursividad> } ]";
                            }
                            return retorno;
                        }
                    }
                }

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

                foreach (PropertyInfo propiedad in tipo.GetProperties())
                {
                    if (propiedad.PropertyType != tipo)
                    {
                        if (esPrimitivo(propiedad.PropertyType) && !esColeccion(propiedad.PropertyType))
                        {
                            retorno += propiedad.Name + " = " + (tipoCompleto ? propiedad.PropertyType.FullName : propiedad.PropertyType.Name) + " , ";
                        }
                        else
                        {
                            if (_recursivo)
                            {
                                tiposDescritos.Add(propiedad.PropertyType);
                                retorno += propiedad.Name + " = " + ToStrType(propiedad.PropertyType, tiposDescritos, _recursivo, tipoCompleto) + " , ";
                            }
                            else
                            {
                                retorno += propiedad.Name + " = " + (tipoCompleto ? propiedad.PropertyType.FullName : propiedad.PropertyType.Name) + "<No se permite la recursividad> , ";
                            }
                        }
                    }
                    else
                    {
                        retorno += propiedad.Name + " = " + tipo.Name + "<Recursivo> , ";
                    }
                }

                if (tipo.GetProperties().Length > 0)
                {
                    retorno = retorno.Substring(0, retorno.Length - 2);
                }

                retorno += " }";

                return retorno;
            }
            catch (Exception e)
            {
                throw new UtilException(e.Message, e);
            }
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
        public object ObtenerInstancia(Type tipo, object[] parametros = null)
        {
            if (parametros == null)
            {
                return Activator.CreateInstance(tipo);
            }
            return Activator.CreateInstance(tipo, parametros);
        }
    }
}
