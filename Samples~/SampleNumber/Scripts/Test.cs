using System.Collections;
using System.Collections.Generic;
using DarkNaku.Number;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textNumber;
    [SerializeField] private TextMeshProUGUI _textIncreasement;
    [SerializeField] private Button _buttonIncreasement;

    private Number _number = Number.Zero;
    private Number _amount = Number.One;

    private string _numberString = new string(new char[8]);
    private string _amountString = new string(new char[8]);

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
        if (_number.GetString(ref _numberString))
        {
            _textNumber.SetText(_numberString);
        }

        if (_amount.GetString(ref _amountString))
        {
            _textIncreasement.SetText(_amountString);
        }

        _number += _amount;
    }

    private void OnClickIncreasement()
    {
        _amount *= 2;
    }
}
