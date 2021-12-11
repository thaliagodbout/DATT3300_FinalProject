using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public string key;
    static bool isPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }

    public void pickUp() {
        isPickedUp = true;
    }

    public void putDown() {
        isPickedUp = false;
    }
}
