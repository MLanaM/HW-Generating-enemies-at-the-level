using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field: SerializeField] public Enemy EnemyPrefab { get; private set; }

    public Vector3 Position => transform.position;
}
