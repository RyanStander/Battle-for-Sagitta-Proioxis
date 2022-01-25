using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _killCount;
    void Start()
    {
        _killCount.SetText(StaticValues.kills.ToString()); 
    }
}
