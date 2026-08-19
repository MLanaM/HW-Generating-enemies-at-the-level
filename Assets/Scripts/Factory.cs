using UnityEngine;

public class Factory : MonoBehaviour
{
    public void SpawnEnemy(SpawnPoint spawnPoint, Vector3 direction)
    {
        Enemy enemy = Instantiate(spawnPoint.EnemyPrefab, spawnPoint.Position, Quaternion.identity);
        enemy.SetDirection(direction);
    }
}
