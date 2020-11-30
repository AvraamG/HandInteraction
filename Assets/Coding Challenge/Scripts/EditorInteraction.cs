using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorInteraction : MonoBehaviour
{
    [SerializeField]
    float maxDistance;

    [SerializeField]
    float sphereRadius;

    Vector3 hitPosition;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        //If you want to go 2D use direction = this.transform.position

        Vector3 direction = (this.transform.position - Camera.main.transform.position) * maxDistance;


        Gizmos.DrawRay(transform.position, direction);

        if (hitPosition != Vector3.zero)
        {
            Gizmos.DrawSphere(hitPosition, sphereRadius);

        }
    }

    InteractableCubes currentCube = null;
    void DetectObjects()
    {


        RaycastHit hit;

        Vector3 origin = this.transform.position;
        Vector3 destination = this.transform.position - Camera.main.transform.position;
        if (Physics.SphereCast(origin, sphereRadius, destination, out hit, maxDistance))
        {
            hitPosition = hit.point;

            if (hit.transform.tag == "Interactable")
            {
                if (currentCube != hit.transform.GetComponent<InteractableCubes>())
                {
                    if (currentCube)
                    {
                        currentCube.ResetVisualizations();
                    }
                    currentCube = hit.transform.GetComponent<InteractableCubes>();
                    currentCube.HighlightCubeInteraction();
                }
            }
        }
        else
        {
            hitPosition = Vector3.zero;
            if (currentCube)
            {
                currentCube.ResetVisualizations();
            }

            currentCube = null;
        }

    }


    private void Update()
    {
        DetectObjects();
    }
}

