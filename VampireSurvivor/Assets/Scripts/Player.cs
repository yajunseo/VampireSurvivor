using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody = null;
    [SerializeField] SpriteRenderer _spriteRender = null;
    [SerializeField] Animator _animator = null;
    [SerializeField] Scanner _scanner = null;
    [SerializeField] float _speed = 3.0f;
    [SerializeField] Hand[] _hands;

    public float speed { get { return _speed; } set { _speed = value; } }

    public Rigidbody2D rigid { get { return _rigidBody; } }
    public Scanner scanner { get { return _scanner; } }
    public Hand[] hands { get { return _hands; } }

    private const string ANIMATOR_PARAMETERS_SPEED = "Speed";

    Vector2 _inputVec;
    public Vector2 inputVec { get { return _inputVec; } }

    // Start is called before the first frame update

    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (_rigidBody != null)
        {
            Vector2 movePos = _inputVec.normalized * _speed * Time.fixedDeltaTime;
            _rigidBody.MovePosition(_rigidBody.position + movePos);
        }
    }

    private void OnMove(InputValue value)
    {
        _inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (_animator != null)
        {
            _animator.SetFloat(ANIMATOR_PARAMETERS_SPEED, _inputVec.magnitude);
        }

        if (_spriteRender != null)
        {
            if (_inputVec.x != 0)
            {
                _spriteRender.flipX = _inputVec.x < 0;
            }
        }
    }
}
