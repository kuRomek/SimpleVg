using System;
using System.Collections.Generic;
using System.Reflection;

public class SimpleDI
{
    private Dictionary<Type, object> _container = new();

    public void Register<T>(T instance)
    {
        _container[typeof(T)] = instance;
    }

    public T Resolve<T>()
    {
        return (T)_container[typeof(T)];
    }

    public void Inject(object target)
    {
        var type = target.GetType();

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var field in fields)
        {
            if (Attribute.IsDefined(field, typeof(InjectAttribute)))
            {
                var dependency = Resolve(field.FieldType);
                field.SetValue(target, dependency);
            }
        }

        var props = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var prop in props)
        {
            if (Attribute.IsDefined(prop, typeof(InjectAttribute)) && prop.CanWrite)
            {
                var dependency = Resolve(prop.PropertyType);
                prop.SetValue(target, dependency);
            }
        }
    }

    private object Resolve(Type type)
    {
        if (_container.TryGetValue(type, out var service))
            return service;

        throw new Exception($"Service of type {type} not registered");
    }
}