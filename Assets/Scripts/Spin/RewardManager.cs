using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    // создает префаб на сцене основываясь на данных полученных от приз детектора

    [SerializeField] private GameObject _rewardAnimationPrefab; //префаб анимации
    [SerializeField] private GameObject _skullAnimtaion;
    [SerializeField] private RectTransform _parent; //дочерний объект для анимаций
    [SerializeField] private ChestController _chestController;
    
    [SerializeField] private ItemSettings _goldItem;
    [SerializeField] private ItemSettings _heartItem;
    [SerializeField] private ItemSettings _crystalItem;
    [SerializeField] private ItemSettings _mysteryItem;
    [SerializeField] private ItemSettings _skullItem;
    
    public void Initialize (String itemName)
    {
        if (itemName == "Skull")
        {
            
            Instantiate(_skullAnimtaion, _parent, false);
            return;
        }
        
        var currentObject = Instantiate(_rewardAnimationPrefab, _parent, false);
        var rewardInitializer = currentObject.GetComponent<RewardInitializer>();

        var itemReward = ElementVariator(itemName);
        rewardInitializer.Initialize(itemReward);
        _chestController.GetItem(itemReward);
    }


    private ItemSettings ElementVariator(string itemName)
    {
        switch (itemName)
        {
            case "Gold" : return _goldItem;
            case "Heart" : return _heartItem;
            case "Crystal" : return _crystalItem;
            case "Mystery" : return _mysteryItem;
            default: return _skullItem;
        }
    }
}