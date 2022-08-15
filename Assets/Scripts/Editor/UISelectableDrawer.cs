using UI.Component;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UISelectable))]
public class UISelectableDrawer : Editor {
	private SerializedProperty fillProp;
	private SerializedProperty borderProp;
	private SerializedProperty labelProp;
	private SerializedProperty deselectProp;
	private SerializedProperty settingsProp;

	public override void OnInspectorGUI() {
		var selectable = (UISelectable)target;
		serializedObject.Update();
		fillProp = serializedObject.FindProperty("fill");
		borderProp = serializedObject.FindProperty("border");
		labelProp = serializedObject.FindProperty("label");
		deselectProp = serializedObject.FindProperty("deselectAfterClick");
		settingsProp = serializedObject.FindProperty("settings");

		EditorGUILayout.PropertyField(fillProp);
		EditorGUILayout.PropertyField(borderProp);
		EditorGUILayout.PropertyField(labelProp);
		EditorGUILayout.PropertyField(deselectProp);
		EditorGUILayout.PropertyField(settingsProp);

		using (var _ = new EditorGUILayout.HorizontalScope()) {
			if(GUILayout.Button("Set Unpressed")) selectable.SetUnpressed();
			if(GUILayout.Button("Set Selected")) selectable.SetSelected();
			if(GUILayout.Button("Set Pressed")) selectable.SetPressed();
			if(GUILayout.Button("Set Error")) selectable.SetError();
		}

		serializedObject.ApplyModifiedProperties();
	}
}