using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    [SerializeField] private RewardHolder _rewardHolder;
    [SerializeField] private WalletDisplayer _walletDisplayer;

    public void SetWalletValues()
    {
        _walletDisplayer.SetWalletValue(_rewardHolder.Rewards);
    }
}
