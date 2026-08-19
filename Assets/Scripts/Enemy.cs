using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private Vector3 _direction;
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DestroyEnemy());
    }

    private void OnDisable()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
