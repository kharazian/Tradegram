using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Text;

namespace Volo.Abp.Reflection
{
    /// <summary>
    /// Abstract static type factory. With supports of type overriding and sets special factories.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public static class AbstractTypeFactory<TBaseType>
    {
        private static List<TypeInfo<TBaseType>> _typeInfo = new List<TypeInfo<TBaseType>>();

        /// <summary>
        /// All registered type mapping information within current factory instance
        /// </summary>
        public static IEnumerable<TypeInfo<TBaseType>> AllTypeInfos => _typeInfo;

        /// <summary>
        /// Register new  type (fluent method)
        /// </summary>
        /// <returns>TypeInfo instance to continue configuration through fluent syntax</returns>
        public static TypeInfo<TBaseType> RegisterType<T>() where T : TBaseType
        {
            var kowTypes = _typeInfo.SelectMany(x => x.AllSubclasses);

            if (kowTypes.Contains(typeof(T)))
            {
                throw new ArgumentException($"Type {typeof(T).Name} already registered");
            }

            var retVal = new TypeInfo<TBaseType>(typeof(T));
            _typeInfo.Add(retVal);

            return retVal;
        }

        /// <summary>
        /// Override already registered  type to new 
        /// </summary>
        /// <returns>TypeInfo instance to continue configuration through fluent syntax</returns>
        public static TypeInfo<TBaseType> OverrideType<TOldType, TNewType>() where TNewType : TBaseType
        {
            var oldType = typeof(TOldType);
            var newType = typeof(TNewType);
            var existTypeInfo = _typeInfo.FirstOrDefault(x => x.Type == oldType);
            var newTypeInfo = new TypeInfo<TBaseType>(newType);

            if (existTypeInfo != null)
            {
                _typeInfo.Remove(existTypeInfo);
            }

            _typeInfo.Add(newTypeInfo);

            return newTypeInfo;
        }

        /// <summary>
        /// Create BaseType instance considering type mapping information
        /// </summary>
        /// <returns></returns>
        public static TBaseType TryCreateInstance()
        {
            return TryCreateInstance(typeof(TBaseType).Name);
        }

        /// <summary>
        /// Create derived from BaseType  specified type instance considering type mapping information
        /// </summary>
        /// <returns></returns>
        public static T TryCreateInstance<T>() where T : TBaseType
        {
            return (T) TryCreateInstance(typeof(T).Name);
        }

        public static TBaseType TryCreateInstance(string typeName)
        {
            TBaseType retVal;

            //Try find first direct type match from registered types
            var typeInfo = _typeInfo.FirstOrDefault(x => x.Type.Name.EqualsInvariant(typeName));

            //Then need to find in inheritance chain from registered types
            if (typeInfo == null)
            {
                typeInfo = _typeInfo.FirstOrDefault(x => x.IsAssignableTo(typeName));
            }

            if (typeInfo != null)
            {
                if (typeInfo.Factory != null)
                {
                    retVal = typeInfo.Factory();
                }
                else
                {
                    retVal = (TBaseType) Activator.CreateInstance(typeInfo.Type);
                }
            }
            else
            {
                retVal = (TBaseType) Activator.CreateInstance(typeof(TBaseType));
            }

            return retVal;
        }
    }

    /// <summary>
    /// Helper class contains  type mapping information
    /// </summary>
    public class TypeInfo<TBaseType>
    {
        public TypeInfo(Type type)
        {
            Services = new List<object>();
            Type = type;
        }

        public Func<TBaseType> Factory { get; private set; }
        
        public Type Type { get; private set; }
        
        public Type MappedType { get; set; }
        
        public ICollection<object> Services { get; set; }

        public T GetService<T>()
        {
            return Services.OfType<T>().FirstOrDefault();

            ;
        }

        public TypeInfo<TBaseType> WithService<T>(T service)
        {
            if (!Services.Contains(service))
            {
                Services.Add(service);
            }

            return this;
        }

        public TypeInfo<TBaseType> MapToType<T>()
        {
            MappedType = typeof(T);

            return this;
        }

        public TypeInfo<TBaseType> WithFactory(Func<TBaseType> factory)
        {
            Factory = factory;

            return this;
        }

        public bool IsAssignableTo(string typeName)
        {
            return Type.GetTypeInheritanceChainTo(typeof(TBaseType)).Concat(new[] {typeof(TBaseType)})
                .Any(t => typeName.EqualsInvariant(t.Name));
        }

        public IEnumerable<Type> AllSubclasses => Type.GetTypeInheritanceChainTo(typeof(TBaseType)).ToArray();
    }
}