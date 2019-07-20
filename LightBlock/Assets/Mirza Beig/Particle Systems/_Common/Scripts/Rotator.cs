﻿
// =================================	
// Namespaces.
// =================================

using UnityEngine;

// =================================	
// Define namespace.
// =================================

namespace MirzaBeig
{

    namespace ParticleSystems
    {

        // =================================	
        // Classes.
        // =================================

        public class Rotator : MonoBehaviour
        {
            // =================================	
            // Nested classes and structures.
            // =================================

            // ...

            // =================================	
            // Variables.
            // =================================

            public Vector3 localRotationSpeed;
            public Vector3 worldRotationSpeed;

            public bool executeInEditMode = false;

            public bool unscaledTime;

            // =================================	
            // Functions.
            // =================================

            // ...

            void Awake()
            {

            }

            // ...

            void Start()
            {
                //StartCoroutine(cr());
            }

            //System.Collections.IEnumerator cr()
            //{
            //    while (true)
            //    {
            //        transform.Rotate(localRotationSpeed * Time.deltaTime, Space.Self);
            //        yield return new WaitForSeconds(0.1f);
            //    }
            //}

            // ...

            void OnRenderObject()
            {
                if (executeInEditMode)
                {
                    if (!Application.isPlaying)
                    {
                        rotate();
                    }
                }
            }

            // ...

            void Update()
            {
                if (Application.isPlaying)
                {
                    rotate();
                }
            }

            // ...

            void rotate()
            {
                // Calling Rotate can be expensive.
                // Doing the if-checks is worth it.

                float deltaTime = !unscaledTime ? Time.deltaTime : Time.unscaledDeltaTime;

                if (localRotationSpeed != Vector3.zero)
                {
                    transform.Rotate(localRotationSpeed * deltaTime, Space.Self);
                    //transform.rotation = transform.rotation * Quaternion.AngleAxis(localRotationSpeed.y * Time.deltaTime, Vector3.up);
                }

                if (worldRotationSpeed != Vector3.zero)
                {
                    transform.Rotate(worldRotationSpeed * deltaTime, Space.World);
                }
            }

            // =================================	
            // End functions.
            // =================================

        }

        // =================================	
        // End namespace.
        // =================================

    }

}

// =================================	
// --END-- //
// =================================
