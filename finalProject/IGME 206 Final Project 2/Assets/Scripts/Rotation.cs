using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

// ReSharper disable once InconsistentNaming
[RequiresEntityConversion]
public class Rotation : MonoBehaviour, IConvertGameObjectToEntity
{

public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
{
var data = new RotationSpeed { RadiansPerSecond = math.radians(40) };
//Spin the cubes
//Because of how enemy finding works (facing enemy and moving forwards) rotation doesn't really work'
dstManager.AddComponentData(entity, data);
}
}
