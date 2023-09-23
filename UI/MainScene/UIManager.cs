using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IdleGame;

public class UIManager : Singleton<UIManager>
{
    public GameObject welcomeWindow, overlayInfoWindow, combatWindow, statsWindow, bagWindow, mapsWindow, settingsWindow;

    public GameObject combatEquipmentWindow;

    public GameObject combatMenuButton, statsMenuButton, bagMenuButton, mapsMenuButton, settingsMenuButton;

    public GameObject combatSubMenuButton, combatEquipmentMenuButton, combatMainMenuButton;

    public GameObject charSelectWindow, charSelectReturnButton;

    public GameObject speedAura1, speedAura2, speedAura3;

    public GameObject rebirthWindow, craftingWindow, logoutWindow , rebirthAura, craftingAura, logoutAura;

    public GameObject earthWorldInfo, swampWorldInfo, iceWorldInfo, fireWorldInfo;

    public GameObject bagAura, equipmentAura;

    private MapSwitcher ms;

    private bool speed1;
    private bool speed2;
    private bool speed3;
    


    public void Speed1Active()
    {
        speedAura1.SetActive(true);
        speedAura2.SetActive(false);
        speedAura3.SetActive(false);
    }

    public void Speed2Active()
    {
        speedAura1.SetActive(false);
        speedAura2.SetActive(true);
        speedAura3.SetActive(false);
    }

    public void Speed3Active()
    {
        speedAura1.SetActive(false);
        speedAura2.SetActive(false);
        speedAura3.SetActive(true);
    }


