using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveServer.Games
{
    public class Player
    {
        private byte id = 0;

        public Player(byte id)
        {
            this.id = id;
            AdditionalBytes = new byte[0];
            NoMessageFor = 0f;
            IsReady = 0;

            Position = new float[3];
            Rotation = new float[3];
            Velocity = new float[3];
            BuildingCameraPosition = new float[3];
            BuildingCameraRotation = new float[3];
            AngularVelocity = new float[3];
            IsInGoal = false;
            GotObstacles = false;
            HasReceivedAllObstacles = false;
            RacePoints = 0;
            HasStartedRace = false;
            ParticleEffectsBytes = 0;

            TotalPoints = new List<int>();
            NewPoints = new List<int>();

            HeightInGoal = 0f;
            DeadlyInstances = 0;
            HelpfullInstances = 0;

            BuildingCredits = 0;
            MapVoteIndex = -1;
            Team = 0;
            CurrentCPIndex = 0;
            Skill = 255;

            CustomSkinPNGBytes = null;
            CustomSkinPNGBytesReceived = new List<int>();
            CustomSkinPNGMetaString = "";
        }

        public byte[] AdditionalBytes
        {
            get;set;
        }

        public byte[] CustomSkinPNGBytes
        {
            get; set;
        }

        public List<int> CustomSkinPNGBytesReceived
        {
            get;set;
        }

        public string CustomSkinPNGMetaString
        {
            get; set;
        }

        public bool CustomSkinComplete
        {
            get
            {
                if (CustomSkinPNGBytes == null)
                {
                    return false;
                }
                else
                {
                    int toReceivePackages = ((CustomSkinPNGBytes.Length - 1) / 800) + 1;

                    return CustomSkinPNGBytesReceived.Count >= toReceivePackages && CustomSkinPNGMetaString.Length > 0;
                }
            }
        }

        public float NoMessageFor
        {
            get;set;
        }

        public byte IsReady
        {
            get; set;
        }

        public byte CurrentCPIndex
        {
            get;set;
        }

        public bool HasReceivedAllObstacles
        {
            get; set;
        }

        public bool GotObstacles
        {
            get; set;
        }

        public int RacePoints
        {
            get; set;
        }

        public int MapVoteIndex
        {
            get;set;
        }

        public List<int> TotalPoints
        {
            get; set;
        }

        public byte ParticleEffectsBytes
        {
            get;set;
        }

        public List<int> NewPoints
        {
            get; set;
        }

        public float HeightInGoal
        {
            get; set;
        }

        public int BuildingCredits
        {
            get;set;
        }

        public byte ID
        {
            get
            {
                return id;
            }
        }

        public float[] Position
        {
            get;set;
        }

        public float[] Rotation
        {
            get; set;
        }

        public float[] Velocity
        {
            get; set;
        }

        public float[] AngularVelocity
        {
            get; set;
        }

        public float[] BuildingCameraPosition
        {
            get; set;
        }

        public float[] BuildingCameraRotation
        {
            get; set;
        }

        public bool IsInGoal
        {
            get;set;
        }

        public bool HasStartedRace
        {
            get; set;
        }

        public float RaceTime
        {
            get;set;
        }

        public int DeadlyInstances
        {
            get; set;
        }

        public int HelpfullInstances
        {
            get; set;
        }

        public byte Team
        {
            get; set;
        }

        public byte Skill
        {
            get; set;
        }
    }
}
