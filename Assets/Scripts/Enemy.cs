using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private Coroutine _coroutine;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(DestroyEnemy());
    }

    private void OnDisable()
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(_coroutine);
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }
}
