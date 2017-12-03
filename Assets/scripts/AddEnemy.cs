using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour
{
	public Texture2D enemyTex;
	public GameObject brick;
	public Vector2 pos;

	private int DX = 32;
	private int DY = 32;
	//private List<Sprite> sprites = new List<Sprite>();
	
	// Use this for initialization
	void Start () {
		var pv = new Vector2(0f, 0f);
		for (int i = 0; i < enemyTex.width; i += DX)
		{
			for (int j = 0; j < enemyTex.height; j += DY)
			{
				// check that texture have no blank pixels
				
				var needBlock = true;
				
				for (int k = 0; k < 32; k++)
				{
					if(needBlock == false)
						break;
					
					for (int l = 0; l < 32; l++)
					{
						if (enemyTex.GetPixel(i + k, j + l).a == 0)
						{
							needBlock = false;
							break;
						}
					}
				}
				
				if(needBlock == false)
					continue;
				
				var loc = new Rect(i, j, DX, DY);
				var s = Sprite.Create(enemyTex, loc, pv, 100f);
				var b = Instantiate(brick);
				(b.GetComponent<Renderer>() as SpriteRenderer).sprite  = s;
				var cpos = b.GetComponent<Transform>().position;
				b.GetComponent<Transform>().position = new Vector3(pos.x + (float) i / 100f, pos.y + (float) j / 100f, cpos.z);

				// sprites.Add(s);
				// Debug.Log(i, j);
			}
		}
//		Debug.Log(sprites);
//		for (int i = 0; i < 100; i++)
//		{
//			var b = Instantiate(brick);
//			(b.GetComponent<Renderer>() as SpriteRenderer).sprite  = sprites[i];	
//		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
