using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Text healthText;
    public Player player;
    void Start()
    {
        healthText = GetComponent<Text>();
        Data.onHealthChanged.AddListener(UpdateHealthText);
    }

    void UpdateHealthText()
    {

        healthText.text = "Health: "+player.GetPlayerHealth().ToString();
    }
}
