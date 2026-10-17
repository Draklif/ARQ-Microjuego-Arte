using UnityEngine;

// LevelExit: zona detrás de la puerta. Necesita un Collider2D con "Is Trigger" activado.
public class LevelExit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Pawn>() != null)
            Level.Instance.Complete();
    }
}
