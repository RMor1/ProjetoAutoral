﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemTimeline
    {
        Present, Future
    }
    public enum ItemType
    {
        Flashlight, Placeholder,
        KeyCabine1, KeyCabine2, Cloth, Plunger, KeyExit1, //itens do puzzle1
        KeyEscritCongela, KeyEscrit, Matches, ClothesHanger, Stilleto, KeyExit2 //itens do puzzle2

    }
    public ItemType itemType;
    public int amount;
    public bool active;
    public bool isAged;
    [System.NonSerialized] public ItemTimeline itemTimeline;

    [System.NonSerialized] public Item itemInFuture;
    [System.NonSerialized] public ItemWorld itemWorld;
    public bool isDestroyedOnUse()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flashlight:
            case ItemType.KeyCabine1:
            case ItemType.KeyCabine2:
            case ItemType.Cloth:
            case ItemType.Plunger:
            case ItemType.KeyExit1:
            case ItemType.ClothesHanger:
            case ItemType.KeyEscrit:
            case ItemType.KeyEscritCongela:
            case ItemType.Matches:
            case ItemType.Stilleto:
                return false;
                //return true;
        }
    }
    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flashlight:
            case ItemType.Cloth:
            case ItemType.KeyCabine1:
            case ItemType.KeyCabine2:
            case ItemType.ClothesHanger:
            case ItemType.KeyEscrit:
            case ItemType.KeyEscritCongela:
            case ItemType.Matches:
            case ItemType.Stilleto:
                return false;
            case ItemType.Placeholder:
                return true;
        }
    }
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Flashlight:
                if (isAged) return ItemAssets.Instance.flashlightFutureSprite;
                else return ItemAssets.Instance.flashlightPresentSprite;

            case ItemType.Placeholder: return ItemAssets.Instance.placeholderSprite;
            //puzzle1
            #region
            case ItemType.KeyCabine1:
                if (isAged) return ItemAssets.Instance.chaveCab1FutureSprite;
                else return ItemAssets.Instance.chaveCab1PresentSprite;
            case ItemType.KeyCabine2:
                if (isAged) return ItemAssets.Instance.chaveCab2FutureSprite;
                else return ItemAssets.Instance.chaveCab2PresentSprite;
            case ItemType.Cloth:
                if (isAged) return ItemAssets.Instance.panoFutureSprite;
                else return ItemAssets.Instance.panoPresentSprite;
            case ItemType.Plunger:
                if (isAged) return ItemAssets.Instance.desentupidorFutureSprite;
                else return ItemAssets.Instance.desentupidorPresentSprite;
            case ItemType.KeyExit1:
                if (isAged) return ItemAssets.Instance.chaveSaidaFutureSprite;
                else return ItemAssets.Instance.chaveSaidaPresentSprite;
            #endregion
            //puzzle2
            #region
            case ItemType.KeyEscrit:
                if (isAged) return ItemAssets.Instance.chaveEscritFutureSprite;
                else return ItemAssets.Instance.chaveEscritPresentSprite;
            case ItemType.KeyEscritCongela:
                if (isAged) return ItemAssets.Instance.chaveCongeladaPresentSprite;
                else return ItemAssets.Instance.chaveCongelaFutureSprite;
            case ItemType.Matches:
                if (isAged) return ItemAssets.Instance.fosforoFutureSprite;
                else return ItemAssets.Instance.fosforoPresentSprite;
            case ItemType.ClothesHanger:
                if (isAged) return ItemAssets.Instance.cabideFutureSprite;
                else return ItemAssets.Instance.cabidePresentSprite;
            case ItemType.Stilleto:
                if (isAged) return ItemAssets.Instance.estileteFutureSprite;
                else return ItemAssets.Instance.estiletePresentSprite;
            case ItemType.KeyExit2:
                if (isAged) return ItemAssets.Instance.chaveSaida2FutureSprite;
                else return ItemAssets.Instance.chaveSaida2PresentSprite;
             #endregion
            //puzzle3
        }
    }
}