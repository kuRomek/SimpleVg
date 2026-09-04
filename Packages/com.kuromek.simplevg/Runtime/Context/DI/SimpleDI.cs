using System;
using System.Collections.Generic;
using System.Reflection;

public class SimpleDI
{
    private readonly Dictionary<Type, object> _container = new();
    private readonly List<IUpdatable> _updatables = new();

    public void Register<T>(T instance)
    {
        _container[typeof(T)] = instance;

        if (instance is IUpdatable updatable)
            _updatables.Add(updatable);
    }

    public T Resolve<T>()
    {
        return (T)_container[typeof(T)];
    }

    public void Update(float deltaTime)
    {
        foreach (var updatable in _updatables)
            updatable.Update(deltaTime);
    }

    public void InjectConstructors(object target)
    {
        var type = target.GetType();

        while (type != null)
        {
            var methods = target.GetType()
                .GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                if (method.Name != "Construct") continue;

                var parameters = method.GetParameters();
                var args = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                    args[i] = Resolve(parameters[i].ParameterType);

                method.Invoke(target, args);
            }

            type = type.BaseType;
        }
    }

    private object Resolve(Type type)
    {
        if (_container.TryGetValue(type, out var @object))
            return @object;

        throw new Exception($"Service of type {type} not registered");
    }
}