using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _this;
    [SerializeField] private float delayDestroy;
    [SerializeField] private Collider _collider;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _animator.SetTrigger("is-dead");
            StartCoroutine(Die());
            Die();
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
