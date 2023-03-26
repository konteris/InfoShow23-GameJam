using static UnityEditor.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Collections;


public class PlayerInteraction : MonoBehaviour
{
    public GameObject over;
    private GameObject heldItem;
    public bool isHoldingItem = false;
    public GameObject Cauldron;
    float distance = 1.5f;
    private bool isInteracting = false;
    private float interactionTime = 0.3f;
    public AudioSource PickUp;
    public AudioSource Music;


    // Angle between the player's forward vector and the held item

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && !isHoldingItem && transform.childCount == 1)
        {
            heldItem = other.gameObject;
        }
        if (other.gameObject.CompareTag("Ghost"))
        {
            Die();
        }
    }
    public void Start()
    {
        Music.Play();
    }
    public void Die()
    {
        //cia game over paskelbyt
        Debug.Log("Ghostinas");
        over.GetComponent<GameOver>().ActivateCanvas();
        Debug.Log("Death");
        Invoke("Reload", 2);
    }
    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            heldItem = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingItem && transform.childCount == 2)
            {
                DropItem();
                StartCoroutine(Interact());
            }
            else if (heldItem != null && !isHoldingItem && transform.childCount == 1) // Add check for isHoldingItem here
            {
                isHoldingItem = true;
                heldItem.transform.parent = transform;
                PickUp.Play();
                StartCoroutine(Interact());
            }
            else if (Vector3.Distance(Cauldron.GetComponent<Transform>().position, transform.position) <= 3)
                if (heldItem == null)
                    Cauldron.gameObject.GetComponent<cauldron>().Cook();
        }


        if (isHoldingItem)
        {
            Vector3 offset = new Vector3(0, distance, 0);
            if (heldItem != null)
                heldItem.transform.position = transform.position + offset;
            else isHoldingItem = false;
        }
    }

    private void DropItem()
    {
        PickUp.Play();

        heldItem.transform.parent = null;
        heldItem.transform.position = transform.position + new Vector3(0, 0, 0.3f);
        heldItem = null;
        isHoldingItem = false;
        StartCoroutine(Interact());
    }
    IEnumerator Interact()
    {
        yield return new WaitForSeconds(interactionTime);
    }
}