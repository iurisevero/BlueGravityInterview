using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUIController : MonoBehaviour
{
    public static bool OpenMenu = false;
    [SerializeField] GameObject menuWindow;
    [SerializeField] TextMeshProUGUI coinsQuantity;

    private void Start()
    {
        UpdateCoins();
        CloseMenuUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ToogleMenu();
        }
    }

    private void ToogleMenu()
    {
        if(OpenMenu)
            CloseMenuUI();
        else
            OpenMenuUI();
    }

    public void UpdateCoins()
    {
        coinsQuantity.text = Player.Instance.coins.ToString();
    }

    public void OpenMenuUI()
    {
        Time.timeScale = 0;
        OpenMenu = true;
        menuWindow.SetActive(true);
    }

    public void CloseMenuUI()
    {
        Time.timeScale = 1;
        OpenMenu = false;
        menuWindow.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
