using UnityEngine;
using System.Collections;

public class InventoryButton : MonoBehaviour {

    public GameObject inventoryPanel;

    private bool inventoryOpen;
    private GameObject inventory;

    public void ButtonPressed() {
        if(!inventoryOpen) {
            inventory = (GameObject)Instantiate(inventoryPanel);
            inventoryOpen = true;
            Player.Get().GetComponent<ClickToMove>().enabled = false;
        }
        else if(inventoryOpen) {
            Destroy(inventory);
            inventoryOpen = false;
            Player.Get().GetComponent<ClickToMove>().enabled = true;
        }
    }
}
