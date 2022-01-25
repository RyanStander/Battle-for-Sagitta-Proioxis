using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] RectTransform barRectTransform;
    private float _maxWidth;

    void Awake()
    {
        _maxWidth = barRectTransform.rect.width;
    }
    void OnEnable()
    {
        EventManager.onTakeDamage += UpdateHealthDisplay;
    }
    void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateHealthDisplay;
    }

    void UpdateHealthDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(_maxWidth * percentage, 10f);
    }
}
