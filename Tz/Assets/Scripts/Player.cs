using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _movespeed;
    [SerializeField] private Gun _currentGun;
    [SerializeField] private Enemy _closestEnemy;
    private bool _faceright = true;
    public HealthBar healthBar;
    private void Start()
    {
        _closestEnemy=FindFirstObjectByType<Enemy>();
    }
    private void FixedUpdate()
    {
        CheckEnemy();
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _movespeed, _joystick.Vertical * _movespeed);
        ReflectPlayer();
    }
    private void Update()
    {
        if (healthBar.current <= 0)
        {
            Death();
        }
    }
    void ReflectPlayer()
    {
        bool _isRun = _joystick.Horizontal == 0 ? false : true;
        if (_isRun)
        {
            _animator.Play("Run&gun");
        }
        else
        {
            _animator.Play("Idle");
        }
        if (_joystick.Horizontal > 0 && _faceright == false || _joystick.Horizontal < 0 && _faceright == true)
        {
            Vector3 temp = transform.localScale;
            temp.y *= -1;
            transform.localScale = temp;
            _faceright = !_faceright;
            transform.rotation = Quaternion.Euler(0f, 0f, _faceright ? 0f : 180f);
            healthBar.AdjustCurrentValue(0);
        }
    }
    void CheckEnemy()
    {
        Enemy[] enemyObj = FindObjectsOfType<Enemy>();
        if (enemyObj.Length > 0)
        {
            foreach (Enemy enemy in enemyObj)
            {
                _closestEnemy = Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, _closestEnemy.transform.position) ? enemy : _closestEnemy;
            }
            if (Vector3.Distance(_closestEnemy.transform.position, transform.position) < 10f) _currentGun.Aim(_closestEnemy.transform.position, _faceright);
            else _currentGun.ResetAim(_faceright);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
                healthBar.AdjustCurrentValue(-5);
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
