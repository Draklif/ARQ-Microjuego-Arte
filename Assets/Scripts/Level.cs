using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Level: las reglas del nivel. Cuenta monedas, abre la puerta y carga el siguiente nivel.
public class Level : MonoBehaviour
{
    // shortcut: acceso global simple para principiantes; en microjuegos siguientes lo cambiamos por eventos.
    public static Level Instance { get; private set; }

    [SerializeField] int coinsToOpenDoor = 5;
    [SerializeField] Door door;
    [Header("UI")]
    [SerializeField] TMP_Text coinText;
    [SerializeField] Pop counterPop;
    [SerializeField] Toast toast;
    [SerializeField] ScreenFader fader;

    [Header("Final del nivel")]
    [SerializeField] AudioClip completeSound;
    [SerializeField] float delayBeforeNextLevel = 0.8f;

    int coins;
    bool completed;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateText();
        toast.Show("Nivel " + (SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void AddCoin()
    {
        coins++;
        UpdateText();
        counterPop.Play();
        if (coins == coinsToOpenDoor)
        {
            door.Open();
            toast.Show("¡Puerta abierta!");
        }
    }

    public void Complete()
    {
        // Evita completar dos veces si el jugador vuelve a tocar la salida durante la pausa.
        if (completed) return;
        completed = true;

        SoundPlayer.Instance.Play(completeSound);
        fader.FadeOut();
        // Una pausa corta deja sonar la victoria (y oscurecer la pantalla) antes de cambiar de escena.
        Invoke(nameof(LoadNextLevel), delayBeforeNextLevel);
    }

    void LoadNextLevel()
    {
        // Siguiente escena en Build Profiles; al terminar la última, vuelve a la primera.
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next >= SceneManager.sceneCountInBuildSettings)
            next = 0;
        SceneManager.LoadScene(next);
    }

    void UpdateText()
    {
        coinText.text = coins + " / " + coinsToOpenDoor;
    }
}
