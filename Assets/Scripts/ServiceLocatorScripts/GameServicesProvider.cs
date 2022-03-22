using System;
using System.Collections.Generic;
using UnityEngine;

public class GameServicesProvider : MonoBehaviour
{
    public static GameServicesProvider instance;

    private IServiceLocator<MonoBehaviour> _locator;

    private void Awake()
    {
        instance = this;
        _locator = new ServiceLocator<MonoBehaviour>();
    }

    public void Register(MonoBehaviour newService)
    {
        _locator.Register(newService);
    }

    public void Unregister(MonoBehaviour service)
    {
        _locator.Unregister(service);
    }

    public List<T> GetServices<T>() where T : MonoBehaviour
    {
        return _locator.GetServices<T>();
    }

    public T GetService<T>() where T : MonoBehaviour
    {
        return _locator.GetService<T>();
    }
}