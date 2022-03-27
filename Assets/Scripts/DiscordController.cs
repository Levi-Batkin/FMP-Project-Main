using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour {

	public Discord.Discord discord;

	// Use this for initialization
	void Start () {
		discord = new Discord.Discord(957205184768008212, (System.UInt64)Discord.CreateFlags.Default);
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			Details = "Viewing the main menu...",
			State = "In the menus",
			Assets = {
				LargeImage = "bg",
			},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("DiscordController.cs > Connected Successfully.");
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
		discord.RunCallbacks();
	}
	public void ViewingMainMenu()  
	{
		var activityManager = discord.GetActivityManager();
		var activity2 = new Discord.Activity
		{
			Details = "Viewing the main menu...",
			State = "In the menus",
			Assets = {
				LargeImage = "bg",
			},
		};
		activityManager.UpdateActivity(activity2, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("DiscordController.cs > Updated Successfully.");
			}
		});
	}
	public void ViewingOptions()  
	{
		var activityManager = discord.GetActivityManager();
		var activity2 = new Discord.Activity
		{
			Details = "Viewing the options menu...",
			State = "In the menus",
			Assets = {
				LargeImage = "bg",
			},
		};
		activityManager.UpdateActivity(activity2, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("DiscordController.cs > Updated Successfully.");
			}
		});
	}
	public void ViewingHowToPlay()  
	{
		var activityManager = discord.GetActivityManager();
		var activity3 = new Discord.Activity
		{
			Details = "Viewing how to play...",
			State = "In the menus",
			Assets = {
				LargeImage = "bg",
			},
		};
		activityManager.UpdateActivity(activity3, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("DiscordController.cs > Updated Successfully.");
			}
		});
	}
	public void ClearPresence()
    {
        discord.Dispose();
    }
}