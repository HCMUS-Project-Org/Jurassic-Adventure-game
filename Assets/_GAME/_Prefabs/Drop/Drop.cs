using DG.Tweening;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private Transform MoneyPrefab, EXPPrefab;

    void Start()
    {
        int RandomMoneyAmount = Random.Range(1, 4);
        int RandomEXPAmount   = Random.Range(1, 4);

        for (int i = 0; i < RandomMoneyAmount; i++)
        {
            PlayerController.budget += 10;
            InstantiateThenMoveUp(MoneyPrefab);
        }

        for (int i = 0; i < RandomEXPAmount; i++)
        {
            PlayerEXP.GainedEXP?.Invoke(1);
            InstantiateThenMoveUp(EXPPrefab);
        }
    }

    private void InstantiateThenMoveUp(Transform prefab)
    {
        var obj = Instantiate(prefab);
        obj.position = transform.position + (Vector3)Random.insideUnitCircle * 3f;
        obj
            .DOMove(obj.position + Vector3.up * 15f, Random.Range(1f, 1.2f))
            .SetDelay(Random.Range(.1f, .4f))
            .SetEase(Ease.InBack);

        var renderer = obj.GetComponent<SpriteRenderer>();

        renderer
            .DOFade(1f, .2f)
            .From(0f)
            .OnComplete(() =>
                renderer
                    .DOFade(0f, 1f)
                    .SetDelay(.5f)
                    .OnComplete(() =>
                    {
                        obj.DOKill();
                        Destroy(obj.gameObject);
                    })
            );
    }
}