using System;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public static event Action<int> DifficultySelected; // Event receives an int param
    [SerializeField] private Button button;

    [Min(1)] [SerializeField] private int difficulty;

    void Awake()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked() // Only this class can trigger this
    {
        DifficultySelected?.Invoke(difficulty); // Invokes the event, passing the param difficulty
    }
}
