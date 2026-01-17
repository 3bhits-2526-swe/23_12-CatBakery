using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public int phase = 1; // gemeinsame Variable 
    void Awake() {
        Instance = this;
    }
}
