using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimButton : MonoBehaviour
{
    [SerializeField] private RewardHolder _rewardHolder;

    private void Awake()
    {
        _rewardHolder.AllRewardsOnDisplay += SetActive;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _rewardHolder.AllRewardsOnDisplay -= SetActive;
    }

    private void SetActive()
    {
        gameObject.SetActive(true);
    }
}
