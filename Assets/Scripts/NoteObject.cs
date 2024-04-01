using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode KeyToPress;

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
            GameManager.instance.NoteHit();
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
            }
        }
    }
}
