using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSpriteController : Singleton<FloatingSpriteController>
{
    const string FloatingSpritePoolKey = "FloatingSprite.FloatingText";
    const int Speed = 2;
    [SerializeField] private GameObject floatingSpritePrefab;

    private void Start()
    {
        GameObjectPoolController.AddEntry(FloatingSpritePoolKey, floatingSpritePrefab, 10, 100);
    }

    private GameObject Dequeue(){
        Poolable p = GameObjectPoolController.Dequeue(FloatingSpritePoolKey);
        SpriteRenderer floatingSprite = p.GetComponent<SpriteRenderer>();
        floatingSprite.transform.localScale = Vector3.one;
        floatingSprite.gameObject.SetActive(true);
        return floatingSprite.gameObject;
    }

    private void Enqueue(GameObject floatingTextObject)
    {
        Poolable p = floatingTextObject.GetComponent<Poolable>();
        GameObjectPoolController.Enqueue(p);
    }

    private IEnumerator AnimateFloatingSprite(GameObject floatingSprite)
    {
        int times = 0;
        while(times < 50){
            floatingSprite.transform.Translate(Vector3.up * Speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            times++;
        }
        Enqueue(floatingSprite);
    }

    public void FloatSprite(Transform parent, Sprite sprite)
    {
        GameObject spritePrefab = Dequeue();
        spritePrefab.transform.SetParent(parent);
        spritePrefab.transform.localPosition = Vector3.zero;
        spritePrefab.GetComponent<SpriteRenderer>().sprite = sprite;
        StartCoroutine(AnimateFloatingSprite(spritePrefab));

    }
}
