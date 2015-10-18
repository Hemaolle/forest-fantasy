using UnityEngine;
using System.Collections;

public class Player : Singleton<Player> {
    public ClickToMove Movement() {
        return GetComponent<ClickToMove>();
    }
}
