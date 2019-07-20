using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindParticleSystem : MonoBehaviour
{
    ParticleSystem[] particleSystems;

    float[] startTimes;
    float[] simulationTimes;

    public float startTime = 2.0f;
    public float simulationSpeedScale = 1.0f;

    public bool useFixedDeltaTime = true;

    bool gameObjectDeactivated;

    void OnEnable()
    {
        bool particleSystemsNotInitialized = particleSystems == null;

        if (particleSystemsNotInitialized)
        {
            particleSystems = GetComponentsInChildren<ParticleSystem>(false);

            startTimes = new float[particleSystems.Length];
            simulationTimes = new float[particleSystems.Length];
        }

        for (int i = particleSystems.Length - 1; i >= 0; i--)
        {
            simulationTimes[i] = 0.0f;

            if (particleSystemsNotInitialized || gameObjectDeactivated)
            {
                startTimes[i] = startTime;
                particleSystems[i].Simulate(startTimes[i], false, false, useFixedDeltaTime);
            }
            else
            {
                startTimes[i] = particleSystems[i].time;
            }
        }
    }

    void OnDisable()
    {
        particleSystems[0].Play(true);
        gameObjectDeactivated = !gameObject.activeInHierarchy;
    }

    void Update()
    {
        particleSystems[0].Stop(true,
            ParticleSystemStopBehavior.StopEmittingAndClear);

        for (int i = particleSystems.Length - 1; i >= 0; i--)
        {
            bool useAutoRandomSeed = particleSystems[i].useAutoRandomSeed;
            particleSystems[i].useAutoRandomSeed = false;

            particleSystems[i].Play(false);

            float deltaTime = particleSystems[i].main.useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            simulationTimes[i] -= (deltaTime * particleSystems[i].main.simulationSpeed) * simulationSpeedScale;

            float currentSimulationTime = startTimes[i] + simulationTimes[i];
            particleSystems[i].Simulate(currentSimulationTime, false, false, useFixedDeltaTime);

            particleSystems[i].useAutoRandomSeed = useAutoRandomSeed;

            if (currentSimulationTime < 0.0f)
            {
                particleSystems[i].Play(false);
                particleSystems[i].Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }
}
