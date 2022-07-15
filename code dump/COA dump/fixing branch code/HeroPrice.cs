using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum PriceModifier
{
    Low,
    Medium, 
    High,
    LowPremium,
    Premium,
    HighPremium
}
public enum AttributeClass
{
    Body,
    Mind,
    Social,
    BodyAndMind
}

public enum AttributeType
{
    Power,
    Finesse,
    Defence,
    NonDefence
}

public static class HeroPrice 
{

    private static float randomOffsetMin = 0.9f;
    private static float randomOffsetMax = 1.1f;
    public static int GetPrice(Hero hero)
    {
        int price = 0;


        float attributeValue = 0;
        List<AttributeClassification> attrClassList = CalcAttributeClass(hero);
        foreach(AttributeClassification a in attrClassList)
        {
            attributeValue += GetClassificationValue(a.skillClass) * AttributeValue(a.priceModifier);
        }

        int classPrice = GetTierIndex(hero.level.GetValue());
        int levelPrice = 100 + hero.level.GetValue() * 50;

        price = (int)(((((int)attributeValue + classPrice) * hero.level.GetValue()/2)+levelPrice)* UnityEngine.Random.Range(randomOffsetMin,randomOffsetMax));

        return price;
    }


    public static List<AttributeClassification> CalcAttributeClass(Hero hero)
    {
        List<AttributeClassification> classList = new List<AttributeClassification>();
        List<HeroClass> heroClassList = hero.GetHeroClasses();
        HeroClass finalClass = heroClassList[heroClassList.Count - 1];

        List<HeroAttribute> primaryAttributes = HeroGenerator.GetPrimaryStats(finalClass);

        var attrValues = Enum.GetValues(typeof(HeroAttribute));
        foreach (HeroAttribute a in attrValues)
        {
            if (a != HeroAttribute.None)
            {
                int ind = GetTierIndex(hero.level.GetValue());
                if (primaryAttributes.Contains(a))
                {
                    ind += 2;
                }
                else if (GetAttributes(AttributeClass.BodyAndMind, AttributeType.NonDefence).Contains(a)
                    || GetAttributes(AttributeClass.Social, AttributeType.Defence).Contains(a)
                    )
                {
                    ind++;
                }
                else if (GetAttributes(AttributeClass.BodyAndMind, AttributeType.Defence).Contains(a))
                {
                    ind += 2;

                }

                SkillClassification skillClass = HeroGenerator.ReturnSkillClassification(hero.GetAttribute(a).baseValue.GetValue());
                classList.Add(new AttributeClassification(a, skillClass, (PriceModifier)ind));
            }
        }

        return classList;
    }

