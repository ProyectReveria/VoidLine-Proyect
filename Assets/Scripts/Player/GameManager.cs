using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Race
    {
        Angel,
        Demon, 
        Human
    }
    [SerializeField] public Race player_Race; 
    [SerializeField] public bool isinteracting; 
}
