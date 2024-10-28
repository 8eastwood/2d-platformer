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
        if (other.gameObject.TryGetComponent(out CollectibleItem item))
        {
            _wallet.AddCoin();
            item.DestroyAfterCapture();
        }

        if (other.gameObject.TryGetComponent(out CollectibleItem healEssense))
        {
            _player.Heal();
            healEssense.DestroyAfterCapture();
        }
    }
}
