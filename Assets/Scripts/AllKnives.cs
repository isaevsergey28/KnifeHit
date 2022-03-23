using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllKnives : MonoBehaviour
{
    [SerializeField] private List<GameObject> _activeKnives = new List<GameObject>();

    public List<GameObject> GetActiveKnives()
    {
        return _activeKnives;
    }

    public void AddKnife(GameObject knife)
    {
        _activeKnives.Add(knife);
    }

    public void ChangeKnivesSettings(Transform newParent)
    {
        foreach (var knife in _activeKnives)
        {
            knife.transform.parent = newParent;
            var knifeBeh = knife.GetComponent<Knife>();
            knifeBeh.enabled = true;
            knifeBeh.SetDynamicPhysics();
            Destroy(knifeBeh.gameObject, 3f);
        }
    }
    
    public void ClearKnivesList()
    {
        _activeKnives.Clear();
    }
}
