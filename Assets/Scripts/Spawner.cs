using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Factory _factory;
    [SerializeField] private SpawnPoint _spawnPointPrefab;
    [SerializeField] private Tower _towerPrefab;

    private List<Vector3> _spawnPositions;
    private List<SpawnPoint> _spawnPoints;

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
        FillSpawnPoints();
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

    private void FillSpawnPoints()
    {
        _spawnPoints = new List<SpawnPoint>();

        foreach (Vector3 position in _spawnPositions)
        {
            SpawnPoint spawnPoint = Instantiate(_spawnPointPrefab, position, Quaternion.identity);
            _spawnPoints.Add(spawnPoint);
        }
    }

    private void DrawTowers()
    {
        foreach (Vector3 position in _spawnPositions)
        {
            Tower tower = Instantiate(_towerPrefab, position, Quaternion.identity);
            tower.Init(position);
        }
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);
        SpawnPoint spawnPoint;
        Vector3 direction;

        while (enabled)
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

            _factory.SpawnEnemy(spawnPoint, direction);
            yield return wait;
        }
    }
}
