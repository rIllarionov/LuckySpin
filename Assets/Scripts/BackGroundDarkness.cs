using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundDarkness : MonoBehaviour
{
    [SerializeField] private ChestController _chestController;
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        _chestController.OnChestMoving += SetActive;
    }

    private void OnDestroy()
    {
        _chestController.OnChestMoving -= SetActive;
    }

    private void SetActive()
    {
        _gameObject.SetActive(true);
    }
}
