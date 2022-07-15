using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HeroOffer
{

    public static List<HeroChance[]> heroChanceList = new List<HeroChance[]>()
    {
        new HeroChance[]
        {
            new HeroChance(1,0.67f),
            new HeroChance(2,0.22f),
            new HeroChance(3,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(1,0.34f),
            new HeroChance(2,0.33f),
            new HeroChance(3,0.22f),
            new HeroChance(4,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(1,0.11f),
            new HeroChance(2,0.22f),
            new HeroChance(3,0.33f),
            new HeroChance(4,0.22f),
            new HeroChance(5,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(2,0.11f),
            new HeroChance(3,0.22f),
            new HeroChance(4,0.33f),
            new HeroChance(5,0.33f),
        },
        //next level guild
        new HeroChance[]
        {
            new HeroChance(4,0.34f),
            new HeroChance(5,0.33f),
            new HeroChance(6,0.22f),
            new HeroChance(7,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(4,0.11f),
            new HeroChance(5,0.22f),
            new HeroChance(6,0.33f),
            new HeroChance(7,0.22f),
            new HeroChance(8,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(5,0.11f),
            new HeroChance(6,0.22f),
            new HeroChance(7,0.33f),
            new HeroChance(8,0.22f),
            new HeroChance(9,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(6,0.11f),
            new HeroChance(7,0.22f),
            new HeroChance(8,0.33f),
            new HeroChance(9,0.33f),
        },

        //next level guild
        new HeroChance[]
        {
            new HeroChance(8,0.34f),
            new HeroChance(9,0.33f),
            new HeroChance(10,0.22f),
            new HeroChance(11,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(8,0.11f),
            new HeroChance(9,0.22f),
            new HeroChance(10,0.33f),
            new HeroChance(11,0.22f),
            new HeroChance(12,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(9,0.11f),
            new HeroChance(10,0.22f),
            new HeroChance(11,0.33f),
            new HeroChance(12,0.22f),
            new HeroChance(13,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(10,0.11f),
            new HeroChance(11,0.22f),
            new HeroChance(12,0.33f),
            new HeroChance(13,0.33f),
        },
        //next level guild
        new HeroChance[]
        {
            new HeroChance(12,0.34f),
            new HeroChance(13,0.33f),
            new HeroChance(14,0.22f),
            new HeroChance(15,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(12,0.11f),
            new HeroChance(13,0.22f),
            new HeroChance(14,0.33f),
            new HeroChance(15,0.22f),
            new HeroChance(16,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(13,0.11f),
            new HeroChance(14,0.22f),
            new HeroChance(15,0.33f),
            new HeroChance(16,0.22f),
            new HeroChance(17,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(14,0.11f),
            new HeroChance(15,0.22f),
            new HeroChance(16,0.33f),
            new HeroChance(17,0.33f),
        },
        //next level guild
        new HeroChance[]
        {
            new HeroChance(16,0.34f),
            new HeroChance(17,0.33f),
            new HeroChance(18,0.22f),
            new HeroChance(19,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(16,0.11f),
            new HeroChance(17,0.22f),
            new HeroChance(18,0.33f),
            new HeroChance(19,0.22f),
            new HeroChance(20,0.11f),
        },
        new HeroChance[]
        {
            new HeroChance(17,0.11f),
            new HeroChance(18,0.22f),
            new HeroChance(19,0.33f),
            new HeroChance(20,0.33f),

        },
        new HeroChance[]
        {
            new HeroChance(18,0.11f),
            new HeroChance(19,0.22f),
            new HeroChance(20,0.66f),

        },
    };


    private static int GetGuildExpInd()
    {
        float progress = (float)GameLogic.gameLogic.guild.guildExperiance.GetValue() / (float)GameLogic.gameLogic.guild.expForLevel.GetValue();


        if (progress <= 0.25f)
        {
            return 0;
        }
        else if (progress <= 0.5f)
        {
            return 1;
        }
        else if (progress <= 0.75f)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    private static int GetOfferIndex()
    {
       int offerIndex =( GameLogic.gameLogic.guild.guildLevel.GetValue()-1)*4+GetGuildExpInd();

        return offerIndex;
    }

    public static int GetRandomOffer()
    {
        int offer=0;
        int offerIndex = GetOfferIndex();

        float chanceValue = UnityEngine.Random.Range(0f, heroChanceList[offerIndex].Sum(x => x.chance));
        float currentValue = 0;
        foreach (HeroChance entry in heroChanceList[offerIndex])
        {
            currentValue += entry.chance;
            if (chanceValue < currentValue)
            {
                return entry.level;
            }
        }

        return offer;
    }
    public class HeroChance
    {
        public int level;
        public float chance;
        public HeroChance(int level, float chance)
        {
            this.level = level;
            this.chance = chance;
        }
    }
}
