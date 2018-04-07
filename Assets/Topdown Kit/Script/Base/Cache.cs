using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cache  {

    public static RoleCache Role;

    public static void Init() {
        Role = new RoleCache();
    }
	
}
