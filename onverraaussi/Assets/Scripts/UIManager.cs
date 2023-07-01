using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject vaisseau;
    public Text playerPos;
    private PlayerMovement PM;

    public bool showPlayerPos
    {
        get => showPlayerPos; 
        set => DisplayPlayerPos(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        showPlayerPos = true;
        PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        getPos(vaisseau.transform);
    }

    public void getPos(Transform t)
    {
        playerPos.text = "x = " + t.position.x + " y = " + t.position.y + " z =" + t.position.z;
        playerPos.text += "\nspeed = " + PM._Velocity;
    }

    public void DisplayPlayerPos(bool value)
    {
        playerPos.enabled = value;
    }
}
