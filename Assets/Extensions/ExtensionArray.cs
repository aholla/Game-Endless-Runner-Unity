using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class ExtensionArray {

	/// <summary>
	/// Suffles the array.
	/// </summary>
	public static void Shuffle<T>( this T[] arr ) {		
		for( int i = 0; i < arr.Length; i++ ) {
			T tmp = arr[ i ];
			int r = Random.Range( i, arr.Length );
			arr[ i ] = arr[ r ];
			arr[ r ] = tmp;
		}
	}

	/// <summary>
	/// Logs the array items.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="arr">The Array</param>
	/// <param name="prefix">The prefix.</param>
	public static void LogArrayItems<T>( this T[] arr, string prefix = "" ) {
		string outputStr = "" + prefix;
		for( int i = 0; i < arr.Length; i++ ){
			outputStr += arr[ i ];
		}
		Debug.Log( outputStr );
	}


	
}
