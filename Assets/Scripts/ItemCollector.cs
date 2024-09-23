using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.AddCoin();
            coin.DestroyAfterCapture();
        }

        if (other.gameObject.TryGetComponent(out HealEssense healEssense))
        {
            _player.Heal();
            healEssense.DestroyAfterCapture();
        }
    }
}
