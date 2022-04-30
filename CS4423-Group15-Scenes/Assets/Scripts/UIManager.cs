using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject hudCanvas = null;
    [SerializeField] private GameObject endCanvas = null;

	private void Start()
	{
		SetActiveHud(true);
	}

    public void SetActiveHud(bool state)
	{
		hudCanvas.SetActive(state);
		endCanvas.SetActive(!state);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
