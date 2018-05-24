using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;



namespace Games
{

	enum kiteGameState {starting, playing, finished};

	public class KitingGame : MiniGames
	{
		public float gravity;
		public float airflow;
		public GameObject background;
		public Transform startingPosition;
		public Transform groundLevel;
		public Transform upperLevel;

		private kiteGameState currentState = kiteGameState.starting;

		void Start ()
		{
			background.transform.position = startingPosition.position;
		}
	
		void Update ()
		{
			//float test = ;
			UpdateState();
			UpdateGame();
		}

		public override StatChange Play()
		{
			return new StatChange(0,0,0);
		}

		private void UpdateState()
		{
			switch(currentState)
			{
				default:
					//do nothing
				break;

				case kiteGameState.starting:
					if (Input.GetButton("Vertical"))
					{
						currentState = kiteGameState.playing;
					}
				break;

				case kiteGameState.playing:
					if (!Input.GetButton("Vertical") || background.transform.position.y > groundLevel.position.y || background.transform.position.y < upperLevel.position.y)
					{
						currentState = kiteGameState.finished;
					}
				break;
			}
		}

		private void UpdateGame()
		{
			switch(currentState)
			{
				default:
					//do nothing
				break;
					case kiteGameState.playing:
					//effects of gravity
					background.transform.position += new Vector3(0, gravity, 0);
					//effect of blowing
					background.transform.position -= new Vector3(0, airflow, 0);
				break;
					case kiteGameState.finished:
					if (background.transform.position.y < groundLevel.position.y)
					{
						//effects of gravity
						background.transform.position += new Vector3(0, gravity, 0);
					}
				break;
			}
		}
	}
}