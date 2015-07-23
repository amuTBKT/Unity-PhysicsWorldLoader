using UnityEngine;
using UnityEditor; 
using System.Collections;
using System.Collections.Generic;

// place this script in Editor folder

[CustomEditor(typeof(WorldLoader))]
public class WorldLoaderInspector : Editor {

	WorldLoader loader;

	void OnEnable () {
		loader = (WorldLoader) target;
	}

	public override void OnInspectorGUI ()
	{
		// draw the default inspector
		DrawDefaultInspector();

		// draw custom button which when clicked, loads the scene
		if (GUILayout.Button("Load Scene")){
			loader.loadJsonScene();
		}

		// delete created gameobjects
		if (GUILayout.Button("Delete Loaded Scene")){
			if (loader.getLoadedObjects() != null){
				for (int i = 0, numberofLoadedObjects = loader.getLoadedObjects().Count; i < numberofLoadedObjects; i++){
					DestroyImmediate(loader.getLoadedObjects()[i]);
				}
				loader.reset();
			}
		}
	}
}
