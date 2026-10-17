using UnityEngine;

// Door: bloquea el paso hasta que el Level la abre.
public class Door : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(false);
    }
}
