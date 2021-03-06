using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> carsPrefabs = new List<GameObject>();
    [SerializeField] private int trafficDensity = 5;

    private void Awake()
    {
        SpawnCars();
    }

    private void SpawnCars()
    {
        float posX = 0.5f;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < trafficDensity; j++)
            {
                var car = Instantiate(carsPrefabs[Random.Range(0, carsPrefabs.Count)]);
                float carZPos = Random.Range((j * 100 / trafficDensity), (j + 1) * 100 / trafficDensity) + 2;
                car.transform.position = new Vector3(posX, 0.5f, carZPos);
                car.transform.SetParent(transform);
            }
            posX += 2f;
        }
    }
}
