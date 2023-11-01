using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PoolingManager : SingletonMonoBehaviour<PoolingManager>
{
  
    Dictionary<IdentityType, List<Entity>> spawnedEntities = new Dictionary<IdentityType, List<Entity>>();

   public Entity GetPrefab(IdentityType entityType)
    {

        if (spawnedEntities.ContainsKey(entityType))
        {
            foreach(var entity in spawnedEntities[entityType])
            {
                if (entity.gameObject.activeInHierarchy)
                {
                    continue;
                }
                return spawnedEntities[entityType].FirstOrDefault();
            }           
        }
        

        GameObject _go = Instantiate(entityType.prefab);
        Entity _sendMe = _go.GetComponent<Entity>();

        
        if (spawnedEntities.ContainsKey(entityType))
        {
            spawnedEntities[entityType].Add(_sendMe);
        }
        else
        {
            spawnedEntities.Add(entityType, new List<Entity> { _sendMe }); //Creates the key, the list, and adds sendme.
        }

        return _sendMe;
    }

}
