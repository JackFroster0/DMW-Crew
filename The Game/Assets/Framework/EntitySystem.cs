using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySystem : MonoBehaviour
{
    public IdentityType putis;
    public Entity spaceman;

    // Start is called before the first frame update
    void Start()
    {
        spaceman = PoolingManager.instance.GetPrefab(putis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
