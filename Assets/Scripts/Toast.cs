using TMPro;
using UnityEngine;

// Toast: un mensaje grande en pantalla que aparece con un "pop", se queda un momento y se desvanece.
// El CanvasGroup controla la transparencia de todo el mensaje a la vez.
public class Toast : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] CanvasGroup group;
    [SerializeField] Pop pop;
    [SerializeField] float visibleTime = 1.2f;
    [SerializeField] float fadeSpeed = 2f;

    float timeLeft;

    void Awake()
    {
        group.alpha = 0;
    }

    public void Show(string message)
    {
        text.text = message;
        group.alpha = 1;
        timeLeft = visibleTime;
        pop.Play();
    }

    void Update()
    {
        if (timeLeft > 0)
            timeLeft -= Time.deltaTime;
        else
            group.alpha = Mathf.MoveTowards(group.alpha, 0, fadeSpeed * Time.deltaTime);
    }
}
