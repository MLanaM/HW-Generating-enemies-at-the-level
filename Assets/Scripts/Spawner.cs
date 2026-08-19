using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Factory _factory;
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private Tower _tower;

    private List<Vector3> _spawnPositions;
    private Coroutine _coroutine;

    private void Awake()
    {
        CreateSpawnPoints();

        _coroutine = StartCoroutine(CreateEnemy());
    }

    private void OnDisable()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
    }

    private void CreateSpawnPoints()
    {
        FillSpawnPositions();
        DrawTowers();
    }

    private void FillSpawnPositions()
    {
        _spawnPositions = new List<Vector3>
        {
            new Vector3(-10, 3, 20),
            new Vector3(15, 3, 0),
            new Vector3(5, 3, -15),
            new Vector3(-15, 3, -10)
        };
    }

    private void DrawTowers()
    {
        foreach (Vector3 position in _spawnPositions)
        {
            Tower tower = Instantiate(_tower, position, Quaternion.identity);
            tower.Init(position);
        }
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);
        Vector3 spawnPosition;
        Vector3 rotation;

        while (enabled)
        {
            spawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Count)];
            rotation = new Vector3(0, Random.Range(0, 360), 0);

            _spawnPoint.SetPosition(spawnPosition);
            SpawnEnemy(rotation);

            yield return wait;
        }
    }

    private void SpawnEnemy(Vector3 rotation) =>
        _factory.SpawnEnemy(_spawnPoint, rotation);
}
