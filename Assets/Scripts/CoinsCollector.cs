using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class CoinCollector : CollectibleItem
{
    [SerializeField] private CoinCollector coins;

    private Wallet _wallet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out CollectibleItem coin))
        {
            _wallet.AddCoin();
            coin.DestroyAfterCapture();
        }
    }
}