    #region MainMenu
    public void OpenCombatWindow()
    {
        if (combatWindow != null)
        {
       
            bool isActive = combatWindow.activeSelf;
            combatWindow.SetActive(true);
            overlayInfoWindow.SetActive(true);
            statsWindow.SetActive(false);
            bagWindow.SetActive(false);
            mapsWindow.SetActive(false);
            settingsWindow.SetActive(false);
            combatEquipmentWindow.SetActive(false);


            if (speedAura1.activeSelf)
            {
                speed1 = true;
                speed2 = false;
                speed3 = false;
                if (GameManager.IsPaused && speed1)
                {
                    GameManager.UnpauseGame();
                }
            }

            if (speedAura2.activeSelf)
            {
                speed1 = false;
                speed2 = true;
                speed3 = false;
                if (GameManager.IsPaused && speed2)
                {
                    GameManager.UnpauseGame();
                }
            }
            
            if (speedAura3.activeSelf)
            {
                speed1 = false;
                speed2 = false;
                speed3 = true;
                if (GameManager.IsPaused && speed3)
                {
                    GameManager.PauseGame();
                }
            }

            GameManager.playerObject.GetComponent<SpriteRenderer>().enabled = true;
            GameManager.enemyObject.GetComponent<SpriteRenderer>().enabled = true;
            var spriteRenderers = GameObject.Find("Equipment").GetComponentsInChildren<SpriteRenderer>();
            foreach (var x in spriteRenderers)
            {
                x.enabled = true;
            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Advanced)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Advanced)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Advanced)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Advanced)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Boss)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Boss)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Boss)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }
            foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Boss)
            {
                actor.GetComponent<SpriteRenderer>().enabled = true;

            }

            if (!isActive)
            {
                welcomeWindow.SetActive(false);
                combatSubMenuButton.SetActive(true);
                combatEquipmentMenuButton.SetActive(true);
                combatMainMenuButton.SetActive(true);

                combatMenuButton.SetActive(false);
                statsMenuButton.SetActive(false);
                bagMenuButton.SetActive(false);
                mapsMenuButton.SetActive(false);
                settingsMenuButton.SetActive(false);

            }
            else
            {
                welcomeWindow.SetActive(false);
                combatSubMenuButton.SetActive(true);
                combatEquipmentMenuButton.SetActive(true);
                combatMainMenuButton.SetActive(true);
            }
        }
    }

    public void OpenStatsWindow()
    {
        if (statsWindow != null)
        {
            bool isActive = statsWindow.activeSelf;
            combatWindow.SetActive(false);
            statsWindow.SetActive(!isActive);
            bagWindow.SetActive(false);
            mapsWindow.SetActive(false);
            settingsWindow.SetActive(false);

            combatMenuButton.SetActive(true);
            statsMenuButton.SetActive(true);
            bagMenuButton.SetActive(true);
            mapsMenuButton.SetActive(true);
            settingsMenuButton.SetActive(true);

            if (!isActive)
            {
                welcomeWindow.SetActive(false);
            }
            else
            {
                welcomeWindow.SetActive(true);
            }
        }
    }

    public void OpenBagWindow()
    {
        if (bagWindow != null)
        {
            bool isActive = bagWindow.activeSelf;
            combatWindow.SetActive(false);
            statsWindow.SetActive(false);
            bagWindow.SetActive(!isActive);
            mapsWindow.SetActive(false);
            settingsWindow.SetActive(false);

            if (!isActive)
            {
                welcomeWindow.SetActive(false);
                bagAura.SetActive(true);
            }
            else
            {
                welcomeWindow.SetActive(true);
                bagAura.SetActive(false);
            }
        }
    }

    public void OpenEffectsWindow()
    {
        if (mapsWindow != null)
        {
            bool isActive = mapsWindow.activeSelf;
            combatWindow.SetActive(false);
            statsWindow.SetActive(false);
            bagWindow.SetActive(false);
            mapsWindow.SetActive(!isActive);
            settingsWindow.SetActive(false);

            if (!isActive)
            {
                welcomeWindow.SetActive(false);
            }
            else
            {
                welcomeWindow.SetActive(true);
            }
        }
    }

    public void OpenSettingsWindow()
    {
        if (settingsWindow != null)
        {
            bool isActive = settingsWindow.activeSelf;
            combatWindow.SetActive(false);
            statsWindow.SetActive(false);
            bagWindow.SetActive(false);
            mapsWindow.SetActive(false);
            settingsWindow.SetActive(!isActive);

            if (!isActive)
            {
                welcomeWindow.SetActive(false);
            }
            else
            {
                welcomeWindow.SetActive(true);
            }
        }
    }
    #endregion

    private void Awake()
    {
        //StartCoroutine(LoadBags());
        //Debug.Log($"UIManager Just Woke Up! {System.DateTime.Now.ToBinary()}");
    }

    private IEnumerator LoadBags()
    {
        OpenCombatWindow();
        OpenEquipmentWindow();
        //GameManager.LoadBags(); // Tells GameManager to save the values to this location before the wait for seconds runs.
        yield return new WaitForSeconds(0.001f);
        CloseEquipmentWindow();
        MainMenu();
    }
    public void OpenEquipmentWindow()
    {
        if (combatEquipmentWindow != null)
        {
            combatEquipmentWindow.SetActive(true);
            bagAura.SetActive(false);
            bool isActive = combatEquipmentWindow.activeSelf;
            if (isActive)
            {
                if (!GameManager.IsPaused) {
                    GameManager.PauseGame();
                }

                GameManager.playerObject.GetComponent<SpriteRenderer>().enabled = false;
                GameManager.enemyObject.GetComponent<SpriteRenderer>().enabled = false;

                var spriteRenderers = GameObject.Find("Equipment").GetComponentsInChildren<SpriteRenderer>();
                foreach (var x in spriteRenderers)
                {
                    x.enabled = false;
                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Advanced)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Advanced)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Advanced)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Advanced)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Boss)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Boss)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Boss)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
                foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Boss)
                {
                    actor.GetComponent<SpriteRenderer>().enabled = false;

                }
            }
                
               combatWindow.SetActive(false);
               combatEquipmentWindow.SetActive(true);
               overlayInfoWindow.SetActive(false);
               bagWindow.SetActive(true);
           
        }
      
    }

    public void CloseEquipmentWindow()
    {
        combatEquipmentWindow.SetActive(false);
        bagWindow.SetActive(false);
        GameManager.UnpauseGame();
    }
    
    public void OpenCharSelectWindow()
    {
        if (charSelectWindow != null)
        {
            bool isActive = charSelectWindow.activeSelf;
            charSelectWindow.SetActive(true);
            charSelectReturnButton.SetActive(true);

            settingsWindow.SetActive(false);
            statsWindow.SetActive(false);
            combatMenuButton.SetActive(false);
            statsMenuButton.SetActive(false);
            bagMenuButton.SetActive(false);
            mapsMenuButton.SetActive(false);
            settingsMenuButton.SetActive(false);
        }
    }

    public void CloseCharSelectWindow()
    {
        charSelectWindow.SetActive(false);
        charSelectReturnButton.SetActive(false);

        settingsWindow.SetActive(true);
        welcomeWindow.SetActive(false);
        combatMenuButton.SetActive(true);
        statsMenuButton.SetActive(true);
        bagMenuButton.SetActive(true);
        mapsMenuButton.SetActive(true);
        settingsMenuButton.SetActive(true);
    }

    public void OpenRebirthWindow()
    {
        rebirthWindow.SetActive(true);
        craftingWindow.SetActive(false);
        logoutWindow.SetActive(false);

        rebirthAura.SetActive(true);
        craftingAura.SetActive(false);
        logoutAura.SetActive(false);

    }

    public void OpenCraftingWindow()
    {
        rebirthWindow.SetActive(false);
        craftingWindow.SetActive(true);
        logoutWindow.SetActive(false);

        rebirthAura.SetActive(false);
        craftingAura.SetActive(true);
        logoutAura.SetActive(false);
    }

    public void OpenLogOutWindow()
    {
        rebirthWindow.SetActive(false);
        craftingWindow.SetActive(false);
        logoutWindow.SetActive(true);

        rebirthAura.SetActive(false);
        craftingAura.SetActive(false);
        logoutAura.SetActive(true);
    }

    public void SelectedEarthMap()
    {
        earthWorldInfo.SetActive(true);
        swampWorldInfo.SetActive(false);
        iceWorldInfo.SetActive(false);
        fireWorldInfo.SetActive(false);
    }

    public void SelectedSwampMap()
    {
        earthWorldInfo.SetActive(false);
        swampWorldInfo.SetActive(true);
        iceWorldInfo.SetActive(false);
        fireWorldInfo.SetActive(false);
    }

    public void SelectedIceMap()
    {
        earthWorldInfo.SetActive(false);
        swampWorldInfo.SetActive(false);
        iceWorldInfo.SetActive(true);
        fireWorldInfo.SetActive(false);
    }

    public void SelectedFireMap()
    {
        earthWorldInfo.SetActive(false);
        swampWorldInfo.SetActive(false);
        iceWorldInfo.SetActive(false);
        fireWorldInfo.SetActive(true);
    }

    

    public void MainMenu()
    {

        if (speedAura1.activeSelf)
        {
            speed1 = true;
            speed2 = false;
            speed3 = false;
            if (GameManager.IsPaused && speed1)
            {
                GameManager.UnpauseGame();
            }
        }

        if (speedAura2.activeSelf)
        {
            speed1 = false;
            speed2 = true;
            speed3 = false;
            if (GameManager.IsPaused && speed2)
            {
                GameManager.UnpauseGame();
            }
        }

        if (speedAura3.activeSelf)
        {
            speed1 = false;
            speed2 = false;
            speed3 = true;
            if (GameManager.IsPaused && speed3)
            {
                GameManager.PauseGame();
            }
        }

        GameManager.playerObject.GetComponent<SpriteRenderer>().enabled = true;
        GameManager.enemyObject.GetComponent<SpriteRenderer>().enabled = true;
        var spriteRenderers = GameObject.Find("Equipment").GetComponentsInChildren<SpriteRenderer>();
        foreach (var x in spriteRenderers)
        {
            x.enabled = true;
        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Advanced)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Advanced)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Advanced)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Advanced)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Fire_Boss)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Earth_Boss)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Wind_Boss)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }
        foreach (GameObject actor in GameObject.FindObjectOfType<MapSwitcher>().enemyObjects_Water_Boss)
        {
            actor.GetComponent<SpriteRenderer>().enabled = true;

        }

        combatWindow.SetActive(false);
        combatEquipmentWindow.SetActive(false);
        bagWindow.SetActive(false);
        welcomeWindow.SetActive(true);
        overlayInfoWindow.SetActive(true);

        combatSubMenuButton.SetActive(false);
        combatEquipmentMenuButton.SetActive(false);
        combatMainMenuButton.SetActive(false);

        combatMenuButton.SetActive(true);
        statsMenuButton.SetActive(true);
        bagMenuButton.SetActive(true);
        mapsMenuButton.SetActive(true);
        settingsMenuButton.SetActive(true);
    }

    public void Logout()
    {
        SceneManager.LoadScene(sceneName: "StartScene");
    }
}