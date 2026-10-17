using UnityEngine;

// Pop: agranda el objeto de golpe y lo devuelve suavemente a su tamaño. Sirve para UI o sprites.
public class Pop : MonoBehaviour
{
    [SerializeField] float scale = 1.5f;
    [SerializeField] float smoothing = 10f;

    public void Play()
    {
        transform.localScale = Vector3.one * scale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, smoothing * Time.deltaTime);
    }
}
