using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cauldron : MonoBehaviour
{
    public List<string> ingredientsInside;
    public GameObject Particles;
    public GameObject Game;
    public GameObject Camera;
    public AudioSource Drop;
    public AudioSource Shake;

    
    // Start is called before the first frame update
    void Start()
    {
        ingredientsInside = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPotion(string potionName)
    {
        ingredientsInside.Add(potionName);
        Game.GetComponent<GameLoop>().CheckRecipe(ingredientsInside);
        Camera.GetComponent<CameraEffects>().StartShake(1f);
        Particles.GetComponent<ParticleSystem>().Play();
        Drop.Play();
        Shake.Play();

    }
    public void Cook() 
    {
        Debug.Log("Cooking");
        Particles.GetComponent<ParticleSystem>().Play();
    }
    public void ResetCauldron() 
    {
        ingredientsInside = new List<string>();
    }
}
