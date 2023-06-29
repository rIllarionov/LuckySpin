using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardDisplayer : MonoBehaviour
{
    [SerializeField] private List<RectTransform> _rewardPositions;
    [SerializeField] private GameObject _rewardPrefab;
    [SerializeField] private float _moveDuration = 0.3f;
    
    public void Initialize (List<ItemSettings> rewards)
    {
        StartCoroutine(DisplayRewards(rewards));
    }
    
    private IEnumerator DisplayRewards(List <ItemSettings> rewards)
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            var currentObj = Instantiate(_rewardPrefab, transform,false);
            currentObj.GetComponent<ChestRewardInitializer>().Initialize(rewards[i]);
            
            yield return null;

            var startPosition = currentObj.transform.position;
            var endPosition = _rewardPositions[i].position;

            var elapsedTime = 0f;
            
            while (elapsedTime < _moveDuration)
            {
                elapsedTime += Time.deltaTime;
                var progress = elapsedTime / _moveDuration;
                
                currentObj.transform.position = Vector3.Lerp(startPosition, endPosition, progress);

                yield return null;
            }
        }
    }
}
