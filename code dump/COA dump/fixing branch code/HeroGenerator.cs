using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum SkillClassification
{
    Pathethic,
    Poor,
    Average,
    Decent,
    Good,
    Great,
    Heroic
}

public enum HeroChance
{
    normal,
    primary,
    hector
}

public enum PrimarySkills
{
    none,

    strength,
    dexterity,
    intelligence,
    wisdom
}


public class HeroGenerator
{

    public static Dictionary<SkillClassification, float> startingChance = new Dictionary<SkillClassification, float>()
    {
        { SkillClassification.Pathethic,14},
        { SkillClassification.Poor,34},
        { SkillClassification.Average,34},
        { SkillClassification.Decent,8},
        { SkillClassification.Good,5},
        { SkillClassification.Great,3},
        { SkillClassification.Heroic,2}
    };
    public static Dictionary<SkillClassification, float> changeChance = new Dictionary<SkillClassification, float>()
    {
        { SkillClassification.Pathethic,-3},
        { SkillClassification.Poor,-3},
        { SkillClassification.Average,-2},
        { SkillClassification.Decent,3},
        { SkillClassification.Good,2},
        { SkillClassification.Great,2},
        { SkillClassification.Heroic,1}
    };

    public static Dictionary<SkillClassification, float> primaryStartingChance = new Dictionary<SkillClassification, float>()
    {
        { SkillClassification.Pathethic,0},
        { SkillClassification.Poor,20},
        { SkillClassification.Average,39},
        { SkillClassification.Decent,25},
        { SkillClassification.Good,8},
        { SkillClassification.Great,5},
        { SkillClassification.Heroic,3}
    };

    public static Dictionary<SkillClassification, float> hectorStartingChance = new Dictionary<SkillClassification, float>()
    {
        { SkillClassification.Pathethic,60},
        { SkillClassification.Poor,30},
        { SkillClassification.Average,7},
        { SkillClassification.Decent,1.8f},
        { SkillClassification.Good,0.9f},
        { SkillClassification.Great,0.21f},
        { SkillClassification.Heroic,0.09f}
    };


    public static Dictionary<SkillClassification, float> primaryChangeChance = new Dictionary<SkillClassification, float>()
    {
        { SkillClassification.Pathethic,0},
        { SkillClassification.Poor,-4},
        { SkillClassification.Average,-4},
        { SkillClassification.Decent,1},
        { SkillClassification.Good,3},
        { SkillClassification.Great,2},
        { SkillClassification.Heroic,2}
    };


    public static Dictionary<CharacterSkill, Skill> baseSkills = new Dictionary<CharacterSkill, Skill>()
    {
        { CharacterSkill.Alchemy, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Wisdom, heroSkill= CharacterSkill.Alchemy, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Arcane, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Willpower, heroSkill= CharacterSkill.Arcane, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Athletics, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Constitution, heroSkill= CharacterSkill.Athletics, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Axes, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Strength, heroSkill= CharacterSkill.Axes, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Beasts, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Wisdom, heroSkill= CharacterSkill.Beasts, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Beast_handling, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Charisma, heroSkill= CharacterSkill.Beast_handling, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Blades, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Dexterity, heroSkill= CharacterSkill.Blades, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Bluff, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Communication, heroSkill= CharacterSkill.Bluff, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Blunt, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Strength, heroSkill= CharacterSkill.Blunt, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Climbing, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Strength, heroSkill= CharacterSkill.Climbing, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Crafting, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Dexterity, heroSkill= CharacterSkill.Crafting, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Demonic, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Willpower, heroSkill= CharacterSkill.Demonic, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Desert, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Desert, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Diplomacy, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Communication, heroSkill= CharacterSkill.Diplomacy, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Disguise, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Charisma, heroSkill= CharacterSkill.Disguise, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Divine, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Willpower, heroSkill= CharacterSkill.Divine, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Elemental, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Willpower, heroSkill= CharacterSkill.Elemental, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Enchanting, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Wisdom, heroSkill= CharacterSkill.Enchanting, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Engineering, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Wisdom, heroSkill= CharacterSkill.Engineering, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Entertainment, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Charisma, heroSkill= CharacterSkill.Entertainment, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Environment, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Environment, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Forest, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Forest, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.History, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Wisdom, heroSkill= CharacterSkill.History, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Intimidation, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Demeanor, heroSkill= CharacterSkill.Intimidation, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Investigation, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Demeanor, heroSkill= CharacterSkill.Investigation, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Jumping, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Strength, heroSkill= CharacterSkill.Jumping, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Linguistics, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Communication, heroSkill= CharacterSkill.Linguistics, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Magic, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Willpower, heroSkill= CharacterSkill.Magic, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Mountain, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Mountain, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Perception, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Dexterity, heroSkill= CharacterSkill.Perception, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Polearms, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Strength, heroSkill= CharacterSkill.Polearms, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Ranged, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Dexterity, heroSkill= CharacterSkill.Ranged, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Religion, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Wisdom, heroSkill= CharacterSkill.Religion, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Running, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Constitution, heroSkill= CharacterSkill.Running, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Snow, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Snow, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Stealth, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Dexterity, heroSkill= CharacterSkill.Stealth, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Swamp, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Swamp, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Swimming, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Constitution, heroSkill= CharacterSkill.Swimming, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Tundra, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Tundra, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Underworld, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Underworld, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Urban, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Intelligence, heroSkill= CharacterSkill.Urban, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },
        { CharacterSkill.Weapon_mastery, new Skill(new SkillSaveData() { basedAttribute = HeroAttribute.Dexterity, heroSkill= CharacterSkill.Weapon_mastery, dice = new List<DiceSaveData>() { new DiceSaveData() { diceType = DiceType.d4 } } }) },

    };

