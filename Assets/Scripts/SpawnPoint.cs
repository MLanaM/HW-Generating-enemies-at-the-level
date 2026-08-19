using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    public Vector3 Position { get; private set; }
    public Enemy EnemyPrefab { get; private set; }

    public void SetPosition(Vector3 position)
    {
        Position = position;
    }

    private void Awake()
    {
        EnemyPrefab = _enemyPrefab;
    }
}
