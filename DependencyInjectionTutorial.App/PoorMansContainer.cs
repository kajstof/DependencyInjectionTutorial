using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DependencyInjectionTutorial.App
{
    public class PoorMansContainer
    {
        private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

        public void RegisterType<T>()
        {
            _registrations.Add(typeof(T), typeof(T));
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _registrations.Add(typeof(TInterface), typeof(TImplementation));
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            bool implementationFound = _registrations.TryGetValue(type, out var implementationType);
            if (implementationFound == false)
            {
                throw new TypeNotRegisteredException(type);
            }

            ConstructorInfo[] ctors = implementationType.GetConstructors();

            if (ctors.Length == 0)
            {
                throw new NoConstructorFoundException(type);
            }

            if (ctors.Length > 1)
            {
                throw new MultipleConstructorFoundException(type);
            }

            object[] ctorParams = ctors[0].GetParameters()
                .Select(x => Resolve(x.ParameterType))
                .ToArray();

            return Activator.CreateInstance(type, ctorParams);
        }
    }
    
    public abstract class ResolveException : Exception
    {
        public readonly Type Type;

        public ResolveException(Type type, string message, Exception innerException) : base(message, innerException)
        {
            type = type;
        }
    }
    
    public class TypeNotRegisteredException : ResolveException
    {
        public TypeNotRegisteredException(Type type)
            : base(type, string.Format("Type {0} not registered in the constructor", type.Name), new Exception())
        {
        }
    }
    
    public class NoConstructorFoundException : ResolveException
    {
        public NoConstructorFoundException(Type type)
            : base(type, string.Format("Type {0} does not have any constructor", type.Name), new Exception())
        {
        }
    }
    
    public class MultipleConstructorFoundException : ResolveException
    {
        public MultipleConstructorFoundException(Type type)
            : base(type, string.Format("Type {0} has more than one constructor", type.Name), new Exception())
        {
        }
    }
}