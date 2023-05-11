﻿using SRTPluginProviderRE3.Structs.GameStructs;
using SRTPluginProviderRE3.Structs;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SRTPluginProviderRE3
{
    public class GameMemoryRE3 : IGameMemoryRE3
    {
        public string GameName => "RE3R";

        public string VersionInfo => FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        public GameTimer Timer { get => _timer; set => _timer = value; }
        internal GameTimer _timer;

        public RankManager RankManager { get => _rankManager; set => _rankManager = value; }
        internal RankManager _rankManager;

        public Player PlayerManager { get => _playerManager; set => _playerManager = value; }
        internal Player _playerManager;

        public int InventoryCount { get => _inventoryCount; set => _inventoryCount = value; }
        internal int _inventoryCount;
        public int InventoryMaxCount { get => _inventoryMaxCount; set => _inventoryMaxCount = value; }
        internal int _inventoryMaxCount;

        public InventoryEntry[] Items { get => _items; set => _items = value; }
        internal InventoryEntry[] _items;

        public int ShortcutCount { get => _shortcutCount; set => _shortcutCount = value; }
        internal int _shortcutCount;
        public InventoryEntry[] Shortcuts { get => _shortcuts; set => _shortcuts = value; }
        internal InventoryEntry[] _shortcuts;

        public int EnemyCount { get => _enemyCount; set => _enemyCount = value; }
        internal int _enemyCount;

        public Enemy[] Enemies { get => _enemies; set => _enemies = value; }
        internal Enemy[] _enemies;

        public int EnemyKillCount { get => _enemyKillCount; set => _enemyKillCount = value; }
        internal int _enemyKillCount;

        public int LocationID { get => _locationID; set => _locationID = value; }
        internal int _locationID;

        public string LocationName { get => _locationName; set => _locationName = value; }
        internal string _locationName;

        public int MapID { get => _mapID; set => _mapID = value; }
        internal int _mapID;

        public string MapName { get => _mapName; set => _mapName = value; }
        internal string _mapName;
    }
}
