using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Coin : MonoBehaviour
{
    public void DestroyAfterCapture()
    {
        Destroy(gameObject);
    }
}
