/*using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using static Unity.Mathematics.math;

public class MovementSystem : JobComponentSystem
{
    
    [BurstCompile]
    struct MovementSystemJob : IJobForEach<Translation, Rotation>
    {
        public float deltaTime;
        public Transform Enemy;
        float HP;
        float MoveSpeed;


        public void Execute(ref Translation translation, [ReadOnly] ref Rotation rotation)
        {
            HP = 10;
            MoveSpeed = 4;
            if(gameObject.tag == "Tag1")
            {
                Enemy = GameObject.FindWithTag("Tag2").transform;
                if (GameObject.FindWithTag("Tag2") != null)
                {
                    //Find and move towards enemy
                    transform.LookAt(Enemy);
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }
            }
            else if(gameObject.tag == "Tag2")
            {
                Enemy = GameObject.FindWithTag("Tag2").transform;
                if (GameObject.FindWithTag("Tag1") != null)
                {
                    //Find and move towards enemy
                    transform.LookAt(Enemy);
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }
            }
            translation.Value += mul(rotation.Value, new float3(0, 0, 1)) * deltaTime;
            
            
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        var job = new MovementSystemJob();
        
        job.deltaTime = UnityEngine.Time.deltaTime;
        return job.Schedule(this, inputDependencies);
    }
}*/