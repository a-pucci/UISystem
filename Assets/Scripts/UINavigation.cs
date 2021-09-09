using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UINavigation : MonoBehaviour {
	private static GameObject CurrentObject => EventSystem.current.currentSelectedGameObject;

	private float Horizontal => Input.GetAxis("Horizontal");
	private float Vertical => Input.GetAxis("Vertical");
	private bool LeftInput => Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Horizontal < 0;
	private bool RightInput => Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Horizontal > 0;
	private bool UpInput => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Vertical > 0;
	private bool DownInput => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Vertical < 0;
	
	
	public static void UpdateSelectedObject(GameObject obj) {
		if (CurrentObject != obj) 
			EventSystem.current.SetSelectedGameObject(obj);
	}

	// private void Update() => HandleInputs();
	//
	// private void HandleInputs() {
	// 	if (TryExecute(UpInput, MoveUp))
	// 		return;
	// 	if (TryExecute(DownInput, MoveDown))
	// 		return;
	// 	if (TryExecute(LeftInput, MoveLeft))
	// 		return;
	// 	TryExecute(RightInput, MoveRight);
	// }
	//
	// private bool TryExecute(bool input, Action action) {
	// 	if (!input)
	// 		return false;
	// 	action?.Invoke();
	// 	return true;
	// }
	//
	// private void MoveRight() {
	// 	if (CurrentObject != null && CurrentObject.TryGetComponent(out Selectable selectable))
	// 		ChangeSelection(selectable.navigation.selectOnRight);
	// }
	//
	// private void MoveLeft() {
	// 	if (CurrentObject != null && CurrentObject.TryGetComponent(out Selectable selectable))
	// 		ChangeSelection(selectable.navigation.selectOnLeft);
	// }
	//
	// private void MoveUp() {
	// 	if (CurrentObject != null && CurrentObject.TryGetComponent(out Selectable selectable)) 
	// 		ChangeSelection(selectable.navigation.selectOnUp);
	// }
	//
	// private void MoveDown() {
	// 	if (CurrentObject != null && CurrentObject.TryGetComponent(out Selectable selectable)) 
	// 		ChangeSelection(selectable.navigation.selectOnDown);
	// }
	//
	// private void ChangeSelection(Selectable selectable) {
	// 	if(selectable != null && InputHandler.CurrentControllerType == ControllerType.Keyboard)
	// 		EventSystem.current.SetSelectedGameObject(selectable.gameObject);
	// }
}
