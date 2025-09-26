using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField]
    Image imageComponent;

    [SerializeField]
    Button buttonComponent;

    [SerializeField]
    TextMeshProUGUI textMeshProUGUIComponent;

    public Image GetImage() => imageComponent;
    public Button GetButton() => buttonComponent;
    public TextMeshProUGUI GetTextMeshProUGUI() => textMeshProUGUIComponent;
}
