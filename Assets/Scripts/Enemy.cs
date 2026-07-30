using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
