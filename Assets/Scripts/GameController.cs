using System;
using UnityEngine;
using Yarn.Unity;

public class GameController : MonoBehaviour
{
    public class GameData
    {
        public AgeEnum currentAge;
        public int currentDay;
        public int DaysPerAge;
    }
    public static GameData instance;
 
    private void Awake()
    {
        if(instance == null)
        {
            instance = new GameData();
            instance.currentAge = AgeEnum.Young;
            instance.currentDay = 0;
            instance.DaysPerAge = 3;
        }
    }
    
    public static AgeEnum GetCurrentAge()
    {
        return instance.currentAge;
    }
    
    public static int GetCurrentDay()
    {
        return instance.currentDay;
    }
    
    [YarnCommand("next_day")]
    public static void NextDay()
    {
        instance.currentDay++;
        if (instance.currentDay < instance.DaysPerAge) return;
        instance.currentDay = 0;
        instance.currentAge++;
    }
}