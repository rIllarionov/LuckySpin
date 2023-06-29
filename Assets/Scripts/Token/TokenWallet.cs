using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TokenWallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tokenWalletUi;

    public void SetCurrentTokenCount(int count)
    {
        _tokenWalletUi.text = count.ToString();
    }
}
