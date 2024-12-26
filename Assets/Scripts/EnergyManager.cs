using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    [SerializeField] private int maxEnergy = 100;
    [SerializeField] private int currentEnergy;
    [SerializeField] private float energyRegenRate = 1f;
    [SerializeField] private TextMeshProUGUI energyText;
    
    private float regenTimer;

    void Start()
    {
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        regenTimer += Time.deltaTime;
        if (regenTimer >= energyRegenRate && currentEnergy < maxEnergy)
        {
            currentEnergy++;
            regenTimer = 0f;
        }
        
        UpdateEnergyText(); 
    }
    
    private void UpdateEnergyText()
    {
        if (energyText != null)
        {
            energyText.text = "Energy: " + currentEnergy + " / " + maxEnergy;
        }
    }
    
    public bool SpendEnergy(int amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
            return true;
        }
        else
        {
            Debug.Log("Недостаточно энергии!"); 
            return false;
        }
    }
}