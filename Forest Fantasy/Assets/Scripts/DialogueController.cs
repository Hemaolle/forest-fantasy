using UnityEngine;
using System.Collections;

public class DialogueController : MonoBehaviour {

	public float dialogueRange;
	public GameObject dialogueObject;
    public string characterName;
    [Multiline]
    public string dialogueText;

	private bool playerInDialogueRange;
	private bool dialogueColliderClicked;
	private bool dialogueColliderClickedOnThisFrame;
    private bool isDisplayingDialogue;

    private GameObject dialogueInstance;

	void Update() {
		playerInDialogueRange = Vector3.Distance (Player.Get ().transform.position, transform.position) < dialogueRange;

		if (!isDisplayingDialogue && playerInDialogueRange && dialogueColliderClicked && !Player.Get().GetComponent<ClickToMove>().IsWalking()) {
            DisplayDialogue();
		}

		if(Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1) || Input.GetMouseButtonDown (2)) {
			if(!dialogueColliderClickedOnThisFrame) {
				dialogueColliderClicked = false;
			}
            if(isDisplayingDialogue) {
                Destroy(dialogueInstance);
                isDisplayingDialogue = false;
                Player.instance.Movement().ContinueMoving(gameObject);
            }
		}

		dialogueColliderClickedOnThisFrame = false;
	}

    public void DisplayDialogue() {
        dialogueInstance = (GameObject)Instantiate(dialogueObject);
        Dialogue dialogueScript = dialogueInstance.GetComponent<Dialogue>();
        dialogueScript.characterName = characterName;
        dialogueScript.dialogue = dialogueText;
        isDisplayingDialogue = true;
        Player.instance.Movement().StopMoving(gameObject);
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
