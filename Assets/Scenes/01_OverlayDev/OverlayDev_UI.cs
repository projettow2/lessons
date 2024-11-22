using System;
using System.Text;
using TMPro;
using UnityEngine;

public class OverlayDev_UI : MonoBehaviour
{
    public const float UPDATE_DELAY_IN_SEC = 0.5f;

    public TMP_Text TopText;
    public TMP_Text FooterText;
    public float UpdateDelay;

    // Variable privée pour stocker la valeur
    [SerializeField] private bool m_OverlayDevOnStartIsShown;

    // Update
    float lastTickRecorded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastTickRecorded = Time.realtimeSinceStartup;
        RetrieveApplicationInfo();
        DisplayOverlayDev(m_OverlayDevOnStartIsShown);
    }

    public void DisplayOverlayDev(bool showOverlay)
    {
        m_OverlayDevOnStartIsShown = showOverlay;
        transform.GetChild(0).gameObject.SetActive(m_OverlayDevOnStartIsShown);
    }

    private void RetrieveApplicationLiveInfo()
    {
        if (!TopText) return;
        StringBuilder sb = new StringBuilder();
        sb.Append($"FPS: {ProjetTow2.MesOutils.GetFPS()}");
        TopText.text = sb.ToString();
    }

    private void RetrieveApplicationInfo()
    {
        if (!FooterText) return;

        // application name
        // applicatoin version
        // platform
        // resolution
        // device model
        // cpu
        // ram
        // -------------


        StringBuilder sb = new StringBuilder("Application Info:");
        // application name
        sb.Append($" {Application.productName}");
        // applicatoin version
        sb.Append($" , version: {Application.version}");
        // platform
        sb.Append($" ({Application.platform})\n");
        // resolution
        sb.Append($"resolution: {Screen.width}x{Screen.height}");
        // device model
        sb.Append($" , model: {SystemInfo.deviceModel}");
        //cpu 
        //sb.Append(ProjetTow2.MesOutils.GetLogString(nameof(SystemInfo.processorType), SystemInfo.processorType));
        sb.Append($" , cpu: {SystemInfo.processorType}");
        // ram
        sb.Append($" , RAM: {SystemInfo.systemMemorySize}");
        //sb.Append(ProjetTow2.MesOutils.GetLogString(nameof(SystemInfo.systemMemorySize), SystemInfo.systemMemorySize));
        FooterText.text = sb.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_OverlayDevOnStartIsShown) return;

        // delay for update triggered?
        if ((Time.realtimeSinceStartup - lastTickRecorded) < UPDATE_DELAY_IN_SEC) return;

        lastTickRecorded = Time.realtimeSinceStartup;
        RetrieveApplicationLiveInfo();
    }
}
