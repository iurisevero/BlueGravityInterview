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
    [SerializeField] private Button headBuyButton;
    [SerializeField] private Image headSprite;
    [SerializeField] private TextMeshProUGUI bodyPrice;
    [SerializeField] private Button bodyBuyButton;
    [SerializeField] private Image bodySprite;
    [SerializeField] private Image lArmSprite;
    [SerializeField] private Image rArmSprite;
    [SerializeField] private TextMeshProUGUI legsPrice;
    [SerializeField] private Button legsBuyButton;
    [SerializeField] private Image lLegSprite;
    [SerializeField] private Image rLegSprite;
    [SerializeField] private Clothes nakedClothes;

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
        heads = new List<Head>();
        bodies = new List<Body>();
        legs = new List<Legs>();
        foreach(Clothes c in clothes){
            heads.Add(c.head);
            bodies.Add(c.body);
            legs.Add(c.legs);
        }
        UpdateSprites();
    }

    public void NextHead()
    {
        if(heads.Count == 0) 
            return;

        currentHead = (currentHead + 1) % heads.Count;
        UpdateHead();
    }

    public void PrevHead()
    {
        if(heads.Count == 0) 
            return;

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
        if(bodies.Count == 0) 
            return;

        currentBody = (currentBody + 1) % bodies.Count;
        UpdateBody();
    }

    public void PrevBody()
    {
        if(bodies.Count == 0) 
            return;

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
        if(legs.Count == 0) 
            return;

        currentLegs = (currentLegs + 1) % legs.Count;
        UpdateLegs();
    }

    public void PrevLegs()
    {
        if(legs.Count == 0) 
            return;

        currentLegs = (currentLegs - 1) < 0? legs.Count - 1 : currentLegs - 1;
        UpdateLegs();
    }

    public void UpdateLegs()
    {
        lLegSprite.sprite = legs[currentLegs].lLeg;
        rLegSprite.sprite = legs[currentLegs].rLeg;
        legsPrice.text = legs[currentLegs].price.ToString();
    }

    public void UpdateSprites()
    {
        if(bodies.Count == 0){
            bodyBuyButton.interactable = false;
            bodySprite.sprite = nakedClothes.body.bodyFront;
            lArmSprite.sprite = nakedClothes.body.lArm;
            rArmSprite.sprite = nakedClothes.body.rArm;
            bodyPrice.text = "0";
        }else
            UpdateBody();
        
        if(heads.Count == 0){
            headBuyButton.interactable = false;
            headSprite.sprite = nakedClothes.head.headFront;
            headPrice.text = "0";
        } else
            UpdateHead();

        if(legs.Count == 0){
            legsBuyButton.interactable = false;
            lLegSprite.sprite = legs[currentLegs].lLeg;
            rLegSprite.sprite = legs[currentLegs].rLeg;
            legsPrice.text = "0";
        } else
            UpdateLegs();
    }

    public void Show()
    {
        TogglePos(ShowKey);
        rectMask2D.padding = Vector4.zero;
        currentHead = currentBody = currentLegs = 0;
        bodyBuyButton.interactable = true;
        headBuyButton.interactable = true;
        legsBuyButton.interactable = true;
    }

    public void Hide()
    {
        TogglePos(HideKey);
        rectMask2D.padding = rectMaskOriginalPadding;
    }
}
