using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private const string ObjectName = "ServiceLocator";

    private Dictionary<Type, object> _services = new Dictionary<Type, object>();

    private static ServiceLocator _instance;

    public static ServiceLocator Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(ObjectName).AddComponent<ServiceLocator>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public T RegisterSingle<T>(T service)
    {
        Type type = typeof(T);

        if (_services.ContainsKey(type))
            throw new InvalidOperationException($"Service of type '{type}' already registered.");

        _services[type] = service;

        return service;
    }

    public T Resolve<T>()
    {
        Type type = typeof(T);

        if (_services.ContainsKey(type) == false)
            throw new InvalidOperationException($"Service of type '{type}' not registered.");

        return (T)_services[type];
    }
}
