using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class DG_InputManager : MonoBehaviour
{
	private static DG_InputManager instance;
	public static DG_InputManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<DG_InputManager>();
				return instance;
			}
			return instance;
		}
	}
	private ActionMap baseActionMap = null;
	private Dictionary<string, InputActionMap> mapDictionary = new();
	private void Awake()
	{
		baseActionMap = new ActionMap();
		Debug.Log(baseActionMap.FindAction("LeftClick").WasPerformedThisFrame());
		ReadOnlyArray<InputActionMap> allMaps = baseActionMap.asset.actionMaps;
		mapDictionary.Clear();
		mapDictionary.AddRange(allMaps.ToDictionary((x) => x.name));
	}
	public InputActionMap GetMap(MapName mapName)
	{
		if (mapDictionary == null || mapDictionary.ContainsKey(mapName.ToString()) == false)
		{
			Debug.Log($"Cannot find map : {mapName}");
			return null;
		}
		return mapDictionary[mapName.ToString()	];
	}
	public void EnableMap(MapName mapName)
	{
		if (GetMap(mapName) == null)
		{
			return;
		}
		GetMap(mapName).Enable();
	}
	public void DisableMap(MapName mapName)
	{
		if (GetMap(mapName) == null)
		{
			return;
		}
		GetMap(mapName).Disable();
	}
	public bool GetButtonDown(ActionName actionName)
	{
		return baseActionMap.FindAction(actionName.ToString()).WasPressedThisFrame();
	}
	public bool GetButton(ActionName actionName)
	{
		return baseActionMap.FindAction(actionName.ToString()).IsPressed();
	}
	public bool GetButtonUp(ActionName actionName)
	{
		return baseActionMap.FindAction(actionName.ToString()).WasReleasedThisFrame();
	}
	public T GetAxis<T>(ActionName actionName) where T : struct
	{
		return baseActionMap.FindAction(actionName.ToString()).ReadValue<T>();
	}
}
public enum MapName
{
	Player,
	UI,
	Common,
}
public enum ActionName
{
	LeftClick,
	RightClick,
}
