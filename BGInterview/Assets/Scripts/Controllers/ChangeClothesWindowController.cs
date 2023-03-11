using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeClothesWindowController : MonoBehaviour
{
    const string HideKey = "Hide";
    const string ShowKey = "Show";
    [SerializeField] private Panel panel;
    [SerializeField] private Image headSprite;
    [SerializeField] private Image bodySprite;
    [SerializeField] private Image lArmSprite;
    [SerializeField] private Image rArmSprite;
    [SerializeField] private Image lLegSprite;
    [SerializeField] private Image rLegSprite;
    public List<Head> heads;
    public List<Body> bodies;
    public List<Legs> legs;
    public int currentHead, currentBody, currentLegs;

    private void TogglePos(string pos)
    {
        Tweener t = panel.SetPosition(pos, true);
        t.duration = 0.5f;
        t.equation = EasingEquations.EaseOutQuad;
    }

    public void PopulateChangeClothes()
    {
        heads = new List<Head>(Player.Instance.heads);
        bodies = new List<Body>(Player.Instance.bodies);
        legs = new List<Legs>(Player.Instance.legs);
        Debug.Log("Player outifits: " + heads.Count + " " + bodies.Count + " " + legs.Count);
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
    }

    public void Show()
    {
        TogglePos(ShowKey);
        currentHead = currentBody = currentLegs = 0;
        headSprite.sprite = Player.Instance.equippedClothes.head.headFront;
        bodySprite.sprite = Player.Instance.equippedClothes.body.bodyFront;
        lArmSprite.sprite = Player.Instance.equippedClothes.body.lArm;
        rArmSprite.sprite = Player.Instance.equippedClothes.body.rArm;
        lLegSprite.sprite = Player.Instance.equippedClothes.legs.lLeg;
        rLegSprite.sprite = Player.Instance.equippedClothes.legs.rLeg;
    }

    public void Hide()
    {
        TogglePos(HideKey);
    }
}
