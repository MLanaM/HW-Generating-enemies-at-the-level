using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private List<Spawner> _spawners;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spawners = new List<Spawner>();
        
        CreateSpawner(new Vector3(-10, 3, 20));
        CreateSpawner(new Vector3(15, 3, 0));
        CreateSpawner(new Vector3(5, 3, -15));
        CreateSpawner(new Vector3(-15, 3, -10));

        _coroutine = StartCoroutine(CreateEnemy());
    }

    private void OnDisable()
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(_coroutine);
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(2f);
        int randomIndex;

        while (enabled)
        {
            randomIndex = Random.Range(0, _spawners.Count);
            _spawners[randomIndex].SpawnEnemy();

            yield return wait;
        }
    }

    private void CreateSpawner(Vector3 position)
    {
        Spawner spawner = Instantiate(_spawner);
        spawner.Init(position);
        _spawners.Add(spawner);
    }
}
