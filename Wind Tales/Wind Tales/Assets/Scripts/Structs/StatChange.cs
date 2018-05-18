using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Structs
{
	public struct StatChange
	{
		int hunger;
		int clean;
		int happiness;
		public StatChange(int hng, int cln, int hap)
		{
			hunger = hng;
			clean = cln;
			happiness = hap;
		}
	}
}
