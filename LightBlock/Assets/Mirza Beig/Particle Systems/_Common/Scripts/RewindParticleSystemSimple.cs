using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindParticleSystemSimple : MonoBehaviour
{
    ParticleSystem[] particleSystems;

    float simulationTime;
    public float startTime = 2.0f;

    float internalStartTime;

    bool gameObjectDeactivated;

    public float simulationSpeed = 1.0f;
    public bool useFixedDeltaTime = true;

    public bool rewind = true;

    void OnEnable()
    {
        bool particleSystemsNotInitialized = particleSystems == null;

        if (particleSystemsNotInitialized)
        {
            particleSystems = GetComponentsInChildren<ParticleSystem>(false);
        }

        simulationTime = 0.0f;

        if (particleSystemsNotInitialized || gameObjectDeactivated)
        {
            internalStartTime = startTime;
        }
        else
        {
            // Note: ParticleSystem.Time will clamp to the duration of the system. 
            // It's important to make sure the duration is long enough to accomodate the entire effect to prevent it from having a limited start offset.

            internalStartTime = particleSystems[0].time;
        }

        for (int i = particleSystems.Length - 1; i >= 0; i--)
        {
            particleSystems[i].Simulate(internalStartTime, false, false, useFixedDeltaTime);
        }
    }

    void OnDisable()
    {
        particleSystems[0].Play(true);
        gameObjectDeactivated = !gameObject.activeInHierarchy;
    }

    void Update()
    {
        simulationTime -= Time.deltaTime * simulationSpeed;
        float currentSimulationTime = internalStartTime + simulationTime;

        particleSystems[0].Stop(true,
            ParticleSystemStopBehavior.StopEmittingAndClear);

        for (int i = particleSystems.Length - 1; i >= 0; i--)
        {
            bool useAutoRandomSeed = particleSystems[i].useAutoRandomSeed;
            particleSystems[i].useAutoRandomSeed = false;

            particleSystems[i].Play(false);
            particleSystems[i].Simulate(currentSimulationTime, false, false, useFixedDeltaTime);

            particleSystems[i].useAutoRandomSeed = useAutoRandomSeed;

            if (currentSimulationTime < 0.0f)
            {
                particleSystems[i].Play();
                particleSystems[i].Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }
}
