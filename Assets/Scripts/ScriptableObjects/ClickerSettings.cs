using UnityEngine;

[CreateAssetMenu(fileName = "New Clicker Settings", menuName = "Clicker/Clicker Settings")]
public class ClickerSettings : ScriptableObject
{
    public int baseSoftCurrency = 1;
    public float tapModifier = 1f;
    public float timePeriod = 60f;
    public float incomeDivider = 10f;
    
    public int energyCost = 3;
}