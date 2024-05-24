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
        var audioSource = _gameObject.GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.Play();
        }
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