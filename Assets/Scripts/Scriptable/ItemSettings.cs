using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "ItemSettings", menuName = "ScriptableObject/ItemStat", order = 2)]
public class ItemSettings : ScriptableObject
{
    [SerializeField] private string _type;
    [SerializeField] private string _name;
    [SerializeField] private string _count;
    [SerializeField] private Sprite _sprite;

    public string Type => _type;
    public string Name => _name;
    public string Count => _count;
    public Sprite Sprite => _sprite;
}
