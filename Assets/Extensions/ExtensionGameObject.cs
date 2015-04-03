using UnityEngine;

public static class ExtensionGameObject {

	public static void EnableChildren( this Component component, System.Func<Component, bool> predicate, bool enabled = true ) {
		foreach( var c in component.GetComponentsInChildren<Collider>( true ) ) {
			if( predicate( c ) ) {
				c.enabled = enabled;
			}
		}
		foreach( var c in component.GetComponentsInChildren<Rigidbody>( true ) ) {
			if( predicate( c ) ) {
				c.isKinematic = !enabled;
			}
		}
		foreach( var c in component.GetComponentsInChildren<Behaviour>( true ) ) {
			if( predicate( c ) ) {
				c.enabled = enabled;
			}
		}
	}

	public static void EnableChildren( this Component component, bool enabled = true ) {
		component.EnableChildren( ( a ) => true, enabled );
	}

	public static void EnableChildren( this GameObject go, bool enabled = true ) {
		go.transform.EnableChildren( ( a ) => true, enabled );
	}

	public static void EnableChildren( this GameObject go, System.Func<Component, bool> predicate, bool enabled = true ) {
		go.transform.EnableChildren( predicate, enabled );
	}

}