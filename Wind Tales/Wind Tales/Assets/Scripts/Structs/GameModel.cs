using System;
using UnityEngine;

namespace Application
{
	public static class GameModel
	{
		/// <summary>
		/// Gets the float of a key
		/// </summary>
		/// <returns>The float from the action, saved or defaultvalue</returns>
		/// <param name="key">The key to get</param>
		/// <param name="defaultvalue">The value to return if there is no value saved</param>
		private static float GetFloat(string key, float defaultvalue = 0f)
		{
			return PlayerPrefs.GetFloat(key, defaultvalue);
		}

		/// <summary>
		/// Sets the key of the action
		/// </summary>
		/// <param name="key">The key to update</param>
		/// <param name="value">The value to put in</param>
		private static void SetFloat(string key, float value)
		{
			PlayerPrefs.SetFloat(key, value);
		}

		public static void SetHappiness(float value)
		{
			SetFloat("Happiness", value);
		}

		public static float GetHappiness()
		{
			return GetFloat("Happiness");
		}

		public static void SetCleanliness(float value)
		{
			SetFloat("Cleanliness", value);
		}

		public static float GetCleanliness()
		{
			return GetFloat("Cleanliness");
		}

		public static void SetCleanlinessRoom(float value)
		{
			SetFloat("CleanlinessRoom", value);
		}

		public static float GetCleanlinessRoom()
		{
			return GetFloat("CleanlinessRoom");
		}

		public static void SetHunger(float value)
		{
			SetFloat("Hunger", value);
		}

		public static float GetHunger()
		{
			return GetFloat("Hunger");
		}

		//public static DateTime GetLastLogin()
		//{
		//	return (DateTime)PlayerPrefs.GetString("LastLogin");
		//}

		public static void SetLastLogin(DateTime value)
		{
			PlayerPrefs.SetString("LastLogin", value.ToString());
		}

		public static void SetBreathTimeFood(float value)
		{
			SetFloat("BreathTimeFood", value);
		}

		public static float GetBreathTimeFood()
		{
			return GetFloat("BreathTimeFood");
		}

		public static void SetBreathStrengthFlappyBird(float value)
		{
			SetFloat("BreathStrengthFlappyBird", value);
		}

		public static float GetBreathStrengthFlappyBird()
		{
			return GetFloat("BreathStrengthFlappyBird");
		}
	}
}
