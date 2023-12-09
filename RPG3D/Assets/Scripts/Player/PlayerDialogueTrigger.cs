using UnityEngine;

public class PlayerDialogueTrigger : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Jump"))
        {
            NPCDialogue dialogue;
            if (other.gameObject.TryGetComponent(out dialogue))
                dialogue.StartDialogue();
        }
    }
}
