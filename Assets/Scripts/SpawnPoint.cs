using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Vector3 Position { get; private set; }
    public Enemy EnemyPrefab { get; private set; }

    private void Awake()
    {
        Position = transform.position;
        EnemyPrefab = _enemyPrefab;
    }
}
