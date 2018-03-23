using UnityEngine;
using System.Collections;

namespace PixelCrushers.DialogueSystem.Examples {

	public class KillCount : MonoBehaviour {

		public string variable;
		public int increment = 1;
		public int min = 0;
		public int max = 100;

		void OnDestroy() {
			if (!string.IsNullOrEmpty(variable)) {
				int oldValue = DialogueLua.GetVariable(variable).AsInt;
				int newValue = Mathf.Clamp(oldValue + increment, min, max);
				DialogueLua.SetVariable(variable, newValue);
				DialogueManager.Instance.SendMessage("UpdateTracker", SendMessageOptions.DontRequireReceiver);
			}
		}

	}

}