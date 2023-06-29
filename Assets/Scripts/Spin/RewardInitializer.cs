using System;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class RewardInitializer : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _count;
    private Animator _animator;

    public void Initialize(ItemSettings itemSettings)
    {
        _sprite.sprite = itemSettings.Sprite;
        _name.text = itemSettings.Name;
        _count.text = itemSettings.Count;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
