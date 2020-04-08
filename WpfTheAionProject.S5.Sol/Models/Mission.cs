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
            unassigned,
            incomplete,
            complete
        }

        private MissionTypeName _missionType;
        private List<Location> _requiredLocations;
        private List<GameItemQuantity> _requiredGameItems;
        private List<Npc> _requiredNpcs;
        private MissionStatus _status;

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

        public List<GameItemQuantity> RequiredGameItems
        {
            get { return _requiredGameItems; }
            set { _requiredGameItems = value; }
        }

        public MissionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        public Mission()
        {

        }

        public Mission(MissionTypeName missionType, List<Location> requiredLocations)
        {
            _missionType = missionType;
            _requiredLocations = requiredLocations;
        }

        public Mission(MissionTypeName missionType, List<GameItemQuantity> requiredGameItemQuantities)
        {

        }

        public Mission(MissionTypeName missionType, List<Npc> requiredNpcs)
        {

        }

    }
}
