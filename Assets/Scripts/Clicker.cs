using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] private ClickerSettings clickerSettings;
    [SerializeField] private EnergyManager energyManager;

    public void OnMouseDown()
    {
        if (energyManager.SpendEnergy(clickerSettings.energyCost))
        {
            int income = CalculateClickIncome();
            
            CurrencyManager.Instance.AddSoftCurrency(income);
            
            CurrencyVisualizer.ShowIncome(income, transform.position);
        }
    }

    private int CalculateClickIncome()
    {
        int baseIncome = clickerSettings.baseSoftCurrency;
        float tapModifier = clickerSettings.tapModifier;
        float autoCollectModifier = 1 + AutoCollector.Instance.incomePerCollection * 0.1f;
        float otherVariableMultiplier = 1f;
        if (clickerSettings.incomeDivider > 0)
        {
            otherVariableMultiplier += 1f / clickerSettings.timePeriod / clickerSettings.incomeDivider;
        }
        
        int totalIncome = Mathf.RoundToInt(
            baseIncome * tapModifier * autoCollectModifier * otherVariableMultiplier
        );

        return totalIncome;
    }
}