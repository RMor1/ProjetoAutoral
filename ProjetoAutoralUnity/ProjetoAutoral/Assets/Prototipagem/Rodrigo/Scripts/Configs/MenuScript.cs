﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    GameObject baseMenu;

    GameObject optionsMenu;

    GameObject controlsMenu;
    GameObject controlsOnWaitForInputMsg;
    GameObject controlsButtons;

    private void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        optionsMenu = canvas.transform.Find("OptionsTab").gameObject;
        baseMenu = canvas.transform.Find("BaseMenu").gameObject;
        controlsMenu = canvas.transform.Find("ControlsTab").gameObject;
        controlsOnWaitForInputMsg = controlsMenu.transform.Find("NextKeyMsg").gameObject;
        controlsButtons = controlsMenu.transform.Find("ControlsButtons").gameObject;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Jogar");
    }
    public void Credits()
    {
        Debug.Log("Creditos");
    }
    public void Controls()
    {
        Debug.Log("Controles");
        baseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        waitForInput = StartCoroutine(WaitForInput(MenuConfigs.Action.Menu, ExitControls));
    }
    public void OnChangeInput(int actionKeyID)
    {
        controlsButtons.SetActive(false);
        controlsOnWaitForInputMsg.SetActive(true);
        StartCoroutine(WaitForNextControlsInput(actionKeyID));
    }
    private IEnumerator WaitForNextControlsInput(int actionKeyID)
    {
        StopCoroutine(waitForInput);
        waitForInput = null;
        while (Input.inputString == "")
        {
            yield return null;
        }
        MenuConfigs.Instance.InputKeys[actionKeyID] = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
        //update all 
        controlsOnWaitForInputMsg.SetActive(false);
        controlsButtons.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        waitForInput = StartCoroutine(WaitForInput(MenuConfigs.Action.Menu, ExitControls));
    }
    public void ExitControls()
    {
        controlsMenu.SetActive(false);
        baseMenu.SetActive(true);
    }
    public void Options()
    {
        Debug.Log("Opções");
        baseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        waitForInput = StartCoroutine(WaitForInput(MenuConfigs.Action.Menu, ExitOptions));
    }
    public void VolumeSlider(Slider slider)
    {
        AudioListener.volume = slider.value;
    }
    public void ExitOptions()
    {
        baseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    private Coroutine waitForInput;
    public IEnumerator WaitForInput(MenuConfigs.Action actionKey, waitForInputConsequence consequence)
    {
        waitForInputConsequence WaitForInputConsequence;
        WaitForInputConsequence = consequence;
        while (!Input.GetKeyDown(MenuConfigs.Instance.InputKeys[(int)actionKey]))
        {
            yield return null;
        }
        WaitForInputConsequence();
    }
    public delegate void waitForInputConsequence();
}