    private static float AttributeValue(PriceModifier tier)
    {
        switch (tier)
        {
            case PriceModifier.Low:return 0.75f;
            case PriceModifier.Medium: return 1f;
            case PriceModifier.High: return 1.5f;
            case PriceModifier.LowPremium: return 2f;
            case PriceModifier.Premium: return 3f;
            case PriceModifier.HighPremium: return 4f;
            default: return 0;
        }
    }
    private static int GetClassificationValue(SkillClassification skillClass)
    {

        switch (skillClass)
        {
            case SkillClassification.Pathethic:
                return 5;
            case SkillClassification.Poor:
                return 10;
            case SkillClassification.Average:
                return 20;
            case SkillClassification.Decent:
                return 30;
            case SkillClassification.Good:
                return 45;
            case SkillClassification.Great:
                return 60;
            case SkillClassification.Heroic:
                return 80;
            default: return 0;
        }

    }
    private static int ClassPrice(int tier)
    {
        switch (tier) 
        {
            case 1: return 100;
            case 2:return 250;
            case 3:return 500;
            default:return 0;
        }
    }
    private static List<HeroAttribute> GetAttributesByType(AttributeType attrType)
    {
        List<HeroAttribute> allAttributes = new List<HeroAttribute>();
        if (attrType == AttributeType.Defence)
        {
            allAttributes.Add(HeroAttribute.Constitution);
            allAttributes.Add(HeroAttribute.Willpower);
            allAttributes.Add(HeroAttribute.Demeanor);
        }
        else if(attrType == AttributeType.Finesse)
        {
            allAttributes.Add(HeroAttribute.Dexterity);
            allAttributes.Add(HeroAttribute.Wisdom);
            allAttributes.Add(HeroAttribute.Communication);
        }
        else if (attrType == AttributeType.Power)
        {
            allAttributes.Add(HeroAttribute.Strength);
            allAttributes.Add(HeroAttribute.Intelligence);
            allAttributes.Add(HeroAttribute.Charisma);
        }
        else if (attrType == AttributeType.NonDefence)
        {
            allAttributes.Add(HeroAttribute.Dexterity);
            allAttributes.Add(HeroAttribute.Wisdom);
            allAttributes.Add(HeroAttribute.Communication);
            allAttributes.Add(HeroAttribute.Strength);
            allAttributes.Add(HeroAttribute.Intelligence);
            allAttributes.Add(HeroAttribute.Charisma);
        }
        return allAttributes;
    }
    private static List<HeroAttribute> GetAttributesByClass(AttributeClass attrClass)
    {
        List<HeroAttribute> allAttributes = new List<HeroAttribute>();
        if (attrClass == AttributeClass.Body)
        {
            allAttributes.Add(HeroAttribute.Strength);
            allAttributes.Add(HeroAttribute.Dexterity);
            allAttributes.Add(HeroAttribute.Constitution);
        }
        else if (attrClass == AttributeClass.Mind)
        {
            allAttributes.Add(HeroAttribute.Intelligence);
            allAttributes.Add(HeroAttribute.Wisdom);
            allAttributes.Add(HeroAttribute.Willpower);
        }
        else if (attrClass == AttributeClass.Social)
        {
            allAttributes.Add(HeroAttribute.Charisma);
            allAttributes.Add(HeroAttribute.Communication);
            allAttributes.Add(HeroAttribute.Demeanor);
        }
        else if (attrClass == AttributeClass.BodyAndMind)
        {
            allAttributes.Add(HeroAttribute.Strength);
            allAttributes.Add(HeroAttribute.Dexterity);
            allAttributes.Add(HeroAttribute.Constitution);
            allAttributes.Add(HeroAttribute.Intelligence);
            allAttributes.Add(HeroAttribute.Wisdom);
            allAttributes.Add(HeroAttribute.Willpower);
        }
        return allAttributes;
    }

    private static List<HeroAttribute> GetAttributes(AttributeClass attrClass, AttributeType attrType)
    {
        List<HeroAttribute> attrClassList = GetAttributesByClass(attrClass);
        List<HeroAttribute> attrTypeList = GetAttributesByType(attrType);

        List<HeroAttribute> attrList = new List<HeroAttribute>();
        foreach (HeroAttribute attr in attrClassList)
        {
            if (attrTypeList.Contains(attr))
            {
                attrList.Add(attr);
            }
        }
        return attrList;
    }



    private static int GetTierIndex(int level)
    {
        if (level > 12)
        {
            return 3;
        }
        else if (level > 6)
        {
            return 2;
        }
        else if (level > 2)
        {
            return 1;
        }
        else
        {
            return 0;
        }



    }

    public class AttributeClassification
    {
        public HeroAttribute attr;
        public SkillClassification skillClass;
        public PriceModifier priceModifier;

        public AttributeClassification(HeroAttribute attr, SkillClassification skillClass,PriceModifier priceModifier)
        {
            this.attr = attr;
            this.skillClass = skillClass;
            this.priceModifier = priceModifier;
        }
        public string Print()
        {
            string s = "";
            s += attr + " "+priceModifier+" " + skillClass;
            return s;
        }
    }
}
