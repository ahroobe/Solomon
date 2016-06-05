#pragma strict

function Start () {
    GetComponent.<Animation>()["Jump"].layer = 2;
    GetComponent.<Animation>()["Jump"].wrapMode = WrapMode.Once;

}

function Update () {
    if (Input.GetKey(KeyCode.UpArrow)){
        GetComponent.<Animation>().Play("Jump");
    }
}