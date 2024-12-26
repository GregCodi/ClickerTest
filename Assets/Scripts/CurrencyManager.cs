using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [SerializeField] private int softCurrency;
    [SerializeField] private TextMeshProUGUI softCurrencyText; 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddSoftCurrency(int amount)
    {
        softCurrency += amount;
        softCurrencyText.text = "Coins: " + softCurrency;
    }
}