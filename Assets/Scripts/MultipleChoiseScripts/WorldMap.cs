using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {
    int mapMoveSpeed = 25;
    bool horizontal = true;
    bool vertical = true;
    [SerializeField]
    Image map;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        changeHorizontal();
        moveHorizontal();

        changeVertical();
        moveVertical();
	}

    void moveVertical() {
        if(vertical == true) {
            map.transform.position = Vector3.MoveTowards(map.transform.position, new Vector3(transform.position.x, 10000, 0), Time.deltaTime * mapMoveSpeed);
        }
        else {
            map.transform.position = Vector3.MoveTowards(map.transform.position, new Vector3(transform.position.x, -10000, 0), Time.deltaTime * mapMoveSpeed);
        }
    }

    void changeVertical() {
        if (map.transform.position.y > 1200) {
            vertical = false;
        }
        if (map.transform.position.y < -900) {
            vertical = true;
        }
    }

    void moveHorizontal() {
        if(horizontal == true) {
            map.transform.position = Vector3.MoveTowards(map.transform.position, new Vector3(10000, transform.position.y, 0), Time.deltaTime * mapMoveSpeed);
        }
        else {
            map.transform.position = Vector3.MoveTowards(map.transform.position, new Vector3(-10000, transform.position.y, 0), Time.deltaTime * mapMoveSpeed);
        }
        
    }

    void changeHorizontal() {
        if(map.transform.position.x > 1750) {
            horizontal = false;
        }
        if(map.transform.position.x < -1100) {
            horizontal = true;
        }
    }
}
