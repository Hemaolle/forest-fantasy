using UnityEngine;
using System.Collections;

public class DisplayDialogue : MonoBehaviour {

	public float dialogueRange;
	public GameObject dialogue;

	private bool playerInDialogueRange;
	private bool dialogueColliderClicked;
	private bool dialogueColliderClickedOnThisFrame;
    private bool isDisplayingDialogue;

    private GameObject dialogueInstance;

//	void OnTriggerEnter(Collider collider) {
//		if (collider.tag == Constants.PLAYER_TAG) {
//			playerInDialogueRange = true;
//		}
//	}
//
//	void OnTriggerExit(Collider collider) {
//		if (collider.tag == Constants.PLAYER_TAG) {
//			playerInDialogueRange = false;
//		}
//	}

	void Update() {
		playerInDialogueRange = Vector3.Distance (Player.Get ().transform.position, transform.position) < dialogueRange;

		if (!isDisplayingDialogue && playerInDialogueRange && dialogueColliderClicked && !Player.Get().GetComponent<ClickToMove>().IsWalking()) {
			dialogueInstance = (GameObject)Instantiate(dialogue);
            isDisplayingDialogue = true;
            Player.Get().GetComponent<ClickToMove>().enabled = false;
		}

		if(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
			if(!dialogueColliderClickedOnThisFrame) {
				dialogueColliderClicked = false;
			}
            if(isDisplayingDialogue) {
                Destroy(dialogueInstance);
                isDisplayingDialogue = false;
                Player.Get().GetComponent<ClickToMove>().enabled = true;
            }
		}

		dialogueColliderClickedOnThisFrame = false;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, dialogueRange);
	}

	void OnMouseDown() {
		dialogueColliderClicked = true;
		dialogueColliderClickedOnThisFrame = true;
	}
}
