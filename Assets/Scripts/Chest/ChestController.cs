using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{
    public Action OnChestMoving;
    
    [SerializeField] private Animator _chestAnimator;
    [SerializeField] private RewardHolder _rewardHolder;
    [SerializeField] private Button _chestButton;

    private float _animationDelay = 4f;
    
    private static readonly int Item = Animator.StringToHash("GetItem");
    private static readonly int Move = Animator.StringToHash("Move");
    private static readonly int Tremor = Animator.StringToHash("Tremor");

    public void GetItem(ItemSettings itemReward)
    {
        StartCoroutine(ChasePulse());
        _rewardHolder.AddReward(itemReward);
    }

    public void PrepareChase()
    {
        StartCoroutine(MoveChase());
    }
    
    private IEnumerator ChasePulse()
    {
        yield return new WaitForSeconds(_animationDelay);
        _chestAnimator.SetTrigger(Item);
    }
    
    private IEnumerator MoveChase()
    {
        yield return new WaitForSeconds(_animationDelay * 2);
        _chestAnimator.SetTrigger(Move);
        OnChestMoving?.Invoke();

        _chestButton.gameObject.SetActive(true);
        _chestAnimator.SetTrigger(Tremor);
    }
    
}
