using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySystem : MonoBehaviour
{
    public IdentityType putis;

    public Vector2 maxSpawnRandom = new Vector2(10, 10);

    //public Entity spaceman;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [Button]
    public void SpawnSigurdHeh()
    {
        var _entity = PoolingManager.instance.GetPrefab(putis);

        Vector2 _randomPosition = Vector2.zero;

        _randomPosition.x = Random.Range(-maxSpawnRandom.x, maxSpawnRandom.x);
        _randomPosition.y = Random.Range(-maxSpawnRandom.y, maxSpawnRandom.y);

        _entity.transform.position = _randomPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
