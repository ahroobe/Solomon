using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstantGuiButton : InstantGuiElement
{
	public InstantGuiActivator onPressed;

    public override void Action ()
	{
		base.Action();
        if (activated)
        {
            onPressed.Activate(this);
            if (base.name == "START") { 
				SceneManager.LoadScene("Game");
				Time.timeScale = 1;
				}
            else if (base.name == "Quit_Yes") { Application.Quit(); }
            else if (base.name == "Quit_Start") { SceneManager.LoadScene("GUIscene"); }
			if (base.name == "Pause_Button") {
				Time.timeScale = 0;
			}
			if (base.name == "Resume") {
				Time.timeScale = 1;
			}
        }
	}
}
