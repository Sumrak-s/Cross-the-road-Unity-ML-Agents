using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    private float speed = 6f;
    private float minDistanceBetweenCars = 1.5f;

    private MeshRenderer meshRenderer;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        RandomizeCarSettings();
    }

    /// <summary>
    /// Updating a car after teleportation
    /// </summary>
    private void RandomizeCarSettings()
    {
        speed = Random.Range(6f, 8f);
        minDistanceBetweenCars = Random.Range(1.5f, 3f);
        meshRenderer.materials[0].color = Random.ColorHSV();
    }

    
    private void FixedUpdate()
    {
        CarStopping();
        CarTeleportation();
    }

    /// <summary>
    /// Preventing cars from colliding with each other
    /// </summary>
    private void CarStopping()
    {
        Vector3 rayPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f, transform.localPosition.z);

        if (!Physics.Raycast(rayPos, transform.forward, minDistanceBetweenCars, layerMask))
        {
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }
    /// <summary>
    /// Teleporting a car if it is out of the road
    /// </summary>
    private void CarTeleportation()
    {
        if (transform.localPosition.z > 100f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
            RandomizeCarSettings();
        }
    }
}