    public static Dictionary<Gender, Dictionary<HeroRace, List<string>>> names = new Dictionary<Gender, Dictionary<HeroRace, List<string>>>()
    {
        {
            Gender.Female, new Dictionary<HeroRace, List<string>>()
            {
                { HeroRace.Altharkin, new List<string>() { "Khukloul Irzae", "Pibocu Ghabuth", "Rhaibzod Dhuldred", "Aceklu Oren", "Durne Thuseid", "Girokhi Phrasrubier", "Vagik Ezi", "Udilu Thuzi", "Brykro Chadubaith", "Dhupokso Cairlisai", "Corziss Pomishroh", "Nabubo Sheenvrid", "Thururth Phengires", "Dancyss Diezi", "Rhecme Krialveic", "Dhoulgos Kannis", "Chopissi Gheeborsieth", "Ghisupa Yazoshrat", "Imunnu Shogu", "Okhini Elnee", "Ghunver Bherle", "Itrern Enirvus", "Ahedhi Dhongish", "Ulopi Oserthur", "Fumruth Dolzut", "Dhuvon Shibaeldro", "Cenaru Cherthi", "Salnarn Cinret", "Indadu Gazulvos", "Rhulmern Khagroc" } },
                { HeroRace.Dwarf, new List<string>() { "Dudgraedrid Embermail", "Grourfatalyn Trollblade", "Dufihilda Flatheart", "Dorardrotaine Gravelborn", "Hakutelyn Duskbelly", "Sirmotelyn Mithrilmaul", "Baritgrubyrn Chaosrock", "Dwowaeline Bitterforge", "Dursodeth Jadebelt", "Thardearra Lavaview", "Narnugaer Marbleriver", "Grootgraemora Koboldriver", "Thignobo Rubystone", "Torerdraebelle Berylarmour", "Skorginelynn Boneback", "Kildrealsia Icestone", "Yarfoubera Mithriltoe", "Yaggeahilde Gravelhead", "Bromitrud Platebelt", "Umizeahilda Hillmaker", "Grakeatrude Draketoe", "Ummagith Noblehelm", "Kondotelin Orcfeet", "Khufeatrude Boulderarm", "Krabrubella Anvilspine", "Durizneatalin Orcfury", "Grarforra Iceforge", "Groofrabo Strongarm", "Elrdugit Bronzebraid", "Throsgraedrid Runebrow" } },
                { HeroRace.Ebolar, new List<string>() { "Reedan The Virtuous", "Imi The Kind", "Gada The Joyous", "Zula The Dreamy", "Allu The Lovable", "Rafa The Giving", "Theessine The Superior", "Phisada The Royal", "Tallnua The Venerated", "Thiwrii The Better", "Azih The Honored", "Siadah The Trustworthy", "Shassi The Magnificent", "Wizi The Loyal", "Meeshia The Fesity", "Zali The Precious", "Eeseenol The Generous", "Hudamo The Devoted", "Zussria The Trustworthy", "Irsuain The Accomplished", "Zaba The Humble", "Eedhu The Cruel", "Phayon The Kindhearted", "Jiaffu The Fantastic", "Ashe The Pure", "Thobin The Pleasing", "Salliza The Truthful", "Ghaffuwo The Precious", "Awruaah The Proud", "Iwdoan The Scented" } },
                { HeroRace.Elf, new List<string>() { "Cremia Beigwyn", "Malonne Zingella", "Chandrelle Perhice", "Gweyir Phizana", "Elora Ervaris", "Myantha Erphyra", "Tinesi Heigeiros", "Sarya Daemaris", "Rophalin Ravaynore", "Keerla Helekalyn", "Tyrael Zinven", "Itireae Beiwarin", "Aleratha Carcaryn", "Llorva Adjor", "Solana Tracyne", "Ialantha Reybanise", "Daethie Torhice", "Arthion Qinren", "Ecaeris Enquinal", "Phelorna Naekrana", "Naesala Keasatra", "Ioelena Reyphyra", "Maescia Keaxina", "Ava Loranorin", "Darunia Waesleth", "Ellarian Omavaris", "Delsanra Xilxina", "Aerith Maggolor", "Syvis Heleleth", "Soliana Heleven" } },
                { HeroRace.Human, new List<string>() { "Alayna Hartford", "Alda Fawcett", "Ilonka Camden", "Mara Shearman", "Clodia Royal", "Katriane Shelby", "Herma Colby", "Clare Gladstone", "Brittney Hamet", "Tereza Barclay", "Arlette Mendenhall", "Yaren Alby", "Inge Dudley", "Fleurette Gresham", "Annalise Royal", "Aleah Rudge", "Audey Hampton", "Alleffra Altham", "Pasclina Thorne", "Susie Hale", "Tianna Colton", "Jaliyah Crompton", "Wanja Hastings", "Tamara Marlowe", "Berniss Hayes", "Nadia Hayes", "Berneen Stanford", "Floretta Harrington", "Daralis Rutherford", "Lulu Eastaughffe" } },
                { HeroRace.Merfolk, new List<string>() { "Rainey", "Chenelle", "Rille", "Yaritza", "Glan", "Guinemere", "Kelby", "Murray", "Tishtar", "Guinevere", "Madison", "Tallulah", "Pearl", "Hali", "Laiken", "Madison", "Lamia", "Doria", "Raina", "Shizue", "Adra", "Cherith", "Alana", "Kendall", "Diana", "Dionna", "Brimlad", "Arva", "Marinelle", "Sirena" } },
                { HeroRace.Orc, new List<string>() { "Nargol", "Ugak", "Batul", "Gonk", "Gluronk", "Arob", "Gulfim", "Mog", "Urzoth", "Homraz", "Gharol", "Rolfish", "Grazob", "Murbol", "Burub", "Gul", "Oghash", "Shel", "Shufharz", "Urog", "Murob", "Rolfish", "Yazgash", "Garakh", "Rolfish", "Grazob", "Mazoga", "Shelur", "Atub", "Bum"  } },
            }
        },
        {
            Gender.Male, new Dictionary<HeroRace, List<string>>()
            {
                { HeroRace.Altharkin, new List<string>() { } },
                { HeroRace.Dwarf, new List<string>() { "Boddouc Bristledelver","Fotick Shadowshoulder","Bedgreg Opalfinger","Rurdraes Caskbrand","Toretgrorlig Metalheart","Oridgruth Beastbrow","Hadouth Flaskborn","Kaddouc Jadehelm","Thrakdrolin Flasksunder","Throvatin Boulderbuster","Khestog Boulderbrand","Barfunri Brownborn","Bhateas Orcfall","Brouvrulim Flaskrock","Thonmag Smeltarm","Bardrar Oakenpike","Finotum Runegrip","Groondred Koboldbeard","Whumnot Blacksword","Vokdread Graybuster","Duvil Strongshoulder","Nekgrarlun Merrydigger","Ravret Sapphiremace","Doradrumlir Hardarmour","Lozath Merryhead","Kaznerlum Axebelt","Dhustrur Battleforge","Herdric Bloodminer","Hossaeg Caveshield","Kiggeack Woldguard" } },
                { HeroRace.Ebolar, new List<string>() { "Hoba The Tremendous", "Donish The Glorious", "Dhibbon The Illustrious", "Shubam The Amazing", "Ghisi The Ancient", "Okhoo The Great", "Bhosfibee The Silent", "Yitissaa The Exalted", "Yazzenqesh The Devoted", "Gisinqoo The Trustworthy", "Jasmef The Fortunate", "Ebrod The Humble", "Yasme The Honest", "Ghobbal The Grand", "Yequa The Extravagant", "Jasaf The Treasured", "Zistashol The Treasured", "Banqobof The Tender", "Orussaal The Adventurous", "Razumol The Silent", "Eebri The Better", "Nuabbun The Stunning", "Shezem The Lucky", "Ebri The Friendly", "Guasoz The Intrepid", "Subrain The Victorious", "Obbarhu The Brilliant", "Gobadoz The Friendly", "Kaabeman The Gifted", "Zishuazzum The Tender" } },
                { HeroRace.Elf, new List<string>() { "Ailas Caisys", "Elred Ianyra", "Mirthal Phinorin", "Triandal Qinvaris", "Wyrran Elalen", "Sudryal Preshice", "Aired Uricaryn", "Edwyrd Glynzeiros", "Filverel Xyrdi", "Naeryndam Phixina", "Elre Trisydark", "Lianthorn Chaeric", "Rhistel Chaezorwyn", "Kieran Ulaberos", "Jannalor Torjor", "Tordynnar Krisqen", "Alinar Sarnelis", "Kivessin Zinxisys", "Nelaeryn Naefiel", "Ilbryen Vadove", "Gaeleath Yelydark", "Elauthin Xillana", "Elre Craxina", "Ayred Glynwynn", "Elen Hergolor", "Simimar Crafir", "Sontar Yesmenor", "Beluar Wysadithas", "Iyrandrar Raloqen", "Lafarallin Phirie" } },
                { HeroRace.Human, new List<string>() { "Urs Roscoe", "Bolton Blythe", "Douglas Thorne", "Fernand Duke", "Teddie Clapham", "Tasso Webb", "Jeroma Payton", "Carson Thornton", "Horst Tindall", "Fidelio Garside", "Godfrey Newbery", "Whitfield Hayes", "Moriz Goodwin", "Ranger Hammett", "Otger Clayden", "Gage Harrison", "Frederick Dudley", "Lyle Smythe", "Gilbert Swailes", "Gian Penney", "Reading Crawford", "Red Chatham", "Laurenz Nash", "Beno Breeden", "Dash Hale", "Josias Sweet", "Tony Trollope", "Hendrik Earle", "Royce Gale", "Mace Stanton" } },
                { HeroRace.Merfolk, new List<string>() { "Deniz", "Dorado", "Finn", "Rip", "Morven", "Irving", "Marious", "Marlow", "Bered", "Zander", "Strom", "Irving", "Como", "Dune", "Nerrocen", "Barracudon", "Marsh", "Kairius", "Tad", "Mortimer", "Nereus", "Aberforth", "Kaerius", "Peleg", "Morrissey", "Trent", "Tamesis", "Anenon", "Tridenton"  } },
                { HeroRace.Orc, new List<string>() { "Vukgilug", "Peghed", "Kahigig", "Umhra", "Eichelberbog", "Dushnamub", "Targigoth", "Xuk", "Bog", "Bazur", "Sguk", "Todagog", "Xurl", "Ohulhug", "Hig", "Farghed", "Kubub", "Guthakug", "Poogugh", "Togugh", "Raghat", "Opathu", "Rarfu", "Kerghug", "Xugor", "Vambag", "Kebub", "Onog", "Waruk", "Zaghig"  } },
            }
        }
    };
    public static HeroSaveData GenerateHeroSaveData(int heroLevel = 1)
    {
        if (heroLevel > 5) heroLevel = 5;
        var race = RandomRace();
        var gender = RandomGender(race);

        AllTiers heroTier = GetRandomTierList(heroLevel);
        List<HeroAttribute> primaryStats = GetPrimaryStats(GetCurrentClass(heroTier));

        SkillClassification skillClass;

        int currStrength;
        if (primaryStats.Contains(HeroAttribute.Strength))
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.primary);
            currStrength = RandomSkillValue(skillClass);
        }
        else
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.normal);
            currStrength = RandomSkillValue(skillClass);
        }

        int currDexterity;

        if (primaryStats.Contains(HeroAttribute.Dexterity))
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.primary);
            currDexterity = RandomSkillValue(skillClass);
        }
        else
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.normal);
            currDexterity = RandomSkillValue(skillClass);
        }

        int currIntelligence;
        if (primaryStats.Contains(HeroAttribute.Intelligence))
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.primary);
            currIntelligence = RandomSkillValue(skillClass);
        }
        else
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.normal);
            currIntelligence = RandomSkillValue(skillClass);
        }

        int currWisdom;
        if (primaryStats.Contains(HeroAttribute.Wisdom))
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.primary);
            currWisdom = RandomSkillValue(skillClass);
        }
        else
        {
            skillClass = ReturnClassification(heroLevel, HeroChance.normal);
            currWisdom = RandomSkillValue(skillClass);
        }

        skillClass = ReturnClassification(heroLevel, HeroChance.normal);
        int currConstitution = RandomSkillValue(skillClass);
        skillClass = ReturnClassification(heroLevel, HeroChance.normal);
        int currWillpower = RandomSkillValue(skillClass);
        skillClass = ReturnClassification(heroLevel, HeroChance.normal);
        int currCharisma = RandomSkillValue(skillClass);
        skillClass = ReturnClassification(heroLevel, HeroChance.normal);
        int currCommunication = RandomSkillValue(skillClass);
        skillClass = ReturnClassification(heroLevel, HeroChance.normal);
        int currDemeanor = RandomSkillValue(skillClass);
        HeroSaveData heroSaveData = new HeroSaveData
        {

            characterSaveData = new CharacterSaveData()
            {
                characterGuid = Guid.NewGuid().ToString(),
                portrait = RandomRaceGenderPortrait(race, gender),
                name = names[gender][race].RandomElement(),


                //SETING STATS FOR HERO

                strength = currStrength,
                dexterity = currDexterity,
                constitution = currConstitution,

                intelligence = currIntelligence,
                wisdom = currWisdom,
                willpower = currWillpower,

                charisma = currCharisma,
                communication = currCommunication,
                demeanor = currDemeanor,

                wounds = new List<WoundSaveData>(),

                skills = baseSkills.Values.Select(bs => bs.Save()).ToList(),

                traits = TraitInfo.raceTraits[race],

                armor = 0,
                evasion = 0,
                shield = 0,
                combatStrategy = StrategyType.Agressive,
                maxNumberOfWounds = 0,

            },
            level = heroLevel,
            experiance = 0,

            tier0 = heroTier.tier0,
            tier1 = heroTier.tier1,
            tier2 = heroTier.tier2,
            tier3 = heroTier.tier3,

            race = race,

            gender = gender,

            status = HeroStatus.Available,

            attributePoints = 0,
            equipedBelt = null,
            equipedBody = null,
            equipedBoots = null,
            equipedGloves = null,
            equipedHelmet = null,
            equipedShield = null,
            equipedTrinket1 = null,
            equipedTrinket2 = null,
            equipedTrinket3 = null,
            equipedWeapon = null,

            bodySkillPoints = 0,
            mindSkillPoints = 0,
            socialSkillPoints = 0,
            strengthSkillPoints = 0,
            dexteritySkillPoints = 0,
            constitutionSkillPoints = 0,
            intelligenceSkillPoints = 0,
            wisdomSkillPoints = 0,
            willpowerSkillPoints = 0,
            charismaSkillPoints = 0,
            communicationSkillPoints = 0,
            demeanorSkillPoints = 0,

        };

        heroSaveData.bodySkillPoints = Math.Max((heroSaveData.characterSaveData.strength + heroSaveData.characterSaveData.dexterity + heroSaveData.characterSaveData.constitution) - 30, 0);
        heroSaveData.mindSkillPoints = Math.Max((heroSaveData.characterSaveData.intelligence + heroSaveData.characterSaveData.wisdom + heroSaveData.characterSaveData.willpower) - 30, 0);
        heroSaveData.socialSkillPoints = Math.Max((heroSaveData.characterSaveData.charisma + heroSaveData.characterSaveData.communication + heroSaveData.characterSaveData.demeanor) - 30, 0);

        heroSaveData.strengthSkillPoints = heroSaveData.characterSaveData.strength;
        heroSaveData.dexteritySkillPoints = heroSaveData.characterSaveData.dexterity;
        heroSaveData.constitutionSkillPoints = heroSaveData.characterSaveData.constitution;

        heroSaveData.intelligenceSkillPoints = heroSaveData.characterSaveData.intelligence;
        heroSaveData.wisdomSkillPoints = heroSaveData.characterSaveData.wisdom;
        heroSaveData.willpowerSkillPoints = heroSaveData.characterSaveData.willpower;

        heroSaveData.charismaSkillPoints = heroSaveData.characterSaveData.charisma;
        heroSaveData.communicationSkillPoints = heroSaveData.characterSaveData.communication;
        heroSaveData.demeanorSkillPoints = heroSaveData.characterSaveData.demeanor;

        heroSaveData.characterSaveData.maxNumberOfWounds = heroSaveData.characterSaveData.constitution;

        return heroSaveData;
    }
    public static Hero GenerateHero(int heroLevel = 1)
    {
        Hero result = new Hero(GenerateHeroSaveData(heroLevel));

        return result;
    }

    private static HeroRace RandomRace()
    {
        List<HeroRace> availableRaces = new List<HeroRace>() { HeroRace.Altharkin, HeroRace.Dwarf, HeroRace.Ebolar, HeroRace.Elf, HeroRace.Human, HeroRace.Orc, }; // HeroRace.Merfolk, Merfolk removed because no resources

        return availableRaces.RandomElement();
    }

    private static Gender RandomGender(HeroRace heroRace)
    {
        if (heroRace == HeroRace.Altharkin)
        {
            return Gender.Female;
        }

        return (Gender)Random.RandomFromTo(0, 1);

    }

    private static string RandomRaceGenderPortrait(HeroRace heroRace, Gender gender)
    {
        string result = "Unknown";

        if (gender == Gender.Male)
        {

            switch (heroRace)
            {
                case HeroRace.Human:
                    result = SpriteResourceManager.spriteResourceManager.maleHumanHeroPortraits.RandomElement().name;
                    break;
                case HeroRace.Dwarf:
                    result = SpriteResourceManager.spriteResourceManager.maleDwarfHeroPortraits.RandomElement().name;
                    break;
                case HeroRace.Elf:
                    result = SpriteResourceManager.spriteResourceManager.maleElfHeroPortraits.RandomElement().name;
                    break;
                //case HeroRace.Altharkin:
                //    result = SpriteResourceManager.spriteResourceManager.maleAltharkinHeroPortraits.RandomElement().name;
                //    break;
                case HeroRace.Orc:
                    result = SpriteResourceManager.spriteResourceManager.maleOrcHeroPortraits.RandomElement().name;
                    break;
                //case HeroRace.Merfolk:
                //    result = SpriteResourceManager.spriteResourceManager.maleMerfolkHeroPortraits.RandomElement().name;
                //    break;
                case HeroRace.Ebolar:
                    result = SpriteResourceManager.spriteResourceManager.maleEbolarHeroPortraits.RandomElement().name;
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (heroRace)
            {
                case HeroRace.Human:
                    result = SpriteResourceManager.spriteResourceManager.femaleHumanHeroPortraits.RandomElement().name;
                    break;
                case HeroRace.Dwarf:
                    result = SpriteResourceManager.spriteResourceManager.femaleDwarfHeroPortraits.RandomElement().name;
                    break;
                case HeroRace.Elf:
                    result = SpriteResourceManager.spriteResourceManager.femaleElfHeroPortraits.RandomElement().name;
                    break;
                case HeroRace.Altharkin:
                    result = SpriteResourceManager.spriteResourceManager.femaleAltharkinHeroPortraits.RandomElement().name;
                    break;
                case HeroRace.Orc:
                    result = SpriteResourceManager.spriteResourceManager.femaleOrcHeroPortraits.RandomElement().name;
                    break;
                //case HeroRace.Merfolk:
                //    result = SpriteResourceManager.spriteResourceManager.femaleMerfolkHeroPortraits.RandomElement().name;
                //    break;
                case HeroRace.Ebolar:
                    result = SpriteResourceManager.spriteResourceManager.femaleEbolarHeroPortraits.RandomElement().name;
                    break;
                default:
                    break;
            }
        }


        return result;
    }


    #region hero class methods
    private static HeroClass GetRandomClass(HeroClass currentClass)
    {
        List<HeroClass> classList = GetAvailableClasses(currentClass);
        return classList[Random.RandomFromTo(0, classList.Count - 1)];
    }

    private static List<HeroClass> GetAvailableClasses(HeroClass currentClass)
    {
        List<HeroClass> classList = new List<HeroClass>();

        switch (currentClass)
        {
            case HeroClass.Adventurer:
                classList.Add(HeroClass.Fighter);
                classList.Add(HeroClass.Rogue);
                classList.Add(HeroClass.Scholar);
                classList.Add(HeroClass.Healer);
                break;

            case HeroClass.Fighter:
                classList.Add(HeroClass.WeaponMaster);
                classList.Add(HeroClass.Guardian);
                break;
            case HeroClass.Rogue:
                classList.Add(HeroClass.Assassin);
                classList.Add(HeroClass.Sniper);
                break;
            case HeroClass.Scholar:
                classList.Add(HeroClass.Summoner);
                classList.Add(HeroClass.Wizard);
                break;
            case HeroClass.Healer:
                classList.Add(HeroClass.Druid);
                classList.Add(HeroClass.Cleric);
                break;

            case HeroClass.WeaponMaster:
                classList.Add(HeroClass.Deathknight);
                classList.Add(HeroClass.UnlimitedBladeworks);
                classList.Add(HeroClass.Berserker);
                break;
            case HeroClass.Guardian:
                classList.Add(HeroClass.Artificer);
                classList.Add(HeroClass.Shaman);
                classList.Add(HeroClass.Paladin);
                break;
            case HeroClass.Assassin:
                classList.Add(HeroClass.Deathknight);
                classList.Add(HeroClass.Necromancer);
                classList.Add(HeroClass.PoisonMaster);
                break;
            case HeroClass.Sniper:
                classList.Add(HeroClass.Artificer);
                classList.Add(HeroClass.Spellslinger);
                classList.Add(HeroClass.Ranger);
                break;
            case HeroClass.Summoner:
                classList.Add(HeroClass.UnlimitedBladeworks);
                classList.Add(HeroClass.Necromancer);
                classList.Add(HeroClass.BeastMaster);
                break;
            case HeroClass.Wizard:
                classList.Add(HeroClass.Shaman);
                classList.Add(HeroClass.Spellslinger);
                classList.Add(HeroClass.Warlock);
                break;
            case HeroClass.Druid:
                classList.Add(HeroClass.Berserker);
                classList.Add(HeroClass.PoisonMaster);
                classList.Add(HeroClass.BeastMaster);
                break;
            case HeroClass.Cleric:
                classList.Add(HeroClass.Paladin);
                classList.Add(HeroClass.Ranger);
                classList.Add(HeroClass.Warlock);
                break;
        }

        return classList;
    }
    private static HeroClass GetCurrentClass(AllTiers tier)
    {
        if (tier.tier3 != HeroClass.None)
        {
            return tier.tier3;
        }
        else if (tier.tier2 != HeroClass.None)
        {
            return tier.tier2;
        }
        else if (tier.tier1 != HeroClass.None)
        {
            return tier.tier1;
        }
        else
        {
            return tier.tier0;
        }
    }

    public static List<HeroAttribute> GetPrimaryStats(HeroClass heroClass)
    {
        List<HeroAttribute> primaryStats = new List<HeroAttribute>();
        switch (heroClass)
        {
            case HeroClass.Fighter:
                primaryStats.Add(HeroAttribute.Strength);
                return primaryStats;
            case HeroClass.Rogue:
                primaryStats.Add(HeroAttribute.Dexterity);
                return primaryStats;
            case HeroClass.Scholar:
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.Healer:
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;

            case HeroClass.WeaponMaster:
                primaryStats.Add(HeroAttribute.Strength);
                return primaryStats;
            case HeroClass.Guardian:
                primaryStats.Add(HeroAttribute.Strength);
                return primaryStats;
            case HeroClass.Assassin:
                primaryStats.Add(HeroAttribute.Dexterity);
                return primaryStats;
            case HeroClass.Sniper:
                primaryStats.Add(HeroAttribute.Dexterity);
                return primaryStats;
            case HeroClass.Summoner:
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.Wizard:
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.Druid:
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;
            case HeroClass.Cleric:
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;

            case HeroClass.Deathknight:
                primaryStats.Add(HeroAttribute.Strength);
                primaryStats.Add(HeroAttribute.Dexterity);
                return primaryStats;
            case HeroClass.Artificer:
                primaryStats.Add(HeroAttribute.Strength);
                primaryStats.Add(HeroAttribute.Dexterity);
                return primaryStats;
            case HeroClass.UnlimitedBladeworks:
                primaryStats.Add(HeroAttribute.Strength);
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.Shaman:
                primaryStats.Add(HeroAttribute.Strength);
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.Berserker:
                primaryStats.Add(HeroAttribute.Strength);
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;
            case HeroClass.Paladin:
                primaryStats.Add(HeroAttribute.Strength);
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;
            case HeroClass.Necromancer:
                primaryStats.Add(HeroAttribute.Dexterity);
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.Spellslinger:
                primaryStats.Add(HeroAttribute.Dexterity);
                primaryStats.Add(HeroAttribute.Intelligence);
                return primaryStats;
            case HeroClass.PoisonMaster:
                primaryStats.Add(HeroAttribute.Dexterity);
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;
            case HeroClass.Ranger:
                primaryStats.Add(HeroAttribute.Dexterity);
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;
            case HeroClass.BeastMaster:
                primaryStats.Add(HeroAttribute.Intelligence);
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;
            case HeroClass.Warlock:
                primaryStats.Add(HeroAttribute.Intelligence);
                primaryStats.Add(HeroAttribute.Wisdom);
                return primaryStats;



            default:
                primaryStats.Add(HeroAttribute.None);
                return primaryStats;
        }
    }

    #endregion

    #region skill classification

    private static Range ReturnSkillRange(SkillClassification skill)
    {
        switch (skill)
        {
            case SkillClassification.Pathethic:
                return new Range(3, 7);
            case SkillClassification.Poor:
                return new Range(8, 11);
            case SkillClassification.Average:
                return new Range(12, 13);
            case SkillClassification.Decent:
                return new Range(14, 15);
            case SkillClassification.Good:
                return new Range(16, 17);
            case SkillClassification.Great:
                return new Range(18, 19);
            case SkillClassification.Heroic:
                return new Range(20, 20);
            default: return new Range(1, 7);
        }
    }
    public static SkillClassification ReturnSkillClassification(int value)
    {
        if (value >= 1 && value <= 7)
        {
            return SkillClassification.Pathethic;
        }
        else if (value >= 8 && value <= 11)
        {
            return SkillClassification.Poor;
        }
        else if (value >= 12 && value <= 13)
        {
            return SkillClassification.Average;
        }
        else if (value >= 14 && value <= 15)
        {
            return SkillClassification.Decent;
        }
        else if (value >= 16 && value <= 17)
        {
            return SkillClassification.Good;
        }
        else if (value >= 18 && value <= 19)
        {
            return SkillClassification.Great;
        }
        else if (value == 20)
        {
            return SkillClassification.Heroic;
        }
        else
        {
            return SkillClassification.Pathethic;
        }

    }
    private static int  RandomSkillValue(SkillClassification skill)
    {
        Range range = ReturnSkillRange(skill);
        return Random.RandomFromTo(range.start, range.end);
    }
    #endregion

    #region level tier

    private static AllTiers GetRandomTierList(int level)
    {
        AllTiers tier = new AllTiers();
        tier.tier0 = HeroClass.Adventurer;
        if (level >2)
        {
            tier.tier1 = GetRandomClass(HeroClass.Adventurer);
        }
        if(level >6)
        {
            tier.tier2= GetRandomClass(tier.tier1);
        }
        if(level >12)
        {
            tier.tier3 = GetRandomClass(tier.tier2);
        }
        return tier;
    }


    #endregion
    #region holder class
    public class Range
    {
        public int start;
        public int end;
        public Range(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public class AllTiers
    {
        public HeroClass tier0;
        public HeroClass tier1;
        public HeroClass tier2;
        public HeroClass tier3;

        public AllTiers()
        {
            tier0 = HeroClass.None;
            tier1 = HeroClass.None;
            tier2 = HeroClass.None;
            tier3 = HeroClass.None;
        }
        public AllTiers(HeroClass tier0 = HeroClass.None, HeroClass tier1 = HeroClass.None, HeroClass tier2 = HeroClass.None, HeroClass tier3 = HeroClass.None)
        {
            this.tier0 = tier0;
            this.tier1 = tier1;
            this.tier2 = tier2;
            this.tier3 = tier3;
        }

    }
    #endregion

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
    private static SkillClassification ReturnClassification(int heroLevel, HeroChance chance)
    {
        Dictionary<SkillClassification, float> realChance = new Dictionary<SkillClassification, float>();

        int heroTier = GetTierIndex(heroLevel);
        switch (chance) {
            case HeroChance.normal:
                foreach (KeyValuePair<SkillClassification, float> entry in startingChance)
                {
                    realChance.Add(entry.Key, entry.Value + heroTier * changeChance[entry.Key]);
                }
                break;
            case HeroChance.primary:
                foreach (KeyValuePair<SkillClassification, float> entry in primaryStartingChance)
                {
                    realChance.Add(entry.Key, entry.Value + heroTier * primaryChangeChance[entry.Key]);
                }
                break;
            case HeroChance.hector:
                foreach (KeyValuePair<SkillClassification, float> entry in hectorStartingChance)
                {
                    realChance.Add(entry.Key, entry.Value );
                }
                break;
            default:
                foreach (KeyValuePair<SkillClassification, float> entry in startingChance)
                {
                    realChance.Add(entry.Key, entry.Value + heroTier * changeChance[entry.Key]);
                }
                break;
        }
        float chanceValue = UnityEngine.Random.Range(0, realChance.Sum(x => x.Value));;
        float currentValue = 0;
        foreach(KeyValuePair<SkillClassification, float> entry in realChance)
        {

            currentValue += entry.Value;
            if (chanceValue < currentValue)
            {
                return entry.Key;
            }
        }

        return SkillClassification.Pathethic;

    }


}


