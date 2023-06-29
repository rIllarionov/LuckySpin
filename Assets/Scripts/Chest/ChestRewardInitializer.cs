using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestRewardInitializer : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private TextMeshProUGUI _count;

    public void Initialize(ItemSettings itemSettings)
    {
        _sprite.sprite = itemSettings.Sprite;

        _count.text = itemSettings.Count == "" ? 1.ToString() : itemSettings.Count;
    }
}
