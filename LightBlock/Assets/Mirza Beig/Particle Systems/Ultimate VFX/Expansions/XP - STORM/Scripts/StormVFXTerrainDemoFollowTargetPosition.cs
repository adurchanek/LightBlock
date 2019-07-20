using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormVFXTerrainDemoFollowTargetPosition : MonoBehaviour
{
    public Transform target;

    void Start()
    {

    }

    void Update()
    {

    }

    void LateUpdate()
    {
        transform.position = target.position;
    }
}
