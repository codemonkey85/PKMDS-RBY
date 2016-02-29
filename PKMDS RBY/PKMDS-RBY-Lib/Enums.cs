using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PKMDS_RBY_Lib
{
    public static class Lists
    {
        private static List<MovesObject> _moveList = new List<MovesObject>();
        private static List<SpeciesObject> _speciesList = new List<SpeciesObject>();
        private static List<ItemObject> _itemList = new List<ItemObject>();
        private static List<LocationObject> _locationList = new List<LocationObject>();

        public static List<MovesObject> MoveList
        {
            get
            {
                if (_moveList.Any()) return _moveList;
                foreach (var move in Enum.GetValues(typeof(Moves)).Cast<Moves>().ToArray())
                {
                    _moveList.Add(new MovesObject(move));
                }
                return _moveList;
            }
        }

        public static List<SpeciesObject> SpeciesList
        {
            get
            {
                if (_speciesList.Any()) return _speciesList;
                foreach (var species in Enum.GetValues(typeof(Species)).Cast<Species>().Where(s => s != Species.NoSpecies).ToArray())
                {
                    _speciesList.Add(new SpeciesObject(species));
                }
                return _speciesList;
            }
        }

        public static List<ItemObject> ItemList
        {
            get
            {
                if (_itemList.Any()) return _itemList;
                foreach (var item in Enum.GetValues(typeof(Items)).Cast<Items>().ToArray())
                {
                    _itemList.Add(new ItemObject(item));
                }
                return _itemList;
            }
        }

        public static List<LocationObject> LocationList
        {
            get
            {
                if (_locationList.Any()) return _locationList;
                foreach (var location in Enum.GetValues(typeof(Locations)).Cast<Locations>().ToArray())
                {
                    _locationList.Add(new LocationObject(location));
                }
                return _locationList;
            }
        }
    }

    public static class Extensions
    {
        internal static List<ushort> BallsToItems = new List<ushort>
        {
            0,
            //1,
            //2,
            //3,
            //4,
            //5,
            //6,
            //7,
            //8,
            //9,
            //10,
            //11,
            //12,
            //13,
            //14,
            //15,
            //16,
            //492,
            //493,
            //494,
            //495,
            //496,
            //497,
            //498,
            //499,
            //576
        };

        /// <summary>
        ///     Return the DescriptionAttribute of the given Enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String</returns>
        public static string EnumToString(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            if (name == null) return null;
            var field = type.GetField(name);
            if (field == null) return null;
            var attr =
                Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attr != null ? attr.Description : null;
        }

        public static Items BallToItem(byte ball)
        {
            if (ball >= BallsToItems.Count)
                return Items.NoItem;
            return (Items)BallsToItems[ball];
        }

        public static byte ItemToBall(Items item)
        {
            if (!BallsToItems.Contains((ushort)item))
                return 0;
            return (byte)(BallsToItems.IndexOf((ushort)item));
        }
    }

    public enum Species : ushort
    {
        [Description("No Species")]
        NoSpecies = 0,

        [Description("Bulbasaur")]
        Bulbasaur = 1,

        [Description("Ivysaur")]
        Ivysaur = 2,

        [Description("Venusaur")]
        Venusaur = 3,

        [Description("Charmander")]
        Charmander = 4,

        [Description("Charmeleon")]
        Charmeleon = 5,

        [Description("Charizard")]
        Charizard = 6,

        [Description("Squirtle")]
        Squirtle = 7,

        [Description("Wartortle")]
        Wartortle = 8,

        [Description("Blastoise")]
        Blastoise = 9,

        [Description("Caterpie")]
        Caterpie = 10,

        [Description("Metapod")]
        Metapod = 11,

        [Description("Butterfree")]
        Butterfree = 12,

        [Description("Weedle")]
        Weedle = 13,

        [Description("Kakuna")]
        Kakuna = 14,

        [Description("Beedrill")]
        Beedrill = 15,

        [Description("Pidgey")]
        Pidgey = 16,

        [Description("Pidgeotto")]
        Pidgeotto = 17,

        [Description("Pidgeot")]
        Pidgeot = 18,

        [Description("Rattata")]
        Rattata = 19,

        [Description("Raticate")]
        Raticate = 20,

        [Description("Spearow")]
        Spearow = 21,

        [Description("Fearow")]
        Fearow = 22,

        [Description("Ekans")]
        Ekans = 23,

        [Description("Arbok")]
        Arbok = 24,

        [Description("Pikachu")]
        Pikachu = 25,

        [Description("Raichu")]
        Raichu = 26,

        [Description("Sandshrew")]
        Sandshrew = 27,

        [Description("Sandslash")]
        Sandslash = 28,

        [Description("Nidoran♀")]
        Nidoran_F = 29,

        [Description("Nidorina")]
        Nidorina = 30,

        [Description("Nidoqueen")]
        Nidoqueen = 31,

        [Description("Nidoran♂")]
        Nidoran_M = 32,

        [Description("Nidorino")]
        Nidorino = 33,

        [Description("Nidoking")]
        Nidoking = 34,

        [Description("Clefairy")]
        Clefairy = 35,

        [Description("Clefable")]
        Clefable = 36,

        [Description("Vulpix")]
        Vulpix = 37,

        [Description("Ninetales")]
        Ninetales = 38,

        [Description("Jigglypuff")]
        Jigglypuff = 39,

        [Description("Wigglytuff")]
        Wigglytuff = 40,

        [Description("Zubat")]
        Zubat = 41,

        [Description("Golbat")]
        Golbat = 42,

        [Description("Oddish")]
        Oddish = 43,

        [Description("Gloom")]
        Gloom = 44,

        [Description("Vileplume")]
        Vileplume = 45,

        [Description("Paras")]
        Paras = 46,

        [Description("Parasect")]
        Parasect = 47,

        [Description("Venonat")]
        Venonat = 48,

        [Description("Venomoth")]
        Venomoth = 49,

        [Description("Diglett")]
        Diglett = 50,

        [Description("Dugtrio")]
        Dugtrio = 51,

        [Description("Meowth")]
        Meowth = 52,

        [Description("Persian")]
        Persian = 53,

        [Description("Psyduck")]
        Psyduck = 54,

        [Description("Golduck")]
        Golduck = 55,

        [Description("Mankey")]
        Mankey = 56,

        [Description("Primeape")]
        Primeape = 57,

        [Description("Growlithe")]
        Growlithe = 58,

        [Description("Arcanine")]
        Arcanine = 59,

        [Description("Poliwag")]
        Poliwag = 60,

        [Description("Poliwhirl")]
        Poliwhirl = 61,

        [Description("Poliwrath")]
        Poliwrath = 62,

        [Description("Abra")]
        Abra = 63,

        [Description("Kadabra")]
        Kadabra = 64,

        [Description("Alakazam")]
        Alakazam = 65,

        [Description("Machop")]
        Machop = 66,

        [Description("Machoke")]
        Machoke = 67,

        [Description("Machamp")]
        Machamp = 68,

        [Description("Bellsprout")]
        Bellsprout = 69,

        [Description("Weepinbell")]
        Weepinbell = 70,

        [Description("Victreebel")]
        Victreebel = 71,

        [Description("Tentacool")]
        Tentacool = 72,

        [Description("Tentacruel")]
        Tentacruel = 73,

        [Description("Geodude")]
        Geodude = 74,

        [Description("Graveler")]
        Graveler = 75,

        [Description("Golem")]
        Golem = 76,

        [Description("Ponyta")]
        Ponyta = 77,

        [Description("Rapidash")]
        Rapidash = 78,

        [Description("Slowpoke")]
        Slowpoke = 79,

        [Description("Slowbro")]
        Slowbro = 80,

        [Description("Magnemite")]
        Magnemite = 81,

        [Description("Magneton")]
        Magneton = 82,

        [Description("Farfetch'd")]
        Farfetchd = 83,

        [Description("Doduo")]
        Doduo = 84,

        [Description("Dodrio")]
        Dodrio = 85,

        [Description("Seel")]
        Seel = 86,

        [Description("Dewgong")]
        Dewgong = 87,

        [Description("Grimer")]
        Grimer = 88,

        [Description("Muk")]
        Muk = 89,

        [Description("Shellder")]
        Shellder = 90,

        [Description("Cloyster")]
        Cloyster = 91,

        [Description("Gastly")]
        Gastly = 92,

        [Description("Haunter")]
        Haunter = 93,

        [Description("Gengar")]
        Gengar = 94,

        [Description("Onix")]
        Onix = 95,

        [Description("Drowzee")]
        Drowzee = 96,

        [Description("Hypno")]
        Hypno = 97,

        [Description("Krabby")]
        Krabby = 98,

        [Description("Kingler")]
        Kingler = 99,

        [Description("Voltorb")]
        Voltorb = 100,

        [Description("Electrode")]
        Electrode = 101,

        [Description("Exeggcute")]
        Exeggcute = 102,

        [Description("Exeggutor")]
        Exeggutor = 103,

        [Description("Cubone")]
        Cubone = 104,

        [Description("Marowak")]
        Marowak = 105,

        [Description("Hitmonlee")]
        Hitmonlee = 106,

        [Description("Hitmonchan")]
        Hitmonchan = 107,

        [Description("Lickitung")]
        Lickitung = 108,

        [Description("Koffing")]
        Koffing = 109,

        [Description("Weezing")]
        Weezing = 110,

        [Description("Rhyhorn")]
        Rhyhorn = 111,

        [Description("Rhydon")]
        Rhydon = 112,

        [Description("Chansey")]
        Chansey = 113,

        [Description("Tangela")]
        Tangela = 114,

        [Description("Kangaskhan")]
        Kangaskhan = 115,

        [Description("Horsea")]
        Horsea = 116,

        [Description("Seadra")]
        Seadra = 117,

        [Description("Goldeen")]
        Goldeen = 118,

        [Description("Seaking")]
        Seaking = 119,

        [Description("Staryu")]
        Staryu = 120,

        [Description("Starmie")]
        Starmie = 121,

        [Description("Mr. Mime")]
        Mr_Mime = 122,

        [Description("Scyther")]
        Scyther = 123,

        [Description("Jynx")]
        Jynx = 124,

        [Description("Electabuzz")]
        Electabuzz = 125,

        [Description("Magmar")]
        Magmar = 126,

        [Description("Pinsir")]
        Pinsir = 127,

        [Description("Tauros")]
        Tauros = 128,

        [Description("Magikarp")]
        Magikarp = 129,

        [Description("Gyarados")]
        Gyarados = 130,

        [Description("Lapras")]
        Lapras = 131,

        [Description("Ditto")]
        Ditto = 132,

        [Description("Eevee")]
        Eevee = 133,

        [Description("Vaporeon")]
        Vaporeon = 134,

        [Description("Jolteon")]
        Jolteon = 135,

        [Description("Flareon")]
        Flareon = 136,

        [Description("Porygon")]
        Porygon = 137,

        [Description("Omanyte")]
        Omanyte = 138,

        [Description("Omastar")]
        Omastar = 139,

        [Description("Kabuto")]
        Kabuto = 140,

        [Description("Kabutops")]
        Kabutops = 141,

        [Description("Aerodactyl")]
        Aerodactyl = 142,

        [Description("Snorlax")]
        Snorlax = 143,

        [Description("Articuno")]
        Articuno = 144,

        [Description("Zapdos")]
        Zapdos = 145,

        [Description("Moltres")]
        Moltres = 146,

        [Description("Dratini")]
        Dratini = 147,

        [Description("Dragonair")]
        Dragonair = 148,

        [Description("Dragonite")]
        Dragonite = 149,

        [Description("Mewtwo")]
        Mewtwo = 150,

        [Description("Mew")]
        Mew = 151
    }

    public enum Moves : ushort
    {
        [Description("No Move")]
        NoMove = 0,

        [Description("Pound")]
        Pound = 1,

        [Description("Karate Chop")]
        Karate_Chop = 2,

        [Description("Double Slap")]
        Double_Slap = 3,

        [Description("Comet Punch")]
        Comet_Punch = 4,

        [Description("Mega Punch")]
        Mega_Punch = 5,

        [Description("Pay Day")]
        Pay_Day = 6,

        [Description("Fire Punch")]
        Fire_Punch = 7,

        [Description("Ice Punch")]
        Ice_Punch = 8,

        [Description("Thunder Punch")]
        Thunder_Punch = 9,

        [Description("Scratch")]
        Scratch = 10,

        [Description("Vice Grip")]
        Vice_Grip = 11,

        [Description("Guillotine")]
        Guillotine = 12,

        [Description("Razor Wind")]
        Razor_Wind = 13,

        [Description("Swords Dance")]
        Swords_Dance = 14,

        [Description("Cut")]
        Cut = 15,

        [Description("Gust")]
        Gust = 16,

        [Description("Wing Attack")]
        Wing_Attack = 17,

        [Description("Whirlwind")]
        Whirlwind = 18,

        [Description("Fly")]
        Fly = 19,

        [Description("Bind")]
        Bind = 20,

        [Description("Slam")]
        Slam = 21,

        [Description("Vine Whip")]
        Vine_Whip = 22,

        [Description("Stomp")]
        Stomp = 23,

        [Description("Double Kick")]
        Double_Kick = 24,

        [Description("Mega Kick")]
        Mega_Kick = 25,

        [Description("Jump Kick")]
        Jump_Kick = 26,

        [Description("Rolling Kick")]
        Rolling_Kick = 27,

        [Description("Sand Attack")]
        Sand_Attack = 28,

        [Description("Headbutt")]
        Headbutt = 29,

        [Description("Horn Attack")]
        Horn_Attack = 30,

        [Description("Fury Attack")]
        Fury_Attack = 31,

        [Description("Horn Drill")]
        Horn_Drill = 32,

        [Description("Tackle")]
        Tackle = 33,

        [Description("Body Slam")]
        Body_Slam = 34,

        [Description("Wrap")]
        Wrap = 35,

        [Description("Take Down")]
        Take_Down = 36,

        [Description("Thrash")]
        Thrash = 37,

        [Description("Double-Edge")]
        Double_Edge = 38,

        [Description("Tail Whip")]
        Tail_Whip = 39,

        [Description("Poison Sting")]
        Poison_Sting = 40,

        [Description("Twineedle")]
        Twineedle = 41,

        [Description("Pin Missile")]
        Pin_Missile = 42,

        [Description("Leer")]
        Leer = 43,

        [Description("Bite")]
        Bite = 44,

        [Description("Growl")]
        Growl = 45,

        [Description("Roar")]
        Roar = 46,

        [Description("Sing")]
        Sing = 47,

        [Description("Supersonic")]
        Supersonic = 48,

        [Description("Sonic Boom")]
        Sonic_Boom = 49,

        [Description("Disable")]
        Disable = 50,

        [Description("Acid")]
        Acid = 51,

        [Description("Ember")]
        Ember = 52,

        [Description("Flamethrower")]
        Flamethrower = 53,

        [Description("Mist")]
        Mist = 54,

        [Description("Water Gun")]
        Water_Gun = 55,

        [Description("Hydro Pump")]
        Hydro_Pump = 56,

        [Description("Surf")]
        Surf = 57,

        [Description("Ice Beam")]
        Ice_Beam = 58,

        [Description("Blizzard")]
        Blizzard = 59,

        [Description("Psybeam")]
        Psybeam = 60,

        [Description("Bubble Beam")]
        Bubble_Beam = 61,

        [Description("Aurora Beam")]
        Aurora_Beam = 62,

        [Description("Hyper Beam")]
        Hyper_Beam = 63,

        [Description("Peck")]
        Peck = 64,

        [Description("Drill Peck")]
        Drill_Peck = 65,

        [Description("Submission")]
        Submission = 66,

        [Description("Low Kick")]
        Low_Kick = 67,

        [Description("Counter")]
        Counter = 68,

        [Description("Seismic Toss")]
        Seismic_Toss = 69,

        [Description("Strength")]
        Strength = 70,

        [Description("Absorb")]
        Absorb = 71,

        [Description("Mega Drain")]
        Mega_Drain = 72,

        [Description("Leech Seed")]
        Leech_Seed = 73,

        [Description("Growth")]
        Growth = 74,

        [Description("Razor Leaf")]
        Razor_Leaf = 75,

        [Description("Solar Beam")]
        Solar_Beam = 76,

        [Description("Poison Powder")]
        Poison_Powder = 77,

        [Description("Stun Spore")]
        Stun_Spore = 78,

        [Description("Sleep Powder")]
        Sleep_Powder = 79,

        [Description("Petal Dance")]
        Petal_Dance = 80,

        [Description("String Shot")]
        String_Shot = 81,

        [Description("Dragon Rage")]
        Dragon_Rage = 82,

        [Description("Fire Spin")]
        Fire_Spin = 83,

        [Description("Thunder Shock")]
        Thunder_Shock = 84,

        [Description("Thunderbolt")]
        Thunderbolt = 85,

        [Description("Thunder Wave")]
        Thunder_Wave = 86,

        [Description("Thunder")]
        Thunder = 87,

        [Description("Rock Throw")]
        Rock_Throw = 88,

        [Description("Earthquake")]
        Earthquake = 89,

        [Description("Fissure")]
        Fissure = 90,

        [Description("Dig")]
        Dig = 91,

        [Description("Toxic")]
        Toxic = 92,

        [Description("Confusion")]
        Confusion = 93,

        [Description("Psychic")]
        Psychic = 94,

        [Description("Hypnosis")]
        Hypnosis = 95,

        [Description("Meditate")]
        Meditate = 96,

        [Description("Agility")]
        Agility = 97,

        [Description("Quick Attack")]
        Quick_Attack = 98,

        [Description("Rage")]
        Rage = 99,

        [Description("Teleport")]
        Teleport = 100,

        [Description("Night Shade")]
        Night_Shade = 101,

        [Description("Mimic")]
        Mimic = 102,

        [Description("Screech")]
        Screech = 103,

        [Description("Double Team")]
        Double_Team = 104,

        [Description("Recover")]
        Recover = 105,

        [Description("Harden")]
        Harden = 106,

        [Description("Minimize")]
        Minimize = 107,

        [Description("Smokescreen")]
        Smokescreen = 108,

        [Description("Confuse Ray")]
        Confuse_Ray = 109,

        [Description("Withdraw")]
        Withdraw = 110,

        [Description("Defense Curl")]
        Defense_Curl = 111,

        [Description("Barrier")]
        Barrier = 112,

        [Description("Light Screen")]
        Light_Screen = 113,

        [Description("Haze")]
        Haze = 114,

        [Description("Reflect")]
        Reflect = 115,

        [Description("Focus Energy")]
        Focus_Energy = 116,

        [Description("Bide")]
        Bide = 117,

        [Description("Metronome")]
        Metronome = 118,

        [Description("Mirror Move")]
        Mirror_Move = 119,

        [Description("Self-Destruct")]
        Self_Destruct = 120,

        [Description("Egg Bomb")]
        Egg_Bomb = 121,

        [Description("Lick")]
        Lick = 122,

        [Description("Smog")]
        Smog = 123,

        [Description("Sludge")]
        Sludge = 124,

        [Description("Bone Club")]
        Bone_Club = 125,

        [Description("Fire Blast")]
        Fire_Blast = 126,

        [Description("Waterfall")]
        Waterfall = 127,

        [Description("Clamp")]
        Clamp = 128,

        [Description("Swift")]
        Swift = 129,

        [Description("Skull Bash")]
        Skull_Bash = 130,

        [Description("Spike Cannon")]
        Spike_Cannon = 131,

        [Description("Constrict")]
        Constrict = 132,

        [Description("Amnesia")]
        Amnesia = 133,

        [Description("Kinesis")]
        Kinesis = 134,

        [Description("Soft-Boiled")]
        Soft_Boiled = 135,

        [Description("High Jump Kick")]
        High_Jump_Kick = 136,

        [Description("Glare")]
        Glare = 137,

        [Description("Dream Eater")]
        Dream_Eater = 138,

        [Description("Poison Gas")]
        Poison_Gas = 139,

        [Description("Barrage")]
        Barrage = 140,

        [Description("Leech Life")]
        Leech_Life = 141,

        [Description("Lovely Kiss")]
        Lovely_Kiss = 142,

        [Description("Sky Attack")]
        Sky_Attack = 143,

        [Description("Transform")]
        Transform = 144,

        [Description("Bubble")]
        Bubble = 145,

        [Description("Dizzy Punch")]
        Dizzy_Punch = 146,

        [Description("Spore")]
        Spore = 147,

        [Description("Flash")]
        Flash = 148,

        [Description("Psywave")]
        Psywave = 149,

        [Description("Splash")]
        Splash = 150,

        [Description("Acid Armor")]
        Acid_Armor = 151,

        [Description("Crabhammer")]
        Crabhammer = 152,

        [Description("Explosion")]
        Explosion = 153,

        [Description("Fury Swipes")]
        Fury_Swipes = 154,

        [Description("Bonemerang")]
        Bonemerang = 155,

        [Description("Rest")]
        Rest = 156,

        [Description("Rock Slide")]
        Rock_Slide = 157,

        [Description("Hyper Fang")]
        Hyper_Fang = 158,

        [Description("Sharpen")]
        Sharpen = 159,

        [Description("Conversion")]
        Conversion = 160,

        [Description("Tri Attack")]
        Tri_Attack = 161,

        [Description("Super Fang")]
        Super_Fang = 162,

        [Description("Slash")]
        Slash = 163,

        [Description("Substitute")]
        Substitute = 164,

        [Description("Struggle")]
        Struggle = 165
    }

    public enum Items : ushort
    {
        [Description("No Item")]
        NoItem = 0x0000,
    }

    public enum Locations : ushort
    {
        [Description("Mystery Zone")]
        Mystery_Zone = 0,
    }

    public enum Stats
    {
        HP,
        Attack,
        Defense,
        Speed,
        Special
    }

    public enum Types
    {
        [Description("Normal")]
        Normal,

        [Description("Fighting")]
        Fighting,

        [Description("Flying")]
        Flying,

        [Description("Poison")]
        Poison,

        [Description("Ground")]
        Ground,

        [Description("Rock")]
        Rock,

        [Description("Bug")]
        Bug,

        [Description("Ghost")]
        Ghost,

        [Description("Fire")]
        Fire,

        [Description("Water")]
        Water,

        [Description("Grass")]
        Grass,

        [Description("Electric")]
        Electric,

        [Description("Psychic")]
        Psychic,

        [Description("Ice")]
        Ice,

        [Description("Dragon")]
        Dragon,
    }

    public class ItemObject
    {
        public ItemObject(Items item)
        {
            Value = item;
        }

        private Items value;

        public Items Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = Enum.IsDefined(typeof(Items), value)
                    ? value
                    : Items.NoItem;
            }
        }

        public string Name
        {
            get
            {
                return value.EnumToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var i = obj as ItemObject;
            if (i == null)
            {
                return false;
            }

            return Value == i.Value;
        }

        public bool Equals(Items i)
        {
            return Value == i;
        }

        public override int GetHashCode()
        {
            return (int)value;
        }

        public static bool operator ==(ItemObject a, Items b)
        {
            if (a == null)
            {
                return false;
            }

            return a.Value == b;
        }

        public static bool operator !=(ItemObject a, Items b)
        {
            return !(a == b);
        }
    }

    public class SpeciesObject
    {
        public SpeciesObject(Species species)
        {
            Value = species;
        }

        private Species value;

        public Species Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = Enum.IsDefined(typeof(Species), value)
                    ? value
                    : Species.NoSpecies;
            }
        }

        public string Name
        {
            get
            {
                return value.EnumToString();
            }
        }

        public override string ToString()
        {
            return value.EnumToString();
        }
    }

    public class LocationObject
    {
        public LocationObject(Locations location)
        {
            Value = location;
        }

        private Locations value;

        public Locations Value
        {
            get
            {
                return Enum.IsDefined(typeof(Locations), value)
                    ? value
                    : Locations.Mystery_Zone;
            }
            set
            {
                this.value = Enum.IsDefined(typeof(Locations), value)
                    ? value
                    : Locations.Mystery_Zone;
            }
        }

        public string Name
        {
            get
            {
                return value.EnumToString();
            }
        }

        public override string ToString()
        {
            return value.EnumToString();
        }
    }

    public class MovesObject
    {
        public MovesObject(Moves move)
        {
            Value = move;
        }

        public static implicit operator MovesObject(Moves move)
        {
            return new MovesObject(move);
        }

        private Moves value;

        [DisplayName("Move")]
        public Moves Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = Enum.IsDefined(typeof(Moves), value)
                    ? value
                    : Moves.NoMove;
            }
        }

        [DisplayName("Name")]
        public string Name
        {
            get
            {
                return value.EnumToString();
            }
        }

        [DisplayName("Type")]
        public TypeObject? Type
        {
            get
            {
                int typeid;
                var typequery = DBTools.GetMoveDataTable.Select(string.Format("id = {0}", (int)value));
                if (typequery.Length == 0) return null;
                var typeidstr = typequery[0].ItemArray[(int)DBTools.MoveDataTableColumns.type_id].ToString();
                if (!int.TryParse(typeidstr, out typeid)) return new TypeObject();
                return !Enum.IsDefined(typeof(Types), typeid)
                    ? new TypeObject()
                    : new TypeObject((Types)typeid);
            }
        }

        [DisplayName("Power")]
        public int Power
        {
            get
            {
                var power = 0;
                var powerquery = DBTools.GetMoveDataTable.Select(string.Format("id = {0}", (int)value));
                if (powerquery.Length == 0) return power;
                var powerstr = powerquery[0].ItemArray[(int)DBTools.MoveDataTableColumns.power].ToString();
                int.TryParse(powerstr, out power);
                return power;
            }
        }

        [DisplayName("Accuracy")]
        public decimal Accuracy
        {
            get
            {
                var accuracy = 0M;
                var accuracyquery = DBTools.GetMoveDataTable.Select(string.Format("id = {0}", (int)value));
                if (accuracyquery.Length == 0) return accuracy;
                var accuracystr = accuracyquery[0].ItemArray[(int)DBTools.MoveDataTableColumns.accuracy].ToString();
                decimal.TryParse(accuracystr, out accuracy);
                return accuracy;
            }
        }

        [DisplayName("Base PP")]
        public byte BasePP
        {
            get
            {
                byte basepp = 0;
                var baseppquery = DBTools.GetMoveDataTable.Select(string.Format("id = {0}", (int)value));
                if (baseppquery.Length == 0) return basepp;
                var baseppstr = baseppquery[0].ItemArray[(int)DBTools.MoveDataTableColumns.pp].ToString();
                byte.TryParse(baseppstr, out basepp);
                return basepp;
            }
        }

        [DisplayName("Current PP")]
        public byte CurrentPP { get; set; }

        [DisplayName("PP Ups")]
        public byte PPUps { get; set; }

        [DisplayName("Max PP")]
        public byte MaxPP
        {
            get
            {
                return (byte)(BasePP + (BasePP * 0.2 * PPUps));
            }
        }

        [DisplayName("Flavor Text")]
        public string FlavorText
        {
            get
            {
                var flavor = DBTools.GetMoveDataTable.Select(string.Format("id = {0}", (int)value));
                return flavor.Length != 0
                    ? flavor[0].ItemArray[(int)DBTools.MoveDataTableColumns.flavor_text].ToString()
                    : string.Empty;
            }
        }

        public override string ToString()
        {
            return value.EnumToString();
        }
    }

    public struct TypeObject
    {
        public TypeObject(Types Type)
        {
            value = Enum.IsDefined(typeof(Types), Type)
                ? Type
                : Types.Normal;
        }

        private Types value;

        public Types Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = Enum.IsDefined(typeof(Types), value)
                    ? value
                    : Types.Normal;
            }
        }

        public string Name
        {
            get
            {
                return value.EnumToString();
            }
        }

        public override string ToString()
        {
            return value.EnumToString();
        }
    }
}