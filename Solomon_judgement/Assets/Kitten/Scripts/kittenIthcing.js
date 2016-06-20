#pragma strict

function Start () {
	GetComponent.<Animation>()["Ithcing"].layer  = 1;
	GetComponent.<Animation>()["Ithcing"].wrapMode = WrapMode.Once;
	GetComponent.<Animation>().Play("Ithcing");
}

function Update () {
	
		
	
}