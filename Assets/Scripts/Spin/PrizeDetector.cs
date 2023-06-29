using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PrizeDetector : MonoBehaviour
{
    [SerializeField] private SpinController spinController;
    [SerializeField] private RewardManager _rewardManager;
    
    private GameObject _gameObject;

    private void Start()
    {
        spinController.OnSpinFinish += OpenPrize;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameObject = other.gameObject;
    }

    private void OpenPrize()
    {
        _rewardManager.Initialize(_gameObject.name);
    }

    private void OnDestroy()
    {
        spinController.OnSpinFinish -= OpenPrize;
    }
}
