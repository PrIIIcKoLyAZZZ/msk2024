using System;
using System.Collections;
using Surv;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _this;
    [SerializeField] private float delayDestroy;
    [SerializeField] private Collider _collider;
    [SerializeField] private float _forseFromBullet;
    [SerializeField] private Hero _hero;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject[] poison;

    public bool isDead = false;
    
    public void RotateToHero()
    {
        if(isDead == false)
        {
            Vector3 direction = _hero.transform.position - _collider.transform.position;
            direction = direction.normalized;
            float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg - 90f;
            _rigidbody.rotation = Quaternion.Euler(0, -angle, 0);
        }
    }

    public void TakeDamage(int damage)
    {
        if(_this.IsDestroyed())
            return;
        Vector3 direction = _collider.transform.position - _hero.transform.position;
        direction = direction.normalized;
        _health -= damage;
        _rigidbody.AddForce(direction * _forseFromBullet, ForceMode.Impulse);
        if (_health <= 0)
        {
            _animator.SetTrigger("is-dead");
            isDead = true;
            _this.layer = 0;
            StartCoroutine(Die());
            SpawnPoison();
        }
    }

    private void SpawnPoison()
    {
        int p =  (int)(Random.Range(0, 200) / 10f);
        if (p < poison.Length)
        {
            Instantiate(poison[p], transform.position, quaternion.identity);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(delayDestroy);
        _collider.enabled = false;
        yield return new WaitForSeconds(delayDestroy);
        Destroy(_this);
    }
}
