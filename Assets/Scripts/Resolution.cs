using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SharpConfig;

public class Resolution : MonoBehaviour
{
    private Toggle m_Toggle;
    public GameObject config;
    public Text m_Text;

    void Start()
    {
        var config = Configuration.LoadFromFile("config.cfg");
        var section = config["Fullscreen"];

        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, and output the state
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });

        //Initialize the Text to say whether the Toggle is in a positive or negative state
        m_Text.text = "Toggle is : " + m_Toggle.isOn;
    }

    //Output the new state of the Toggle into Text when the user uses the Toggle
    void ToggleValueChanged(Toggle change)
    {
        m_Text.text =  "Toggle is : " + m_Toggle.isOn;

        if(!m_Toggle == m_Toggle.isOn)
        {
            Screen.SetResolution(1280, 720, false);
        } else
        {
            Screen.SetResolution(Screen.width, Screen.height, true);
        }
    }
}
