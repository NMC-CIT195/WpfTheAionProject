using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTheAionProject.Models
{
    public class Mission
    {
        public enum MissionTypeName
        {
            travel,
            inventory,
            npc
        }
        public enum MissionStatus
        {
            Unassigned,
            Incomplete,
            Complete
        }

        private int _id;
        private string _name;
        private string _description;
        private MissionTypeName _missionType;
        private List<Location> _requiredLocations;
        private List<GameItemQuantity> _requiredGameItemQuantities;
        private List<Npc> _requiredNpcs;
        private MissionStatus _status;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public MissionTypeName MissionType
        {
            get { return _missionType; }
            set { _missionType = value; }
        }

        public List<Location> RequiredLocations
        {
            get { return _requiredLocations; }
            set { _requiredLocations = value; }
        }

        public List<Npc> RequiredNpcs
        {
            get { return _requiredNpcs; }
            set { _requiredNpcs = value; }
        }

        public List<GameItemQuantity> RequiredGameItemQuantities
        {
            get { return _requiredGameItemQuantities; }
            set { _requiredGameItemQuantities = value; }
        }

        public MissionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Mission()
        {

        }

        public Mission(int id, string name, MissionTypeName missionType, List<Location> requiredLocations)
        {
            _id = id;
            _name = name;
            _missionType = missionType;
            _requiredLocations = requiredLocations;
        }

        public Mission(int id, string name, MissionTypeName missionType, List<GameItemQuantity> requiredGameItemQuantities)
        {
            _id = id;
            _name = name;
            _missionType = missionType;
            _requiredGameItemQuantities = requiredGameItemQuantities;
        }

        public Mission(int id, string name, MissionTypeName missionType, List<Npc> requiredNpcs)
        {
            _id = id;
            _name = name;
            _missionType = missionType;
            _requiredNpcs = requiredNpcs;
        }

        public List<Location> LocationsNotCompleted(List<Location> locationsTraveled)
        {
            List<Location> locationsToComplete = new List<Location>();

            foreach (var requiredLocation in _requiredLocations)
            {
                if (!locationsTraveled.Any(l => l.Id == requiredLocation.Id))
                {
                    locationsToComplete.Add(requiredLocation);
                }
            }

            return locationsToComplete;
        }

        public List<Npc> NpcsNotCompleted(List<Npc> NpcsEngaged)
        {
            var testList = _requiredNpcs.Except(NpcsEngaged).ToList();
            return testList;
        }

        public List<GameItemQuantity> GameItemQuantitiesNotCompleted(List<GameItemQuantity> inventory)
        {
            List<GameItemQuantity> gameItemQuantitiesToComplete = new List<GameItemQuantity>();

            foreach (var missionGameItem in _requiredGameItemQuantities)
            {
                GameItemQuantity inventoryItemMatch = inventory.FirstOrDefault(gi => gi.GameItem.Id == missionGameItem.GameItem.Id);
                if (inventoryItemMatch != null)
                {
                    if (inventoryItemMatch.Quantity < missionGameItem.Quantity)
                    {
                        gameItemQuantitiesToComplete.Add(missionGameItem);
                    }
                }
            }

            return gameItemQuantitiesToComplete;
        }
    }
}
