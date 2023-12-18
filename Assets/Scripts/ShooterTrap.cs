using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTrap : Trap
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _shootForce;
    private bool _isTrapActive = false;

    public void Shoot()
    {
        var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, transform.root.position.y) * _shootForce); //To shoot it in any directiction
    }
    public override void PlayAnimation(string name)
    {
        if (!_isTrapActive)
        {
            base.PlayAnimation(name);
            Shoot();
            _isTrapActive = true;
        }
    }
}
