using UnityEngine;

// SquashStretch: deforma el sprite según la velocidad para que el personaje se sienta elástico.
// Va en un hijo "Visual" para no deformar el collider: la física no cambia, solo cómo se ve.
public class SquashStretch : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float amount = 0.2f;
    [SerializeField] float smoothing = 15f;

    void Update()
    {
        Vector2 v = body.linearVelocity / maxSpeed;
        float sx = Mathf.Abs(v.x);
        float sy = Mathf.Abs(v.y);

        // Se estira en el eje en que se mueve y se aplasta en el otro, como una gota.
        Vector3 target = new Vector3(1 + (sx - sy) * amount, 1 + (sy - sx) * amount, 1);
        transform.localScale = Vector3.Lerp(transform.localScale, target, smoothing * Time.deltaTime);
    }
}
