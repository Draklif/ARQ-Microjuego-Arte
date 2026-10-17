using UnityEngine;
using UnityEngine.InputSystem;

// PlayerController: la "voluntad" del jugador. Lee el input y se lo pasa al Pawn que posee.
// Separar quien decide (Controller) de quien actúa (Pawn) permite cambiar de cuerpo sin tocar el input.
public class PlayerController : MonoBehaviour
{
    [SerializeField] Pawn startingPawn;
    // Arrastra aquí la acción Player/Move del asset Assets/Settings/InputSystem_Actions.
    [SerializeField] InputActionReference moveAction;

    Pawn pawn;

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void Start()
    {
        Possess(startingPawn);
    }

    void Update()
    {
        if (pawn != null)
            pawn.Move(moveAction.action.ReadValue<Vector2>());
    }

    public void Possess(Pawn newPawn)
    {
        Unpossess();
        pawn = newPawn;
        if (pawn != null)
            pawn.OnPossessed(this);
    }

    public void Unpossess()
    {
        if (pawn != null)
            pawn.OnUnpossessed();
        pawn = null;
    }
}
