using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WalletDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldField;
    [SerializeField] private TextMeshProUGUI _crystalField;
    [SerializeField] private float _fillDuration;
    [SerializeField] private Animator _animator;

    private int _finalGold;
    private int _finalCrystal;
    private static readonly int Close = Animator.StringToHash("Close");

    public void SetWalletValue (List <ItemSettings > items)
    {
        _finalGold = Convert.ToInt32(_goldField.text);
        _finalCrystal = Convert.ToInt32(_crystalField.text);
        
        foreach (var item in items)
        {
            switch (item.Type)
            {
                case "crystal":

                    _finalCrystal += Convert.ToInt32(item.Count);
                    break;
                
                case "gold":
                    
                    _finalGold += Convert.ToInt32(item.Count);
                    
                    break;
            }
        }

        StartCoroutine(FillWallet(_goldField, _finalGold));
        StartCoroutine(FillWallet(_crystalField, _finalCrystal));
        
        _animator.SetTrigger(Close);
    }

    private IEnumerator FillWallet (TextMeshProUGUI wallet, int endPosition)
    {
        var startPosition = Convert.ToInt32(wallet.text);

        var elapsedTime = 0f;
            
        while (elapsedTime < _fillDuration)
        {
            elapsedTime += Time.deltaTime;
            var progress = elapsedTime / _fillDuration;
                
            wallet.text = Mathf.Lerp(startPosition, endPosition, progress).ToString("F0");

            yield return null;
        }

        wallet.text = endPosition.ToString();
    }

}
