using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SharpConfig;
using System.IO;

public class ConfigFile : MonoBehaviour
{
	public Toggle m_Toggle;
    public Toggle v_Toggle;
	public Configuration cfg = new Configuration();

	void Start()
	{
        var section = cfg["VSYNC"];

		if (!File.Exists ("config.cfg"))
		{
			Debug.Log ("Setting up a default config since no file was found!");
			SetupCleanCFG ();
			SaveConfig ();
		}

		// Load the configuration.
		cfg = Configuration.LoadFromFile("config.cfg");
	}

	public void SaveConfig()
	{
		Debug.Log ("Saving Client config...");

        cfg["Fullscreen"]["Windowed"].BoolValue = !m_Toggle.isOn;
        cfg["VSYNC"]["FPS LOCKED"].BoolValue = v_Toggle.isOn;

		// Save the configuration.
		cfg.SaveToFile ("config.cfg");
	}

    public void SaveConfigButton()
    {
        Debug.Log ("Saving Client config...");

        cfg["Fullscreen"]["Windowed"].BoolValue = !m_Toggle.isOn;
        cfg["VSYNC"]["FPS LOCKED"].BoolValue = v_Toggle.isOn;

		// Save the configuration.
		cfg.SaveToFile ("config.cfg");
        
        // Reload the configuration.
        cfg = Configuration.LoadFromFile("config.cfg");
    }

	private void SetupCleanCFG()
	{
		cfg["Fullscreen"]["Windowed"].BoolValue = !m_Toggle.isOn;
        cfg["VSYNC"]["FPS LOCKED"].BoolValue = v_Toggle.isOn;
	}

    public void vsync()
    {
        if(v_Toggle == v_Toggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else
        {
            Application.targetFrameRate = 300;
        }
    }
}