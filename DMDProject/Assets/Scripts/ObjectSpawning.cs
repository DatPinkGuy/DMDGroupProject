using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private GameObject launchable;
    [SerializeField] private List<GameObject> spawnableList;
    [HideInInspector] public List<GameObject> spawnedObjects;
    private LaunchingCamera _launchingCamera;
    [Tooltip("Time after game start when objects start to spawn (in seconds)")]
    [SerializeField] private float neededTime;
    [Tooltip("Amount of objects to spawn in each spawn cycle")]
    [SerializeField] private int objectSpawnAmount;
    [Tooltip("Range of spawnable locations for objects (in x and y axis)")]
    [SerializeField] private int spawnVariety;
    [Tooltip("Distance that needs to be covered for new objects to spawn")]
    [SerializeField] private int spawnDistance;
    private float _timer;
    private Vector3 _oldSpawn;
    private GameObject _list;
    // Start is called before the first frame update
    void Start()
    {
        _launchingCamera = FindObjectOfType<LaunchingCamera>();
        _list = new GameObject("--Spawnable List--");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_launchingCamera.launched) return;
        _timer += Time.deltaTime;
        if (_timer < neededTime) return;
        ObjectSpwan();
    }

    void ObjectSpwan()
    {
        foreach (var collectible in spawnedObjects.ToList())
        {
            if (collectible.transform.position.x < launchable.transform.position.x - spawnDistance)
            {
                spawnedObjects.Remove(collectible);
                Destroy(collectible);
            }
        }

        if (_oldSpawn.x <= launchable.transform.position.x)
        {
            var vel = _launchingCamera.rb.velocity;
            _oldSpawn = launchable.transform.position;
            _oldSpawn += vel;
            for (int i = 0; i < objectSpawnAmount; i++)
            {
                var collectible = Instantiate(spawnableList[Random.Range(0, spawnableList.Count)],
                    new Vector3(_oldSpawn.x + Random.Range(-spawnVariety, spawnVariety), 
                        _oldSpawn.y + Random.Range(-spawnVariety, spawnVariety), 0f),
                    Quaternion.identity);
                collectible.transform.SetParent(_list.transform, true);
                spawnedObjects.Add(collectible);
            }
        }
    }
}
