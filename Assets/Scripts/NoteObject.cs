using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
		{
            if(canBePressed)
			{
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.25)
				{
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
				} else if(Mathf.Abs(transform.position.y) > 0.05f)
				{
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } else
				{
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
			}
		}
    }

    private void OnTriggerEnter2D(Collider2D other)
	{
        if(other.tag == "Activator")
		{
            canBePressed = true;
		}
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        //check if the player is pressing the button on the frame the arrow disappears
        if (Input.GetKeyDown(keyToPress))
        {
            if (other.tag == "Activator")
            {
                canBePressed = true;
            }
        }
        else
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
