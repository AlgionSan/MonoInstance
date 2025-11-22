using UnityEngine;

public class GameManager : MonoInstance<GameManager>
{
    [SerializeField] bool isGameActive;

    public bool IsGameActive { get => isGameActive; } // now GameManager has an instance access -> GameManager.Instance -> and since IsGameActive is public then you can access it with GameManager.Instance.IsGameActive
}
