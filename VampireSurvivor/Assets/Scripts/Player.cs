using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody = null;
    [SerializeField] SpriteRenderer _spriteRender = null;
    [SerializeField] Animator _animator = null;
    [SerializeField] float _speed = 3.0f;

    private const string ANIMATOR_PARAMETERS_SPEED = "Speed";

    Vector2 _inputVec;
    public Vector2 inputVec { get { return _inputVec; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
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
        if(_animator != null)
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
