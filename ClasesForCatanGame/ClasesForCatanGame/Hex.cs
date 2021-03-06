//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
namespace ClasesForCatanGame
{
	public class Hex
	{
		private Vector3 position;
		private int number; 
		private string resource;
		private bool robber;

		public Hex (Vector3 positionOfHex)
		{
			position = positionOfHex;
			number = 0;
			resource = "desert";
			robber = false;
		}

		public Hex (Vector3 positionOfHex, string resourceOfHex)
		{
			position = positionOfHex;
			number = 0;
			resource = resourceOfHex;
			robber = false;
		}

		public Hex (Vector3 positionOfHex, string resourceOfHex, int numberOfHex)
		{
			position = positionOfHex;
			number = numberOfHex;
			resource = resourceOfHex;
			robber = false;
		}

		// нужен ли расчет векторов граней?


		public void InsertRobber(){
			robber = true;
		}

		public void RemoveRobber(){
			robber = false;
		}

		public bool isRobberHere(){
		return robber;
		}

		public Vector3 Position(){
			return position;
		}

		public string Resource(){
			return resource;
		}

		public int Number(){
			return number;
		}

	}
}

