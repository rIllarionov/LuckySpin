using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstaller : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private RectTransform _parent;

    public void Install()
    {
        Instantiate(_prefab, _parent, false);
    }
}
