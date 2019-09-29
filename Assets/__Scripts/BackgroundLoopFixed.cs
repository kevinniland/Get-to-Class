using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoopFixed : MonoBehaviour
{
    public Sprite[] backgrounds;
    public RawImage backgroundRenderer;
    public float repeat = 3;
    public float slidingSpeedX = .2f, slidingSpeedY = -.2f;
    float moveByX, moveByY;
    Resolution res;
    Sprite useThis;
    float horizontalTiles, verticalTiles;
    int vTiles, hTiles;

    // Use this for initialization
    void Start()
    {
        res = Screen.currentResolution;
        //this script uses a random background, you can set any kind of texture here
        System.Random rnd = new System.Random(System.DateTime.Now.Minute);
        useThis = backgrounds[rnd.Next(0, backgrounds.Length)];
        //this part calculates the screen's size vs texture's size, 
        //so that you don't have to think about it
        horizontalTiles = (float)Screen.width / (float)(useThis.texture.width);
        verticalTiles = (float)Screen.height / (float)(useThis.texture.height);
        //adds in the repeat amount you want in there
        verticalTiles = verticalTiles * repeat;
        horizontalTiles = horizontalTiles * repeat;
        backgroundRenderer.texture = useThis.texture;
        Rect uvRect = new Rect(0, 0, horizontalTiles, verticalTiles);
        backgroundRenderer.uvRect = uvRect;

    }

    // Update is called once per frame
    void Update()
    {
        //moves the sprite over time. if you want this to move with the player,
        //you'll need to get the player location and move it according to that.
        //(it should be relatively easy, but it'll take time to implement).
        moveByX = moveByX + slidingSpeedX * Time.unscaledDeltaTime;
        moveByY = moveByY + slidingSpeedY * Time.unscaledDeltaTime;
        backgroundRenderer.uvRect = new Rect(moveByX, moveByY, horizontalTiles, verticalTiles);
        //check if the screen size changed and recalculate
        if (res.height != Screen.currentResolution.height
        || res.width != Screen.currentResolution.width)
        {
            horizontalTiles = (float)Screen.width / (float)(useThis.texture.width);
            verticalTiles = (float)Screen.height / (float)(useThis.texture.height);
            verticalTiles = verticalTiles * repeat;
            backgroundRenderer.texture = useThis.texture;
            horizontalTiles = horizontalTiles * repeat;
        }
    }
}
