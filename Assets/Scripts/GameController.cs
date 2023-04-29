using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public AgeEnum currentAge;
    public int currentDay;
    
    
    private void Awake()
    {
        instance = this;
    }
    
    public static AgeEnum GetCurrentAge()
    {
        return instance.currentAge;
    }
    
    public static int GetCurrentDay()
    {
        return instance.currentDay;
    }
}