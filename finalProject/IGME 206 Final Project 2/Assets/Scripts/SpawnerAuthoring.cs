using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

// ReSharper disable once InconsistentNaming
[RequiresEntityConversion]
public class SpawnerAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
public GameObject Prefab;
public int CountX;
public int CountY;

public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
{
referencedPrefabs.Add(Prefab);
}

// Convert the editor data representation to the entity optimal runtime representation
public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
{
var spawnerData = new SpawnerComponents
{
// Map the game object to an entity reference to the prefab.
Prefab = conversionSystem.GetPrimaryEntity(Prefab),
CountX = CountX,
CountY = CountY
};
dstManager.AddComponentData(entity, spawnerData);
}
}
