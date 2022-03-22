using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServiceLocator<T> : IServiceLocator<T>
{
    private Dictionary<Type, List<T>> _services { get; }

    public ServiceLocator()
    {
        _services = new Dictionary<Type, List<T>>();
    }

    public void Register<TP>(TP newService) where TP : T
    {
        var type = newService.GetType();
        bool isKeyExist = false;
        foreach (Type key in _services.Keys)
        {
            if (key == type)
            {
                isKeyExist = true;
                break;
            }
        }

        if (isKeyExist)
        {
            var services = _services[type];
            services.Add(newService);
            _services[type] = services;
        }
        else
        {
            _services.Add(type, new List<T>());
            _services[type].Add(newService);
        }
    }

    public void Unregister<TP>(TP service) where TP : T
    {
        var type = service.GetType();
        foreach (Type key in _services.Keys)
        {
            if (key == type)
            {
                var services = _services[type];
                services.Remove(service);
                _services[type] = services;
                break;
            }
        }
    }

    public List<TP> GetServices<TP>() where TP : T
    {
        var type = typeof(TP);
        if (!_services.ContainsKey(type))
        {
            throw new Exception("There is no object of this type");
        }

        return _services[type].Cast<TP>().ToList();
    }

    public TP GetService<TP>() where TP : T
    {
        var type = typeof(TP);
        if (!_services.ContainsKey(type))
        {
            throw new Exception("There is no object of this type");
        }

        return (TP) _services[type][0];
    }
}