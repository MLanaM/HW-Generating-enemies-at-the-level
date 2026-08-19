using UnityEngine;

public class Factory : MonoBehaviour
{
    public void SpawnEnemy(SpawnPoint spawnPoint, Vector3 rotation)
    {
        Enemy enemy = Instantiate(spawnPoint.EnemyPrefab, spawnPoint.Position, Quaternion.Euler(rotation));
    }
}
