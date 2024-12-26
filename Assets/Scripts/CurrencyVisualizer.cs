using UnityEngine;
using TMPro;
using DG.Tweening;

public class CurrencyVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Canvas targetCanvas;

    public static void ShowIncome(int amount, Vector3 position)
    {
        GameObject instance = Instantiate(CurrencyVisualizer.Instance.floatingTextPrefab);
        
        instance.transform.SetParent(CurrencyVisualizer.Instance.targetCanvas.transform, false);
        
        RectTransform rectTransform = instance.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        
        TextMeshProUGUI textComponent = instance.GetComponentInChildren<TextMeshProUGUI>();
        textComponent.raycastTarget = false; 
        textComponent.text = "+" + amount;
        
        instance.transform.DOScale(Vector3.one * 1.2f, 0.2f).SetLoops(2, LoopType.Yoyo);
        instance.transform.DOMoveY(instance.transform.position.y + 50f, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => Destroy(instance));
    }
    
    private static CurrencyVisualizer _instance;
    public static CurrencyVisualizer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<CurrencyVisualizer>();
            }
            return _instance;
        }
    }
}