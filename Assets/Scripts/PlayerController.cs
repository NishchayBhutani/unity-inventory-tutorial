using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPickUp() {
        Debug.Log("OnPickUp() called");
        InventoryScript.INSTANCE.AddItem(new VisualElement());
    }

    void OnDrop() {
        Debug.Log("OnDrop() called");
        InventoryScript.INSTANCE.RemoveItem();
    }
}
