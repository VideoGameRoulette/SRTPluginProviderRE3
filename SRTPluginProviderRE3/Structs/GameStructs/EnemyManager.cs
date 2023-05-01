using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SRTPluginProviderRE3.Structs.GameStructs
{
    public struct Enemy
    {
        private int enemyType;
        private int currentHP;
        private int maxHP;

        public EnemyType EnemyType { get => (EnemyType)enemyType; set => enemyType = (int)value; }
        public string EnemyTypeString => EnemyType.ToString();
        public int CurrentHP { get => currentHP; set => currentHP = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public float Percentage => CurrentHP > 0 ? (float)CurrentHP / (float)MaxHP : 0f;
        public bool IsAlive => CurrentHP > 0;

        public void SetValues(int et, HitPointController? hpc)
        {
            EnemyType = (EnemyType)et;
            CurrentHP = hpc?.CurrentHP ?? 0;
            MaxHP = hpc?.MaxHP ?? 0;
        }
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0x1F8)]
    public struct EnemyManager
    {
        [FieldOffset(0x50)] private nint enemyList;
        [FieldOffset(0x78)] private nint activeEnemyList;
        [FieldOffset(0x190)] private int totalEnemyKillCount;
        public IntPtr EnemyList => IntPtr.Add(enemyList, 0x0);
        public IntPtr ActiveEnemyList => IntPtr.Add(activeEnemyList, 0x0);
        public int TotalEnemyKillCount => totalEnemyKillCount;
    }

    public enum EnemyType : int
    {
        ZOMBIE = 0,
        EM2500 = 1,
        EM2600 = 2,
        EM2700 = 3,
        EM3000 = 4,
        EM3300 = 5,
        EM3400 = 6,
        EM3500 = 7,
        EM4000 = 8,
        EM7000 = 9,
        EM7100 = 10,
        EM7200 = 11,
        EM9000_FIRST = 12,
        EM9010 = 13,
        EM9020 = 14,
        EM9030 = 15,
        EM9040 = 16,
        EM9050 = 17,
        EM9200 = 18,
        EM9300 = 19,
        EM9400 = 20,
    };
}