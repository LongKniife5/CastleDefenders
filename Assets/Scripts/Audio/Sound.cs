﻿using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
	public string name;

	public AudioClip clip;

	public bool playOnAwake;

	[Range(.1f, 3f)]
	public float pitch;
	public bool loop;

	[HideInInspector]
	public AudioSource source;

}