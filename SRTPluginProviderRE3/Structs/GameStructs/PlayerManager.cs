using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SRTPluginProviderRE3.Structs.GameStructs
{
    public class Player
    {
        private SurvivorType currentSurvivor;
        private Costume currentCostume;
        private HitPointController hitPointController;
        private bool isPoisoned;
        private bool hasParasite;
        private Vec3 position;

        public SurvivorType CurrentSurvivor { get => currentSurvivor; set => currentSurvivor = value; }
        public string CurrentSurvivorString => CurrentSurvivor.ToString();
        public Costume CurrentCostume { get => currentCostume; set => currentCostume = value; }
        public string CurrentCostumeString => CurrentCostume.ToString();
        public HitPointController Health { get => hitPointController; set => hitPointController = value; }
        public bool IsPoisoned { get => isPoisoned; set => isPoisoned = value; }
        public bool HasParasite { get => hasParasite; set => hasParasite = value; }
        public Vec3 Position { get => position; set => position = value; }
        public PlayerState HealthState
        {
            get =>
                !Health.IsAlive ? PlayerState.Dead :
                !IsPoisoned ? PlayerState.Poisoned :
                !HasParasite ? PlayerState.Gassed :
                Health.Percentage >= 0.66f ? PlayerState.Fine :
                Health.Percentage >= 0.33f ? PlayerState.Caution :
                PlayerState.Danger;
        }
        public string CurrentHealthState => HealthState.ToString();

        public Player()
        {
            CurrentSurvivor = default(SurvivorType);
            CurrentCostume = default(Costume);
            Health = default(HitPointController);
            IsPoisoned = false;
            HasParasite = false;
            Position = new Vec3(0,0,0);
        }

        public void SetValues(PlayerCondition pc, CostumeChanger cc, HitPointController hpc)
        {
            CurrentSurvivor = pc.SurvivorType;
            CurrentCostume = cc.CurrentCostume;
            Health = hpc;
            IsPoisoned = pc.IsPoison;
            HasParasite = pc.IsParasite;
            Position.Update(pc.X, pc.Y, pc.Z);
        }
    }

    public class Vec3
    {
        private float x;
        private float y;
        private float z;
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }

        public Vec3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public void Update(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x3E0)]
    public struct PlayerCondition
    {
        [FieldOffset(0x54)] private int survivorType;
        [FieldOffset(0x288)] private nint costumeChanger;
        [FieldOffset(0x2C0)] private nint hitPointController;
        [FieldOffset(0x2E8)] private byte isPoison;
        [FieldOffset(0x2E9)] private byte isParasite;
        [FieldOffset(0x3B0)] private Vector3 pastPosition;

        public SurvivorType SurvivorType => (SurvivorType)survivorType;
        public string SurvivorTypeString => SurvivorType.ToString();
        public IntPtr CostumeChanger => IntPtr.Add(costumeChanger, 0x0);
        public IntPtr HitPointController => IntPtr.Add(hitPointController, 0x0);
        public bool IsPoison => isPoison != 0;
        public bool IsParasite => isParasite != 0;
        public float X => pastPosition.X;
        public float Y => pastPosition.Y;
        public float Z => pastPosition.Z;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0xD0)]
    public struct CostumeChanger
    {
        [FieldOffset(0x54)] private int currentCostume;

        public Costume CurrentCostume => (Costume)currentCostume;
        public string CurrentCostumeString => CurrentCostume.ToString();
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x64)]
    public struct HitPointController
    {
        [FieldOffset(0x54)] private int defaultHitPoint;
        [FieldOffset(0x58)] private int currentHitPoint;
        [FieldOffset(0x5C)] private byte invincible;
        [FieldOffset(0x62)] private byte noDamage;

        public int MaxHP => defaultHitPoint;
        public int CurrentHP => currentHitPoint;
        public bool Invincible => invincible != 0;
        public bool NoDamage => noDamage != 0;
        public float Percentage => CurrentHP > 0 ? (float)CurrentHP / (float)MaxHP : 0f;
        public bool IsAlive => CurrentHP != 0 && MaxHP != 0 && CurrentHP > 0 && CurrentHP <= MaxHP;
    }

    public enum PlayerState
    {
        Dead,
        Fine,
        Caution,
        Danger,
        Poisoned,
        Gassed
    }

    public enum SurvivorType : int
    {
        Invalid = -1,
        Carlos = 0,
        PL1000 = 1,
        Jill = 2,
        PL2700 = 3,
        PL2900 = 4,
        PL2910 = 5,
        PL4000 = 6,
        PL5000 = 7,
        PL7000 = 8,
        PL7010 = 9,
        PL7020 = 10,
        PL7030 = 11,
        PL8000 = 12,
        PL8010 = 13,
        PL8020 = 14,
        PL8030 = 15,
        PL8040 = 16,
        PL8050 = 17,
        PL8060 = 18,
        PL8070 = 19,
        PL8080 = 20,
        PL8090 = 21,
        PL8100 = 22,
        PL8140 = 23,
        PL8150 = 24,
        PL8170 = 25,
        PL8200 = 26,
        PL8500 = 27,
        PL8510 = 28,
        PL8520 = 29,
        PL8530 = 30,
        PL8540 = 31,
        PL8550 = 32,
        PL8560 = 33,
        PL9000 = 34,
        PL9100 = 35,
        PL9200 = 36,
        PL9300 = 37,
        PL9400 = 38,
        PL9500 = 39,
        PL9600 = 40,
        PL9700 = 41,
        PL9800 = 42,
        PL9900 = 43,
        INVALID = -1,
        CARLOS = 0,
        CLAIRE = 1,
        JILL = 2,
        JILL_MIRROR = 4,
        JILL_MIRROR_DEF = 5,
        NICHOLAI = 6,
        MIKHAIL = 7,
        BRAD = 12,
        ZOMBIE_A = 8,
        ZOMBIE_B = 9,
        ZOMBIE_C = 10,
        POLICE_H = 11,
        TYRELL = 13,
        MURPHY = 14,
        DARIO = 15,
        AMY = 16,
        RACCOON_CITIZEN = 17,
        NATHANIEL = 18,
        CARLOSZONBI = 19,
        MAVIN = 22,
        BRIAN = 23,
        BEN = 24,
        ROBERT = 25,
        POLICEMAN_A = 27,
        POLICEMAN_B = 28,
        RESEARCHER_MOB = 29,
        PROTECTIVECLOTH = 33,
    }

    public enum Costume : int
    {
        Invalid = -1,
        Default = 0,
        Costume_1 = 1,
        Costume_2 = 2,
        Costume_3 = 3,
        Costume_4 = 4,
        Costume_5 = 5,
        Costume_6 = 6,
        Costume_7 = 7,
        Costume_8 = 8,
        Costume_9 = 9,
        Costume_A = 10,
        Costume_B = 11,
        Costume_C = 12,
        Costume_D = 13,
        Costume_E = 14,
        Costume_F = 15,
        Scenario = 16,
        Classic = 17,
    };
}