using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;



namespace Games
{

	enum kiteGameState {beginningAnimation, starting, playing, finished};

	public class KitingGame : MiniGames
	{
		public float gravity;
		public float airflow;
		public float startingBoost;
		public Transform groundLevel;
		public Transform upperLevel;
		public GameObject beginnningPlaceholder;
		public GameObject victory;
		public GameObject startingIcon;
		public Transform cameraPosition;
		public Transform kitePosition;

		private kiteGameState currentState = kiteGameState.beginningAnimation;
		private float velocity = 0;
		private float maxHeight;
		int animI = 0, animJ = 0, animK = 0;

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
						startingIcon.SetActive(false);
						currentState = kiteGameState.playing;
					}
				break;

				case kiteGameState.playing:
					if (velocity <= 0 || kitePosition.position.y > upperLevel.position.y)
					{
						velocity = 0;
						gravity = gravity/10;
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
				case kiteGameState.beginningAnimation:
					beginnningPlaceholder.SetActive(true);
					bool done = false;
					if(animI < 30)
					{
						velocity = 1f/100;
						animI++;
					}
					else if(animJ < 60)
					{
						velocity = -1f/100;
						animJ++;
					}
					else if (animK < 30)
					{
						velocity = 1f/100;
						animK++;
					}
					else
					{
						done = true;
					}
					kitePosition.position += new Vector3(0, velocity, 0);
					if(done)
					{
						velocity = 0;
						currentState = kiteGameState.starting;
						beginnningPlaceholder.SetActive(false);
					}
					break;
				case kiteGameState.playing:
					velocity -= gravity;
					velocity += airflow*input;
					kitePosition.position += new Vector3(0, velocity, 0);
					cameraPosition.position += new Vector3(0, velocity, 0);
					break;
				case kiteGameState.finished:
					if (kitePosition.position.y >= groundLevel.position.y)
					{
						//effects of gravity
						velocity -= gravity;
						kitePosition.position += new Vector3(0, velocity, 0);
						cameraPosition.position += new Vector3(0, velocity, 0);
					}
					else
					{
						kitePosition.position = groundLevel.position;
						cameraPosition.position = new Vector3(groundLevel.position.x, groundLevel.position.y, -10);
						gravity = 0;
						velocity = 0;
					}
				break;
			}
		}
	}
}