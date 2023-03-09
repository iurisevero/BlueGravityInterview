using UnityEngine;
using System;

// Reference: Reality RPG game by Mach874k, also used on Running Up That City (https://github.com/GameJamFGA-UnB/Grupo4)
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
	private static T instance;
	public static T Instance {

		get {

			if(instance == null) {
				try{
					instance = FindObjectOfType<T>();
					DontDestroyOnLoad(instance);
				} catch(NullReferenceException e) {
					Debug.Log(e);
					instance = null;
				}
			}
			return instance;
		}
	}
}
