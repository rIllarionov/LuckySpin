using System;
using System.Collections.Generic;
using UnityEngine;

public class RewardHolder : MonoBehaviour
{
    public Action AllRewardsOnDisplay;

    [SerializeField] private WalletManager _walletManager;
    [SerializeField] private RewardDisplayer _rewardDisplayer;

    public List <ItemSettings> Rewards => _rewards;
    
    private List <ItemSettings> _rewards = new List<ItemSettings>();

    public void AddReward(ItemSettings rewardItem)
    {
        _rewards.Add(rewardItem);
    }

    public void ShowRewards()
    {
        _rewardDisplayer.Initialize(_rewards);
        AllRewardsOnDisplay?.Invoke();
    }

}
