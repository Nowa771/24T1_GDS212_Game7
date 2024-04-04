using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode KeyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    private bool hasBeenPressed = false; // whether the key has been pressed

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPress) && canBePressed && !hasBeenPressed) // Check if the key hasn't been pressed before
        {
            hasBeenPressed = true; // key as pressed to prevent subsequent presses
            gameObject.SetActive(false);
            //GameManager.instance.NoteHit();

            if (Mathf.Abs(transform.position.y) > 0.25)
            {
                Debug.Log("Hit");
                GameManager.instance.NormalHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
            }
            else if (Mathf.Abs(transform.position.y) > 0.05f)
            {
                Debug.Log("Good");
                GameManager.instance.GoodHit();
                Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
            }
            else
            {
                Debug.Log("perfect");
                GameManager.instance.perfectHit();
                Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            if (!hasBeenPressed) // Check if the key hasn't been pressed before exiting
            {
                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
