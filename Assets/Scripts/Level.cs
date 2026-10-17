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
    [SerializeField] TMP_Text coinText;

    int coins;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateText();
    }

    public void AddCoin()
    {
        coins++;
        UpdateText();
        if (coins == coinsToOpenDoor)
            door.Open();
    }

    public void Complete()
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
