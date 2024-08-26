using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Waypoint _pointA;
    [SerializeField] private Waypoint _pointB;
    [SerializeField] private float _speed = 1f;

    public Animator Animator;
    private Rigidbody2D _rigidbody;
    private Transform _currentPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentPosition = _pointA.transform;
        Animator.SetBool("isRunning", true);
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        float directionChanger = -1f;
        Vector2 point = _currentPosition.position - transform.position;

        if (_currentPosition == _pointB.transform)
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector2(_speed * directionChanger, 0);
        }

        if (Vector2.Distance(transform.position, _currentPosition.position) < 0.5f 
            && _currentPosition == _pointB.transform)
        {
            FlipSide();
            _currentPosition = _pointA.transform;
        }

        if (Vector2.Distance(transform.position, _currentPosition.position) < 0.5f
            && _currentPosition == _pointA.transform)
        {
            FlipSide();
            _currentPosition = _pointB.transform;
        }
    }

    private void FlipSide()
    {
        float sideChanger = -1f;

        Vector3 localScale = transform.localScale;
        localScale.x *= sideChanger;
        transform.localScale = localScale;
    }
}
