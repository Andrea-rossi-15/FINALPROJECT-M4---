using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class UIController : MonoBehaviour
{
    public TextMeshProUGUI CoinCounter;
    public TextMeshProUGUI EndGameCounter;
    private int coins = 0;



    private float EndGametimer = 180;


    PlayerController playerController;
    public Image LifeBar;
    public Gradient healthGradient;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        EndGameCountDown();
        UpdateHealthBar();
    }
    public void AddCoin()
    {
        coins++;
        UpdateUI();
    }

    void UpdateUI()
    {
        CoinCounter.text = "Coins: " + coins;
    }
    void EndGameCountDown()
    {
        EndGametimer -= Time.deltaTime;
        EndGameCounter.text = "Remain" + EndGametimer;
        if (EndGametimer <= 0)
        {
            Time.timeScale = 0f;
        }
    }
    void UpdateHealthBar()
    {
        float fillAmount = (float)playerController.currentHealth / playerController.maxHealth;
        LifeBar.fillAmount = fillAmount;

        LifeBar.color = healthGradient.Evaluate(fillAmount);
    }
}
