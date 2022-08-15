using UI.Component;
using UnityEditor;

[CustomEditor(typeof(UIDropdown))]
public class UIDropdownDrawer : UISelectableDrawer {
	private SerializedProperty labelProp;
	private SerializedProperty arrowProp;
	private SerializedProperty dropdownProp;

	public override void OnInspectorGUI() {
		base.OnInspectorGUI();
		serializedObject.Update();
		labelProp = serializedObject.FindProperty("dropdownLabel");
		arrowProp = serializedObject.FindProperty("arrow");
		dropdownProp = serializedObject.FindProperty("dropdown");
		EditorGUILayout.Space(20);
		EditorGUILayout.PropertyField(labelProp);
		EditorGUILayout.PropertyField(arrowProp);
		EditorGUILayout.PropertyField(dropdownProp);
		serializedObject.ApplyModifiedProperties();
	}
}