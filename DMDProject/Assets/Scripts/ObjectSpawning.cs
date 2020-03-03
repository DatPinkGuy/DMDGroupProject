using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawning : MonoBehaviour
{
    [SerializeField] private GameObject launchable;
    [SerializeField] private List<GameObject> spawnableList;
    [HideInInspector] public List<GameObject> spawnedObjects;
    private LaunchingCamera _launchingCamera;
    [SerializeField] private float neededTime;
    [SerializeField] private int objectSpawnAmount;
    private float _timer;
    private Vector3 _oldSpawn;
    private GameObject _list;
    // Start is called before the first frame update
    void Start()
    {
        _launchingCamera = FindObjectOfType<LaunchingCamera>();
        _list = new GameObject("Spawnable List");
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
        foreach (var collectible in spawnedObjects)
        {
            if (collectible.transform.position.x < launchable.transform.position.x - 50)
            {
                spawnedObjects.Remove(collectible);
                Destroy(collectible);
            }
        }
        
        if (_oldSpawn.x <= launchable.transform.position.x)
        {
            _oldSpawn = launchable.transform.position;
            _oldSpawn.x += 50;
           for (int i = 0; i < objectSpawnAmount; i++)
            {
                var collectible = Instantiate(spawnableList[Random.Range(0, spawnableList.Count)],
                    new Vector3(_oldSpawn.x + Random.Range(-20, 20), _oldSpawn.y + Random.Range(-20, 20), 0f),
                    Quaternion.identity);
                collectible.transform.SetParent(_list.transform, true);
                spawnedObjects.Add(collectible);
            }
        }
    }
}
