using System.Collections.Generic;
using UnityEngine;

public interface IServiceLocator<T>
{
    void Register<TP>(TP newService) where TP : T;
    void Unregister<TP>(TP Service) where TP : T;
    List<TP> GetServices<TP>() where TP : T;
    TP GetService<TP>() where TP : T;
}