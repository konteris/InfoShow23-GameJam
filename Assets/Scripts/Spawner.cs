using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject planePrefab; // The plane prefab to spawn
    public List<Vector3> spawnPoints; // The list of points to spawn the planes
    private bool[] usedSpawnPoints = new bool[20];

    // Start is called before the first frame update
    // Update is called once per frame
    public void AddGhost()
    {
        Debug.Log("atspawning");
        int spawnIndex = GetRandomElement(spawnPoints.Count);
        if (usedSpawnPoints[spawnIndex] != true)
        {
            usedSpawnPoints[spawnIndex] = true;
            Vector3 spawnPoint = spawnPoints[spawnIndex];
            Instantiate(planePrefab, spawnPoint, Quaternion.identity);
        }
    }
    public int GetRandomElement(int lenght)
    {
        return Random.Range(0, lenght);
    }
    public int BoolCount(bool[] array)
    {
        int sum = 0;
        foreach (bool current in array)
        {
            if (current == true)
            {
                sum++;
            }
        }
        return sum;
    }
}