using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    Image _healthBar;

    [SerializeField]
    Stats _playerStats;

    private void Update()
    {
        _healthBar.fillAmount = (float)_playerStats.CurrentHealthPoints / (float)_playerStats.MaxHealthPoints;
    }
}
