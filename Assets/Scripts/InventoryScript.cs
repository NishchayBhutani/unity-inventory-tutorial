using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryScript : MonoBehaviour
{

    UIDocument uiDocument;
    VisualElement inventoryContainer;
    List<VisualElement> inventoryItems;

    public static InventoryScript INSTANCE {get; private set;}
    public int maxInventorySize = 6;

    void Awake() {

        if(INSTANCE != null && INSTANCE != this) {
            Destroy(INSTANCE);
        } else {
            INSTANCE = this;
        }

        uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        inventoryContainer = root.Q("InventoryContainer");
        inventoryItems = root.Query("InventoryItemContainer").ToList();
    }

    public void AddItem(VisualElement inventoryItemContainer) {
        if(inventoryItems.Count == maxInventorySize) {
            Debug.Log("Inventory Full!");
            return;
        }
        inventoryItems.Add(inventoryItemContainer);
    }

    public void RemoveItem() {
        if(inventoryItems.Count == 0) {
            Debug.Log("Inventory Empty!");
            return;
        }
        Debug.Log("inventory items count: " + inventoryItems.Count);
        VisualElement itemToRemove = inventoryItems[inventoryItems.Count - 1];
        itemToRemove.Remove(itemToRemove.Q("InventoryItem"));
        inventoryItems.RemoveAt(inventoryItems.Count - 1);
    }

    public void Clear() {
        inventoryItems.Clear();
    }
}
