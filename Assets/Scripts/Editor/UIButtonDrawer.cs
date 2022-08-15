using UI.Component;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UIButton))]
public class UIButtonDrawer : UISelectableDrawer {
	private SerializedProperty notAvailableProp;
	private SerializedProperty changeViewProp;
	private SerializedProperty showViewProp;
	private SerializedProperty hideViewProp;
	
	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		var button = (UIButton)target;
		serializedObject.Update();
		notAvailableProp = serializedObject.FindProperty("notAvailable");
		changeViewProp = serializedObject.FindProperty("changeViewOnClick");
		showViewProp = serializedObject.FindProperty("viewToShow");
		hideViewProp = serializedObject.FindProperty("viewToHide");

		EditorGUILayout.Space(20);
		bool notAvailable = notAvailableProp.boolValue;
		EditorGUILayout.PropertyField(notAvailableProp, new GUIContent("Not Available", "Set button availability"));
		
		if (notAvailable != notAvailableProp.boolValue) 
			button.ChangeVisibility();
		
		EditorGUILayout.PropertyField(changeViewProp, new GUIContent("Change View", "Enable changing view"));

		if (changeViewProp.boolValue) {
			EditorGUILayout.PropertyField(showViewProp, new GUIContent("Show", "View to show when pressed"));
			EditorGUILayout.PropertyField(hideViewProp, new GUIContent("Hide", "View to hide when pressed"));
		}
		serializedObject.ApplyModifiedProperties();
	}
}