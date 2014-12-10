using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
	public static string fileExtension = ".are";
	string saveDirectory = Application.persistentDataPath + "/Saves/";
	public List<GameSave> gameSaves;

	void Init()
	{
		//Init our list of game saves (but don't load any).
		gameSaves = new List<GameSave>();

		var filenames = Directory.GetFiles(saveDirectory);
		foreach (var filename in filenames)
		{
			var save = new GameSave(filename, File.GetLastWriteTime(saveDirectory + filename));
			gameSaves.Add(save);
		}
	}

	public CharacterData LoadLatestSave()
	{
		var save = gameSaves.OrderByDescending(e => e.timeStamp).FirstOrDefault();
		if (save != null)
		{
			return Load(save.saveName);
		}
		return null;
	}

	public CharacterData Load(string saveName)
	{
		var save = gameSaves.FirstOrDefault(e => e.saveName == saveName);
		if (save != null)
		{
			var stream = File.Open(saveDirectory + save.saveName + fileExtension, FileMode.Open);
			var bformatter = new BinaryFormatter();

			var charData = (CharacterData)bformatter.Deserialize(stream);
			stream.Close();
			return charData;
		}
		return null;
	}

	public void Save(string saveName, CharacterData charData)
	{
		var stream = File.Open(saveDirectory + saveName + fileExtension, FileMode.OpenOrCreate);
		var bformatter = new BinaryFormatter();

		bformatter.Serialize(stream, charData);
		stream.Close();
		//Reload our list of saves.
		Init();
	}
}
