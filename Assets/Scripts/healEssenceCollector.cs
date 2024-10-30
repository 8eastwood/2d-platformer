using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class healEssence : CollectibleItem
{
    [SerializeField] private Player _player;

    private int _healPoints = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollectibleItem healEssense))
        {
            _player.Heal(_healPoints);
            healEssense.DestroyAfterCapture();
        }
    }
}
