using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTheAionProject.Models;

namespace WpfTheAionProject.DataLayer
{
    /// <summary>
    /// static class to store the game data set
    /// </summary>
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Bonzo",
                Age = 43,
                JobTitle = Player.JobTitleName.Explorer,
                Race = Character.RaceType.Human,
                Health = 100,
                Lives = 3,
                ExperiencePoints = 10,
                SkillLevel = 4,
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(1003), 1),
                    new GameItemQuantity(GameItemById(2001), 5),
                },
                Missions = new ObservableCollection<Mission>()
                {
                    MissionById(1),
                    MissionById(2),
                    MissionById(3)
                }
            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        private static Location LocationById(int id)
        {
            List<Location> locations = new List<Location>();

            foreach (Location location in GameMap().MapLocations)
            {
                if (location != null) locations.Add(location);
            }

            return locations.FirstOrDefault(i => i.Id == id);
        }

        private static Mission MissionById(int id)
        {
            return Missions().FirstOrDefault(m => m.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 4;

            Map gameMap = new Map(rows, columns);

            gameMap.StandardGameItems = StandardGameItems();

            //
            // row 1
            //
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Norlon Corporate Headquarters",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit " +
                "Michigan.Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company with " +
                "huge holdings in defense and space research and development.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "\tYou have been hired by the Norlon Corporation to participate in its latest endeavor, the " +
                "Aion Project. Your mission is to  test the limits of the new Aion Engine and report back to the Norlon " +
                "Corporation. You will begin by choosing a new location and using Aion Engine to travel to that point in the " +
                "Galaxy.\n\tThe Aion Engine, design by Dr. Tormeld, is limited to four slipstreams, denoted by the cardinal points on a compass, from any given locations."
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "Aion Base Lab",
                Description = "The Norlon Corporation research facility located in the city of Heraklion on " +
                "the north coast of Crete and the top secret research lab for the Aion Project.\nThe lab is a large, " + "" +
                "well lit room, and staffed by a small number of scientists, all wearing light blue uniforms with the hydra-like Norlan Corporation logo.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(4002), 1)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1001)
                }
            };

            //
            // row 2
            //
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 3,
                Name = "Felandrian Plains",
                Description = "The Felandrian Plains are a common destination for tourist. Located just north of the " +
                "equatorial line on the planet of Corlon, they provide excellent habitat for a rich ecosystem of flora and fauna.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(4001), 1)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(1002),
                    NpcById(2001),
                    NpcById(2002)
                }
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 4,
                Name = "Epitoria's Reading Room",
                Description = "Queen Epitoria, the Torian Monarh of the 5th Dynasty, was know for her passion for " +
                "galactic history. The room has a tall vaulted ceiling, open in the middle  with four floors of wrapping " +
                "balconies filled with scrolls, texts, and infocrystals. As you enter the room a red fog desends from the ceiling " +
                "and you begin feeling your life energy slip away slowly until you are dead.",
                Accessible = false,
                RequiredRelicId = 4001,
                ModifiyExperiencePoints = 50,
                ModifyLives = -1,
                RequiredExperiencePoints = 40
            };

            //
            // row 3
            //
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 5,
                Name = "Xantoria Market",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an open market managed " +
                "by the Xantorian Commerce Coop. It is a place where many races from various systems trade goods." +
                "You purchase a blue potion in a thin, clear flask, drink it and receive 50 points of health.",
                Accessible = false,
                ModifiyExperiencePoints = 20,
                ModifyHealth = 50,
                Message = "Traveler, our telemetry places you at the Xantoria Market. We have reports of local health potions."
            };
            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 6,
                Name = "The Tamfasia Galactic Academy",
                Description = "The Tamfasia Galactic Academy was founded in the early 4th galactic metachron. " +
                "You are currently in the library, standing next to the protoplasmic encabulator that stores all " +
                "recorded information of the galactic history.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001), 10)
                }
            };
            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Longsword", 75, 1, 4, "The longsword is a type of sword characterized as having a cruciform hilt with a grip for two-handed use and 85 to 110 cm in length.", 10),
                new Weapon(1002, "Phaser", 250, 1, 9, "Phasers are common and versatile phased array pulsed energy projectile weapons.", 10),
                new Weapon(1003, "Tommy Gun", 125, 1, 5, "Tommy guns are an old fashioned, hand carry machine gun popularized by the gangsters of the 1940s.", 10),
                new Treasure(2001, "Gold Coin", 10, Treasure.TreasureType.Coin, "24 karat gold coin", 1),
                new Treasure(2020, "Small Diamond", 50, Treasure.TreasureType.Jewel, "A small pea-sized diamond of various colors.", 1),
                new Treasure(2030, "Kalzonian Manuscript", 10, Treasure.TreasureType.Manuscript, "Reportedly stolen during the Zantorian raids of of the 4th dynasty, it is said to contain information about early galactic technologies.", 5),
                new Potion(3001, "Distilled Baladorian Lion Mucus", 5, 40, 1, "Rare potion due to the dangers of procurement. Add 40 points of health.", 5),
                new Relic(4001, "Crystal Key", 5, "Conjured by the Forest Wizard, it opens many doors.", 5, "You have opened the Epitoria's Reading Room.", Relic.UseActionType.OPENLOCATION),
                new Relic(4002, "Stick of Adol", 5, "Long polished wooden rod with sliding silver ribbons..", 5, "Sliding the silver ribbons, you feel a sharp pain in your left temple and quickly die.", Relic.UseActionType.KILLPLAYER)
            };
        }

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Military()
                {
                    Id = 2001,
                    Name = "Sargent Aimes",
                    Race = Character.RaceType.Human,
                    Description = "A short, stocky man who had a strong look of determination and a disposition to match.",
                    Messages = new List<string>()
                    {
                        "Stop and state your purpose.",
                        "I have been ordered to kill all who enter.",
                        "Leave now or bear the consequences."
                    },
                   SkillLevel = 5,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Military()
                {
                    Id = 2002,
                    Name = "Private Smith",
                    Race = Character.RaceType.Human,
                    Description = "A slight, edgy man who looks straight off the farm..",
                    Messages = new List<string>()
                    {
                        "Who are you?",
                        "Why are you here?",
                        "Have I told you about my family?"
                    },
                   SkillLevel = 1,
                   CurrentWeapon = GameItemById(1002) as Weapon
                },

                new Citizen()
                {
                    Id = 1001,
                    Name = "Sonia Smith",
                    Race = Character.RaceType.Human,
                    Description = "A tall women of respectable stature.",
                    Messages = new List<string>()
                    {
                        "Hello, my name is Ms Smith. I noticed you when you arrived.",
                        "Excuse me, but are you looking for something."
                    }
                },

                new Citizen()
                {
                    Id = 1002,
                    Name = "Xantipple Ford",
                    Race = Character.RaceType.Xantorian,
                    Description = "A tall women of respectable stature.",
                    Messages = new List<string>()
                    {
                        "Excuse me, but my kind does not speak with your kind."
                    }
                }
            };
        }

        public static List<Mission> Missions()
        {
            return new List<Mission>()
            {
                new MissionTravel()
                {
                    Id = 1,
                    Name = "Scouting",
                    Description = "Explore all locations and gather all information possible.",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredLocations = new List<Location>()
                    {
                        LocationById(3),
                        LocationById(5)
                    },
                    ExperiencePoints = 100
                },

                new MissionGather()
                {
                    Id = 2,
                    Name = "Collecting",
                    Description = "Locate and collect all required objects.",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredGameItemQuantities = new List<GameItemQuantity>()
                    {
                        new GameItemQuantity(GameItemById(1002), 1),
                        new GameItemQuantity(GameItemById(4001), 1),
                        new GameItemQuantity(GameItemById(2001), 7)
                    },
                    ExperiencePoints = 200
                },

                new MissionEngage()
                {
                    Id = 3,
                    Name = "Locate",
                    Description = "Locate and speak to all required persons.",
                    Status = Mission.MissionStatus.Incomplete,
                    RequiredNpcs = new List<Npc>()
                    {
                        NpcById(2001),
                        NpcById(2002)
                    },
                    ExperiencePoints = 500
                },

            };

        }
    }
}