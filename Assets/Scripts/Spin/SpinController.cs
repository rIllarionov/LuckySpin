using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpinController : MonoBehaviour
{
    public Action OnSpinFinish;

    [SerializeField] private float _minRotationSpeed = 20f;
    [SerializeField] private float _maxRotationSpeed = 40f;
    [SerializeField] private TokenManager _tokenManager;
    [SerializeField] private TokenWallet _tokenWallet;
    [SerializeField] private Button _spinButton;
    [SerializeField] private ChestController _chestController;
    
    private Rigidbody2D _rigidbody2D;

    private bool _startSpin;
    private bool _finishSpin;

    
    public void StartSpin()
    {
        if (_tokenManager.GetToken())
        {
            var speed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
            _rigidbody2D.AddTorque(speed,ForceMode2D.Impulse);
        
            _startSpin = true;
        }
        
    }

    private void BlockSpinButton()
    {
        _spinButton.interactable = false;
    }
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _tokenManager.OnTokenChange += _tokenWallet.SetCurrentTokenCount;
        _tokenManager.WhenTokensEnd += BlockSpinButton;
        _tokenManager.WhenTokensEnd += _chestController.PrepareChase;
    }

    private void OnDestroy()
    {
        _tokenManager.OnTokenChange -= _tokenWallet.SetCurrentTokenCount;
        _tokenManager.WhenTokensEnd -= BlockSpinButton;
        _tokenManager.WhenTokensEnd -= _chestController.PrepareChase;
    }

    private void Update()
    {
        if (_startSpin)
        {
            IsSpin();
        }

        if (_startSpin && _finishSpin)
        {
            OnSpinFinish?.Invoke();
            
            _startSpin = false;
            _finishSpin = false;
        }
    }

    private void IsSpin()
    {
        if (Mathf.Approximately(_rigidbody2D.angularVelocity, 0f))
        {
            _finishSpin = true;
        }
    }
}
