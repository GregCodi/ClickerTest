using UnityEngine;

public class AutoCollector : MonoBehaviour
{
    public static AutoCollector Instance { get; private set; }
    public int incomePerCollection = 10;
    
    [SerializeField] private float collectionInterval = 5f;

    private float timer;

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

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= collectionInterval)
        {
            CollectIncome();
            timer = 0f;
        }
    }

    private void CollectIncome()
    {
        int income = incomePerCollection;
        CurrencyManager.Instance.AddSoftCurrency(income);
        
    }

    public int GetIncomePerSecond()
    {
        return Mathf.RoundToInt(incomePerCollection / collectionInterval);
    }
}