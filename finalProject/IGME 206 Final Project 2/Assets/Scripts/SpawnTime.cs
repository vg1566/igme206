using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnTime : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Prefab2;
    public int CountX = 1;
    public int CountY = 10;

        void Start()
        {
            // Create entity prefabs
            var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, World.Active);
            var prefab2 = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab2, World.Active);
            var entityManager = World.Active.EntityManager;

            for (var x = 0; x < CountX; x++)
            {
                for (var y = 0; y < CountY; y++)
                {
                    //Spawn CountY red cubes
                    Instantiate(GameObject.FindWithTag("Tag2"), new Vector3(x*1.3F, 0, y*1.3F), Quaternion.identity);
                }
                for (var y = 0; y < CountY; y++)
                {
                    //Spawn CountY blue cubes
                    Instantiate(GameObject.FindWithTag("Tag1"), new Vector3(x*1.3F, 0, y*1.3F), Quaternion.identity);
                }
            }
        }
}
