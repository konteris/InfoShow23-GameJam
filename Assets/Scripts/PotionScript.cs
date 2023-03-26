using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Cauldron;
    public string PotionName = "namelesspotion";

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Cauldron.GetComponent<Transform>().position, transform.position) <= 3)
        {
            if (!Player.GetComponent<PlayerInteraction>().isHoldingItem)
            {
                Debug.Log("You dropped a potion");
                Cauldron.GetComponent<cauldron>().AddPotion(PotionName);
                Destroy(gameObject);
            }
        }
    }
}
