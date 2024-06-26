using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidBody = null;
    [SerializeField] float _speed = 3.0f;

    Vector2 _inputVec;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movePos = _inputVec.normalized * _speed * Time.fixedDeltaTime;
        _rigidBody.MovePosition(_rigidBody.position + movePos);
    }

    private void OnMove(InputValue value)
    {
        _inputVec = value.Get<Vector2>();
    }
}
