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
		public float startingBoost;
		public GameObject background;
		public Transform groundLevel;
		public Transform upperLevel;
		public GameObject victory;
		public Transform cameraPosition;
		public Transform kitePosition;

		private kiteGameState currentState = kiteGameState.starting;
		private float velocity = 0;
		private float maxHeight;

		void Start ()
		{
			victory.SetActive(false);
		}
	
		void Update ()
		{
			float input = Input.GetAxis("Player_SimulateBreathing");
			UpdateState(input);
			UpdateGame(input);
			if(kitePosition.position.y > maxHeight)
			{
				maxHeight = kitePosition.position.y;
			}
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
						velocity = input*startingBoost;
						Debug.Log("switched to Playing");
						currentState = kiteGameState.playing;
					}
				break;

				case kiteGameState.playing:
					if (velocity <= 0 || kitePosition.position.y < groundLevel.position.y || kitePosition.position.y > upperLevel.position.y)
					{
						velocity = 0;
						gravity = gravity/10;
						Debug.Log("switched to Finished");
						currentState = kiteGameState.finished;
						victory.SetActive(true);
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
					//background.transform.position += new Vector3(0, gravity, 0);
					//effect of blowing
					//background.transform.position -= new Vector3(0, airflow*input, 0);
					velocity -= gravity;
					velocity += airflow*input;
					kitePosition.position += new Vector3(0, velocity, 0);
					cameraPosition.position += new Vector3(0, velocity, 0);
				break;
					case kiteGameState.finished:
					if (kitePosition.position.y > groundLevel.position.y)
					{
						//effects of gravity
						velocity -= gravity;
						kitePosition.position += new Vector3(0, velocity, 0);
						cameraPosition.position += new Vector3(0, velocity, 0);
					}
					else
					{
						kitePosition.position = groundLevel.position;
						cameraPosition.position = groundLevel.position;
					}
				break;
			}
		}
	}
}