using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D rb;
    private Vector2 elementSize;

    public float moveSpeed = 6f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
    }
    
    void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
    }

    void OnPickUp() {
        Debug.Log("OnPickUp() called");
        InventoryScript.INSTANCE.AddItem(new VisualElement());
    }

    void OnDrop() {
        Debug.Log("OnDrop() called");
        InventoryScript.INSTANCE.RemoveItem();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("collided with: " + collider.gameObject.name);
        if(collider.gameObject.tag == "Consumable") {
            Sprite sprite = collider.gameObject.GetComponent<SpriteRenderer>().sprite;
            VisualElement inventoryItem = new VisualElement();
            inventoryItem.name = sprite.name;
            inventoryItem.style.backgroundImage = new StyleBackground(sprite);
            inventoryItem.style.height = new Length(100, LengthUnit.Percent);
            inventoryItem.style.width = new Length(100, LengthUnit.Percent);
            InventoryScript.INSTANCE.AddItem(inventoryItem);
            if(!InventoryScript.INSTANCE.isFull) {
                Destroy(collider.gameObject);
            }
        }
   }

}
