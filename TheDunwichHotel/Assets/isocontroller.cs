using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isocontroller : MonoBehaviour{

    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    public float walkSpeed;
    public float frameRate;
    // Start is called before the first frame update

    Vector2 direction;

    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        // set walk base
        body.velocity = direction * walkSpeed;

        HandleSpriteFlip();
        // handle direction
        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null) {
            spriteRenderer.sprite = directionSprites[0];
        }
        // vice versa
        
    }
    void HandleSpriteFlip (){
        if (!spriteRenderer.flipX && direction.x < 0) {
            spriteRenderer.flipX = true;
        } else if (spriteRenderer.flipX && direction.x > 0) {
            spriteRenderer.flipX = false;
        }
    }

    List<Sprite> GetSpriteDirection(){

        List<Sprite> selectedSprites = null;


        if (direction.y > 0){
        // north
            if (Mathf.Abs(direction.x)> 0){
                selectedSprites = neSprites;
            } else {
                selectedSprites = nSprites;
            }

        } else if (direction.y < 0){
            if (Mathf.Abs(direction.x)> 0){
                selectedSprites = seSprites;
            } else {
                selectedSprites = sSprites;
            }
        } else {
            if (Mathf.Abs(direction.x)> 0){
                selectedSprites = eSprites;
            }
        }
        return selectedSprites;
    }
}
