using UnityEngine;
using UnityEngine.Playables;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Timeline")]
	[Tooltip("Play Unity timeline. This action requires Unity 2017.1 or above.")]

	public class  playTimeline : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayableDirector))]
		[Tooltip("The game object to hold the unity timeline components.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("Event to send when the timeline is finished playing.")]
		public FsmEvent finishEvent;

		[Tooltip("Check this box to preform this action every frame.")]
		//public FsmBool everyFrame;

		private PlayableDirector timeline;

		public override void Reset()
		{

			gameObject = null;
			//everyFrame = false;
			finishEvent = null;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			timeline = go.GetComponent<PlayableDirector>();

			//if (!everyFrame.Value)
			{
				timelineAction();
				//Finish();
			}

		}

		public override void OnUpdate()
		{
			/*if (everyFrame.Value)
			{
				timelineAction();
			}*/

			// Check if timeline has finished playing
			if(timeline.time >= (timeline.duration - 0.1f))
			{
				Fsm.Event(finishEvent);
				Finish();
			}
		}

		void timelineAction()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			timeline.Play();
		}

	}
}