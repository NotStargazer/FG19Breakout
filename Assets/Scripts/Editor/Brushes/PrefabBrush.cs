using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Prefab Brush", menuName = "Brushes/Prefab Brush")]
[CustomGridBrush(false, true, false, "Prefab Brush")]
public class PrefabBrush : GridBrushBase
{
    //Public
    public GameObject prefab;
    public int zPosition = 0;

    //Private
    GameObject previousBrushTarget;
    Vector3Int previousPosition;

    public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        Transform itemInCell = GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, zPosition));
        if (itemInCell || position == previousPosition)
            return;

        previousPosition = position;
        if (brushTarget)
            previousBrushTarget = brushTarget;

        brushTarget = previousBrushTarget;

        if (brushTarget.layer == 31)
            return;

        GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        if (instance)
        {
            Undo.MoveGameObjectToScene(instance, brushTarget.scene, "Paint prefab");
            Undo.RegisterCompleteObjectUndo(instance, "Paint prefab");
            instance.transform.SetParent(brushTarget.transform);
            instance.transform.position = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(new Vector3(position.x, position.y, zPosition) + (Vector3.one * 0.5f)));
        }
    }

    public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
    {
        if (brushTarget)
            previousBrushTarget = brushTarget;

        brushTarget = previousBrushTarget;

        if (brushTarget.layer == 31)
            return;

        Transform erased = GetObjectInCell(gridLayout, brushTarget.transform, new Vector3Int(position.x, position.y, zPosition));

        if (erased)
            Undo.DestroyObjectImmediate(erased.gameObject);
    }

    static Transform GetObjectInCell(GridLayout gridLayout, Transform parent, Vector3Int position)
    {
        int childCount = parent.childCount;
        Vector3 min = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(position));
        Vector3 max = gridLayout.LocalToWorld(gridLayout.CellToLocalInterpolated(position + Vector3Int.one));
        Bounds bounds = new Bounds((max + min) * 0.5f, max - min);

        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (bounds.Contains(child.position))
                return child;
        }

        return null;
    }
}
