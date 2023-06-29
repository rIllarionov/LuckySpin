using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public Action <int> OnTokenChange;
    public Action WhenTokensEnd;
    
    [SerializeField] private int _tokenCount = 3;
    [SerializeField] private ObjectInstaller _objectInstaller;

    public bool GetToken()
    {
        if (_tokenCount > 0)
        {
            _tokenCount --;
            _objectInstaller.Install();
            OnTokenChange?.Invoke(_tokenCount);
            
            if (_tokenCount == 0)
            {
                WhenTokensEnd?.Invoke();
            }
            return true;
        }

        else
        {
            return false;
        }
    }
}
