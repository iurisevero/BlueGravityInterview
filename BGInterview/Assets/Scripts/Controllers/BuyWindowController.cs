using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyWindowController : MonoBehaviour
{
    const string HideKey = "Hide";
    const string ShowKey = "Show";
    [SerializeField] private Panel panel;
    [SerializeField] private RectMask2D rectMask2D;
    [SerializeField] private TextMeshProUGUI headPrice;
    [SerializeField] private Image headSprite;
    [SerializeField] private TextMeshProUGUI bodyPrice;
    [SerializeField] private Image bodySprite;
    [SerializeField] private Image lArmSprite;
    [SerializeField] private Image rArmSprite;
    [SerializeField] private TextMeshProUGUI legsPrice;
    [SerializeField] private Image lLegSprite;
    [SerializeField] private Image rLegSprite;
    private Vector4 rectMaskOriginalPadding;
    public List<Head> heads;
    public List<Body> bodies;
    public List<Legs> legs;
    public int currentHead, currentBody, currentLegs;
    
    private void Start()
    {
        rectMaskOriginalPadding = rectMask2D.padding;
    }

    private void TogglePos(string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    public void PopulateBuyItems(List<Clothes> clothes)
    {
        foreach(Clothes c in clothes){
            heads.Add(c.head);
            bodies.Add(c.body);
            legs.Add(c.legs);
        }
    }

    public void NextHead()
    {
        currentHead = (currentHead + 1) % heads.Count;
        UpdateHead();
    }

    public void PrevHead()
    {
        currentHead = (currentHead - 1) < 0? heads.Count - 1 : currentHead - 1;
        UpdateHead();
    }

    public void UpdateHead()
    {
        headSprite.sprite = heads[currentHead].headFront;
        headPrice.text = heads[currentHead].price.ToString();
    }

    public void NextBody()
    {
        currentBody = (currentBody + 1) % bodies.Count;
        UpdateBody();
    }

    public void PrevBody()
    {
        currentBody = (currentBody - 1) < 0? bodies.Count - 1 : currentBody - 1;
        UpdateBody();
    }

    public void UpdateBody()
    {
        bodySprite.sprite = bodies[currentBody].bodyFront;
        lArmSprite.sprite = bodies[currentBody].lArm;
        rArmSprite.sprite = bodies[currentBody].rArm;
        bodyPrice.text = bodies[currentBody].price.ToString();
    }

    public void NextLegs()
    {
        currentLegs = (currentLegs + 1) % legs.Count;
        UpdateLegs();
    }

    public void PrevLegs()
    {
        currentLegs = (currentLegs - 1) < 0? legs.Count - 1 : currentLegs - 1;
        UpdateLegs();
    }

    public void UpdateLegs()
    {
        lLegSprite.sprite = legs[currentLegs].lLeg;
        rLegSprite.sprite = legs[currentLegs].rLeg;
        legsPrice.text = legs[currentLegs].price.ToString();
    }

    public void Show()
    {
        TogglePos(ShowKey);
        rectMask2D.padding = Vector4.zero;
        currentHead = currentBody = currentLegs = 0;
    }

    public void Hide()
    {
        TogglePos(HideKey);
        rectMask2D.padding = rectMaskOriginalPadding;
    }
}
