using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Environment
{
    public class TileUtils
    {
#if UNITY_EDITOR
        public static void CreateMenuItem<T>() where T : ScriptableObject
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Tile", "New Tile", "asset", "Save Tile", "Assets");
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<T>(), path);
        }
#endif
    }

    public class BreakableTile : Tile
    {
        public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
        {
            base.GetTileData(location, tileMap, ref tileData);
        }

        public static void Break(Vector3Int location, Tilemap tileMap)
        {
            tileMap.SetTile(location, null);
        }

#if UNITY_EDITOR
        [MenuItem("Assets/Create/BreakableTile")]
        public static void CreateTile()
        {
            TileUtils.CreateMenuItem<BreakableTile>();
        }
#endif
    }
}
