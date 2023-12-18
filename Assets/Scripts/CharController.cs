using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour, IPlayer
{
    public event Action OnKilled;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _JumpButton;
    [SerializeField] private float _jumpForce;
    [SerializeField] private SpriteRenderer _spriteCharacter;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _dumpingSpeed; //for Camera

    private bool isJump;
    public void MakeDamage()
    {
        _rb.AddForce(Vector2.up * _jumpForce);
        _animator.SetTrigger("isDead");
        GetComponent<Collider2D>().isTrigger = true;
        enabled = false; //turn off controller

        Debug.Log("Ouch!!!");
        //Destroy(gameObject);

        OnKilled?.Invoke();
    }

    void Update()
    {
        CharacterMovement();
    }

    private void FixedUpdate()
    {
        _camera.transform.position = Vector3.Lerp(new Vector3(_camera.transform.position.x, _camera.transform.position.y, -10), transform.position, Time.deltaTime * _dumpingSpeed);
    }

    public void CharacterMovement()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _spriteCharacter.flipX = inputDir < 0;

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(_JumpButton) && !isJump) 
        {
                _rb.AddForce(Vector2.up * _jumpForce);
                _animator.SetTrigger("isJump");
                isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}
