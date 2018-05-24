using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;

namespace Games
{
	public class CleaningGame : MiniGames
	{

		public override StatChange Play()
		{
			return new StatChange(0,0,0);
		}
	}
}