using UnityEngine;
using System.Collections;

public static class Orders {

	public static Order CreateStopOrder()
	{
		return new Order("Stop", 0);
	}
	
	public static Order CreateMoveOrder(Vector3 location)
	{
		return new Order("Move", 1, location);
	}
	
	public static Order CreateAttackOrder(RTSObject obj)
	{
		return new Order("Attack", 2, obj);
	}
	
	public static Order CreateDeployOrder()
	{
		return new Order("Deploy", 3);
	}
}
