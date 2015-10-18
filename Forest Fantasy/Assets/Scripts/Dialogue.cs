using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogue : MonoBehaviour {

    public Text characterNameTextField;
    public Text dialogueTextField;

    public string characterName;
    public string dialogue;

	void Start() {
        characterNameTextField.text = characterName;
        dialogueTextField.text = dialogue;
    }
}
