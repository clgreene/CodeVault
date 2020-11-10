using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This is a dialogue trigger script to be used with my StringListOperator script, and StringListData and IntData scriptable objects.
//This script triggers a certain NPCs dialogue, as long at the object entering is the Player and is tagged correctly.

public class DialogueTrigger : MonoBehaviour
{

	//establishing Unity Events for dialogue events
	public UnityEvent TriggerCycleEvent, TriggerUpdateEvent, TriggerExitEvent, TriggerSetEvent;



	//Setting the correct dialogue for where you're at in the game.
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			TriggerSetEvent.Invoke();
		}
	}


	//Cycling through and updating the UI with the dialogue loaded in from above;
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			TriggerCycleEvent.Invoke();
			TriggerUpdateEvent.Invoke();
		}
	}


	//resetting dialogue to begining of cycle
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player")) TriggerExitEvent.Invoke();
	}


}
