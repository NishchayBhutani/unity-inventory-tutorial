using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryScript : MonoBehaviour
{

    UIDocument uiDocument;
    List<VisualElement> inventoryItems;
    int index;
    
    public static InventoryScript INSTANCE {get; private set;}
    public int maxInventorySize = 6;
    public bool isFull = false;

    void Awake() {

        if(INSTANCE != null && INSTANCE != this) {
            Destroy(INSTANCE);
        } else {
            INSTANCE = this;
        }

        uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        inventoryItems = root.Query("InventoryItemContainer").ToList();
        index = inventoryItems.Count - 1;
        if(inventoryItems.Count == maxInventorySize) {
            isFull = true;
        }
    }

    void Update() {
    }

    public void AddItem(VisualElement inventoryItem) {
        Debug.Log("inventory item: "+inventoryItem);
        if((index + 1) == maxInventorySize) {
            Debug.Log("Inventory Full!");
            isFull = true;
            return;
        }
        VisualElement inventoryItemContainer = inventoryItems[index + 1];
        inventoryItemContainer.Add(inventoryItem);
        // inventoryItems.Add(inventoryItem);
        index++;
    }

    public void RemoveItem() {
        if(index < 0) {
            Debug.Log("Inventory Empty!");
            return;
        }
        Debug.Log("item to be removed at index: " + index);
        VisualElement inventoryItemContainer = inventoryItems[index];
        VisualElement itemToRemove = inventoryItemContainer.ElementAt(0);
        if(itemToRemove != null) {
            inventoryItemContainer.Remove(itemToRemove);
            // inventoryItems.RemoveAt(index);
            index--;
            Debug.Log("value of index after item removal: " + index);
        }
        isFull = false;
    }

    public void Clear() {
        Debug.LogError("Clear() called!");
        foreach(VisualElement visualElement in inventoryItems) {
            visualElement.Clear();
        }
    }
}
