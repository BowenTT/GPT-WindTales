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
			float input = Input.GetAxis("Player_SimulateBreathing");
			UpdateState(input);
			UpdateGame(input);
		}

		public override StatChange Play()
		{
			return new StatChange(0,0,0);
		}

		private void UpdateState(float input)
		{
			switch(currentState)
			{
				default:
					//do nothing
				break;

				case kiteGameState.starting:
					if (input > 0)
					{
						currentState = kiteGameState.playing;
					}
				break;

				case kiteGameState.playing:
					if (input <= 0 || background.transform.position.y > groundLevel.position.y || background.transform.position.y < upperLevel.position.y)
					{
						currentState = kiteGameState.finished;
					}
				break;
			}
		}

		private void UpdateGame(float input)
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
					background.transform.position -= new Vector3(0, airflow*input, 0);
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