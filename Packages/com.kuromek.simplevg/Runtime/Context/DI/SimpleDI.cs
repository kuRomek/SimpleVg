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

    public void InjectConstructors(object target)
    {
        var methods = target.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            if (method.Name != "Construct") continue;

            var parameters = method.GetParameters();
            var args = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
                args[i] = Resolve(parameters[i].ParameterType);

            method.Invoke(target, args);
        }
    }

    private object Resolve(Type type)
    {
        if (_container.TryGetValue(type, out var @object))
            return @object;

        throw new Exception($"Service of type {type} not registered");
    }
}