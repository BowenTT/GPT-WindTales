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
		public StatChange(int hun, int cln, int hap)
		{
			hunger = hun;
			clean = cln;
			happiness = hap;
		}
	}
}
