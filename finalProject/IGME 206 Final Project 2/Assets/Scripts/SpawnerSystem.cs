/*
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;
using UnityEngine;

public class SpawnerSystem : JobComponentSystem
{

    [BurstCompile]
    struct SpawnerSystemJob : IJobForEach<Translation, Rotation>
    {
        public Transform Enemy;

        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation)
        {
            if(gameObject.tag == "Tag1")
            {
                Enemy = GameObject.FindWithTag("Tag2").transform;
            }

            transform.LookAt(Enemy);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new SpawnerSystemJob();
        
        job.deltaTime = UnityEngine.Time.deltaTime;
        
        return job.Schedule(this, inputDependencies);
    }
}
*/