using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textField;

    public void SetInventoryCount(int count)
    {
        textField.text = count.ToString() + "/10";
    }
}
