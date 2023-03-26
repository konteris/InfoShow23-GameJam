using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public float time;
    public double roundedTime;
    public GameObject tutorial;
    public GameObject Arrow;
    public List<string> recipe;
    public TextMeshProUGUI Item1;
    public TextMeshProUGUI Item2;
    public TextMeshProUGUI Item3;
    public TextMeshProUGUI Item4;
    public TextMeshProUGUI Item5;
    public List<string> allItems;
    public GameObject over;


    public Canvas canvas;

    public GameObject Cauldron;

    public GameObject Player;

    public Camera Camera;

    public Camera cam;

    public int level = 0;

    private double currentTime = 0;

    public AudioSource Lose;
    public AudioSource Sucess;
    public AudioSource LongEarthQuake;


    public GameObject GhostSpawner;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        roundedTime = time;
        newLevel();
        DisableCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        roundedTime = Math.Round(time, 0);
        //Debug.Log(roundedTime);
        if (roundedTime == 5)
            Destroy(tutorial);
        if (roundedTime == 10)
            Destroy(Arrow);
        if (level == 3)
        {
            Camera.GetComponent<CameraEffects>().StartShake(500f);
        }

        if (level >= 4)
        {
            ChangeCam(ref Camera, true);
        }
        if(level >= 6)
            Player.GetComponent<PlayerInteraction>().Die();

    }
    void newLevel()
    {
        allItems = new List<string>();
        allItems.Add("Nuclear potion");
        allItems.Add("Blood potion");
        allItems.Add("Spider");
        allItems.Add("Head");
        allItems.Add("Banana");
        allItems.Add("Eye");

        recipe = new List<string>();
        for (int i = 0; i < 6; i++)
        {
            int num = UnityEngine.Random.Range(0, 6 - i);
            recipe.Add(allItems[num]);
            allItems.Remove(allItems[num]);
        }
        Item1.text = recipe[0];
        Item2.text = recipe[1];
        Item3.text = recipe[2];
        Item4.text = recipe[3];
        Item5.text = recipe[4];
    }
    public void CheckRecipe(List<String> ingredientsInside)
    {
        Debug.Log(ingredientsInside.Count);
        Debug.Log(recipe[ingredientsInside.Count - 1]);
        Debug.Log(ingredientsInside[ingredientsInside.Count - 1]);
        if (recipe[ingredientsInside.Count - 1] != ingredientsInside[ingredientsInside.Count - 1])
        {
            SpawnGhost();
            if (recipe.Contains(ingredientsInside[ingredientsInside.Count - 1]))
            {
                level++;
                int index = recipe.IndexOf(ingredientsInside[ingredientsInside.Count - 1]);
                var temp = recipe[ingredientsInside.Count - 1];
                recipe[ingredientsInside.Count - 1] = ingredientsInside[ingredientsInside.Count - 1];
                recipe[index] = temp;
                Item1.text = recipe[0];
                Item2.text = recipe[1];
                Item3.text = recipe[2];
                Item4.text = recipe[3];
                Item5.text = recipe[4];
            }
            else if (level == 5&& !recipe.Contains(ingredientsInside[ingredientsInside.Count - 1]))
            {
                ingredientsInside.Remove(ingredientsInside[ingredientsInside.Count - 1]);
            }
            else 
            {
                Player.GetComponent<PlayerInteraction>().Die();
            }
        }
        else RecipeCompleted();
    }
    public void GameOver()
    {
        //dead = true;
        //Debug.Log(dead);
        //Debug.Log("Game over!");

        ActivateCanvas();
        currentTime = roundedTime;


    }
    public void SpawnGhost()
    {
        Debug.Log("GHOST!");
        GhostSpawner.GetComponent<Spawner>().AddGhost();
    }
    public void DisableCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

    public void ActivateCanvas()
    {
        canvas.gameObject.SetActive(true);
    }
    public void NotEnoughItems()
    {
        Debug.Log("Not enought items!");

    }
    public void RecipeCompleted()
    {
        level++;
        Debug.Log("Recipe completed");
        Debug.Log("Level: " + level);
        if (level == 1)
            SpawnGhost();
        if (level >= 5)
            Victory();
        if (level == 3)
            LongEarthQuake.Play();
        if (level >= 4)
        {
            LongEarthQuake.Stop();
        }
    }
    public void Victory()
    {
        Debug.Log("Victory!");
        over.GetComponent<GameOver>().ActivateCanvas();
        Invoke("Reload", 5);
    }
    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void ChangeCam(ref Camera cam, bool triggered)
    {
        if (triggered)
        {
            cam.transform.Rotate(0, 0, .05f);
        }
    }
    public static Vector3 ChangeMovingPositions(Vector3 directions, bool triggered)
    {
        if (triggered)
        {
            Vector3 otherWay = new Vector3(-directions.x, directions.y, -directions.z);
            return otherWay;
        }
        else
        {
            return directions;
        }

    }

}