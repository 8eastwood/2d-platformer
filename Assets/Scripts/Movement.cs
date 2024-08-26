using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _speed = 4f;

    public Animator Animator;
    private float _horizontalMove;
    private float _jumpingPower = 8f;
    private bool _isFacingCorrect = true;

    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal");
        Animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpingPower);
            Animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyUp(KeyCode.Space) && _rigidBody.velocity.y > 0f)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _rigidBody.velocity.y * 0.5f);
            Animator.SetBool("IsJumping", false);
        }

        FlipSide();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_horizontalMove * _speed, _rigidBody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void FlipSide()
    {
        float sideChanger = -1f;

        if (_isFacingCorrect && _horizontalMove < 0f || !_isFacingCorrect && _horizontalMove > 0f)
        {
            _isFacingCorrect = !_isFacingCorrect;
            Vector3 localScale = transform.localScale;
            localScale.x *= sideChanger;
            transform.localScale = localScale;
        }
    }
}