using System.Collections;
using System.Collections.Generic;
using DarkNaku.Number;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private Text _textNumber;
    [SerializeField] private Text _textIncreasement;
    [SerializeField] private Button _buttonIncreasement;

    private Number _number = Number.Zero;
    private Number _amount = Number.One;

    private void OnEnable()
    {
        _buttonIncreasement.onClick.AddListener(OnClickIncreasement);
    }

    private void OnDisable()
    {
        _buttonIncreasement.onClick.RemoveListener(OnClickIncreasement);
    }

    private void Update()
    {
        _textNumber.text = _number.ToString();
        _textIncreasement.text = _amount.ToString();

        _number += _amount;
    }

    private void OnClickIncreasement()
    {
        _amount *= 2;
    }
}
