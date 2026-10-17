using UnityEngine;

// Door: bloquea el paso hasta que el Level la abre.
public class Door : MonoBehaviour
{
    // Prefab de partículas que aparece al abrirse (se destruye solo al terminar).
    [SerializeField] GameObject openEffect;

    public void Open()
    {
        Instantiate(openEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
