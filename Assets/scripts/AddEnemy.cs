using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddEnemy : MonoBehaviour
{
    public Texture2D enemyTex;
    public GameObject brick;
    public float alwaysDamaged;
    public float damageToWin;
    public int winScreenIndex;


    public float damage = 0f; // Just to see this in editor
    private Vector2 pos;
    private int DX = 32;

    private int DY = 32;

    //private List<Sprite> sprites = new List<Sprite>();
    private List<GameObject> bricks = new List<GameObject>();

    private List<Vector3> initialBricksPos = new List<Vector3>();

    private int updateAt = 5;
    private int lastUpdate = 0;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        var pv = new Vector2(0f, 0f);
        for (int i = 0; i < enemyTex.width; i += DX)
        {
            for (int j = 0; j < enemyTex.height; j += DY)
            {
                // check that texture have no blank pixels

                var needBlock = true;

                for (int k = 0; k < 32; k++)
                {
                    if (needBlock == false)
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

                if (needBlock == false)
                    continue;

                var loc = new Rect(i, j, DX, DY);
                var s = Sprite.Create(enemyTex, loc, pv, 100f);
                var b = Instantiate(brick);
                (b.GetComponent<Renderer>() as SpriteRenderer).sprite = s;
                var cpos = b.GetComponent<Transform>().position;
                b.GetComponent<Transform>().position =
                    new Vector3(pos.x + (float) i / 100f, pos.y + (float) j / 100f, cpos.z);
                SaveBrick(b);

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
    void Update()
    {
    }

    private void SaveBrick(GameObject b)
    {
        bricks.Add(b);
        initialBricksPos.Add(b.transform.position);
    }

    // Update is called once per phisics world
    private void FixedUpdate()
    {
        if (lastUpdate < updateAt)
        {
            lastUpdate += 1;
        }
        else
        {
            lastUpdate = 0;
            damage = CalculateDamage() - alwaysDamaged;
            CheckWin();
        }
    }

    private float CalculateDamage()
    {
        float dmg = 0f;

        var nowBricks = new List<Vector3>();
        bricks.ForEach(b => nowBricks.Add(b.transform.position));

        var y = ToFloat(initialBricksPos);
        var y_ = ToFloat(nowBricks);

        return 1 - Variance(Minus(y, y_)) / Variance(y);
    }

    private List<float> Minus(List<float> a, List<float> b)
    {
        var res = new List<float>(a.Capacity);
        for (int i = 0; i < a.Count; i++)
        {
            res.Add(a[i] - b[i]);
        }
        return res;
    }

    private List<float> ToFloat(List<Vector3> list)
    {
        List<float> res = new List<float>(list.Capacity);
        list.ForEach(el => res.Add(el.magnitude));
        return res;
    }

    private float Variance(List<float> list)
    {
        return Mean(list, 2) - Mathf.Pow(Mean(list, 1), 2);
    }

    private float Mean(List<float> list, int moment)
    {
        float m = 0f;
        foreach (float el in list)
        {
            m += Mathf.Pow(el, moment);
        }
        m /= list.Count;
        return m;
    }

    private void CheckWin()
    {
        if (damage <= damageToWin)
        {
			Debug.Log(string.Format("Win with score: {0}", damage));
			Debug.Log("Go to start");
			SceneManager.LoadScene(winScreenIndex);
        }
    }
}