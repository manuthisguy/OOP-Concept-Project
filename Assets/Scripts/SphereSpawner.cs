using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject sphere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnSphere", 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSphere()
    {
        Vector3 spawnRange = new Vector3(Random.Range(-15f, 15f), 22f, 0f);
        Instantiate(sphere, spawnRange, transform.rotation);
    }
}
