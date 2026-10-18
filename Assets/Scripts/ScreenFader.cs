using UnityEngine;

// ScreenFader: una imagen negra a pantalla completa. Empieza opaca y se aclara al cargar el nivel;
// FadeOut() la oscurece antes de cambiar de escena para que el corte no sea brusco.
public class ScreenFader : MonoBehaviour
{
    [SerializeField] CanvasGroup group;
    [SerializeField] float speed = 2f;

    float target;

    void Awake()
    {
        group.alpha = 1;
        target = 0;
    }

    public void FadeOut()
    {
        target = 1;
    }

    void Update()
    {
        group.alpha = Mathf.MoveTowards(group.alpha, target, speed * Time.deltaTime);
    }
}
