using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormVFXTerrainDemoCamera : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float height = 2.0f;

    [Space]

    public float acceleration = 10.0f;
    public float deceleration = 5.0f;


    Vector3 velocity;

    void Start()
    {

    }

    void Update()
    {
        Vector2 input;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        //input.Normalize();

        bool tryingToMove = input != Vector2.zero;
        Vector3 targetVelocity = Vector3.zero;

        RaycastHit raycastHitInfo;
        bool raycastHit = Physics.Raycast(transform.position, Vector3.down, out raycastHitInfo);

        Vector3 position = Vector3.zero;
        //Vector3 heightVector = Vector3.up * height;

        if (raycastHit)
        {
            targetVelocity.y = (raycastHitInfo.point.y + height) - transform.position.y;
        }

        if (tryingToMove)
        {
            targetVelocity += transform.right * input.x;
            targetVelocity += transform.forward * input.y;

            targetVelocity.Normalize();

            targetVelocity *= moveSpeed;

            velocity = Vector3.MoveTowards(velocity, targetVelocity, Time.deltaTime * acceleration);
        }
        else
        {
            velocity = Vector3.MoveTowards(velocity, targetVelocity, Time.deltaTime * deceleration);
        }

        Vector3 force = velocity * Time.deltaTime;

        transform.position += force;
    }
}
