using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exemple_02_02 : MonoBehaviour
{    
    public Movement myPlayer;
    private Dictionary<IPlayerControl.eControllerType, bool> m_playerControllerMap;

    public Image imgBtnKeyboard;
    public Image imgBtnMouse;
    public Image imgBtnXbox;

    private void Start()
    {
        m_playerControllerMap = new Dictionary<IPlayerControl.eControllerType, bool>();
        m_playerControllerMap[IPlayerControl.eControllerType.keyboard] = false;
        m_playerControllerMap[IPlayerControl.eControllerType.inGameMouse] = false;
        m_playerControllerMap[IPlayerControl.eControllerType.xbox] = false;
        UpdateVisual(IPlayerControl.eControllerType.keyboard);
        UpdateVisual(IPlayerControl.eControllerType.inGameMouse);
        UpdateVisual(IPlayerControl.eControllerType.xbox);
    }

    public void UpdatePlayerControl(IPlayerControl.eControllerType type)
    {
        myPlayer.SetPlayerControlActivity(type, m_playerControllerMap[type]);
        UpdateVisual(type);
    }

    private void UpdateVisual(IPlayerControl.eControllerType type)
    {
        switch (type)
        {
            case IPlayerControl.eControllerType.none:
                break;
            case IPlayerControl.eControllerType.keyboard:
                imgBtnKeyboard.color = m_playerControllerMap[type] ? Color.green : Color.red;
                break;
            case IPlayerControl.eControllerType.inGameMouse:
                imgBtnMouse.color = m_playerControllerMap[type] ? Color.green : Color.red;
                break;
            case IPlayerControl.eControllerType.xbox:
                imgBtnXbox.color = m_playerControllerMap[type] ? Color.green : Color.red;
                break;
        }
    }

    public void TogglePlayerController(int i) 
    {
        IPlayerControl.eControllerType type = IPlayerControl.eControllerType.none;
        if (i == 1) type = IPlayerControl.eControllerType.keyboard;
        if (i == 2) type = IPlayerControl.eControllerType.inGameMouse;
        if (i == 3) type = IPlayerControl.eControllerType.xbox;

        if (type == IPlayerControl.eControllerType.none) return;

        m_playerControllerMap[type] = !m_playerControllerMap[type];
        UpdatePlayerControl(type);
    }
}