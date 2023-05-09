using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	private void OnEnable()
	{
		DG_InputManager.Instance.EnableMap(MapName.Common);
	}
	private void OnDisable()
	{
		DG_InputManager.Instance.DisableMap(MapName.Common);
	}
	private void Update()
	{
		if (DG_InputManager.Instance.GetButtonDown(ActionName.RightClick) == true)
		{
			Debug.Log("R.Click");
		}
		else if (DG_InputManager.Instance.GetButtonDown(ActionName.LeftClick) == true)
		{
			Debug.Log("L.ClickDown");
		}
		else if (DG_InputManager.Instance.GetButton(ActionName.LeftClick) == true)
		{
			Debug.Log("L.Click");
		}
		else if (DG_InputManager.Instance.GetButtonUp(ActionName.LeftClick) == true)
		{
			Debug.Log("L.ClickUp");
		}
	}

}
