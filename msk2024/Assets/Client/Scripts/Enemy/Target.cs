using System.Collections;
using Surv;
using Unity.VisualScripting;
using UnityEngine;

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

    public void TakeDamage(int damage)
    {
        Vector3 direction = _collider.transform.position - _hero.transform.position;
        direction = direction.normalized;
        _health -= damage;
        _rigidbody.AddForce(direction * _forseFromBullet, ForceMode.Impulse);
        if (_health <= 0)
        {
            _animator.SetTrigger("is-dead");
            StartCoroutine(Die());
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
