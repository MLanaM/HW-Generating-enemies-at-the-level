using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public void Init(Vector3 position)
    {
        transform.position = position;
        transform.localScale = new Vector3(3, 4, 3);

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.cyan;
    }

    public void SpawnEnemy()
    {
        int rotationY = Random.Range(0, 360);
        Vector3 rotation = new Vector3(0, rotationY, 0); 

        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.Euler(rotation));
    }
}
