using Microsoft.Maui.Essentials;

namespace TagSort.Code;

internal static class database
{
    const int prevCol = 0;
    const int approxPixels = 0;
    static List<Microsoft.Maui.Controls.Grid> gridList = new List<Microsoft.Maui.Controls.Grid>();
    static Dictionary<int, List<Microsoft.Maui.Controls.Button>> tagDict = new Dictionary<int, List<Microsoft.Maui.Controls.Button>>();

    public static List<Microsoft.Maui.Controls.Grid> GridList
    {
        get { return gridList; }
    }

    public static void AddGrid(Microsoft.Maui.Controls.Grid grid)
    {
        if (gridList == null) { return; }

        if (gridList.Contains(grid))
        {
            return;
        }
        else
        {
            gridList.Add(grid);
        }
    }

    public static Dictionary<int, List<Microsoft.Maui.Controls.Button>> TagDict
    {
        get { return tagDict; }
    }

    public static void AddTag(int row, Microsoft.Maui.Controls.Button tag)
    {
        if (tagDict == null) {return;}

        if (tagDict.ContainsKey(row))
        {
            tagDict[row].Add(tag);
        }
        else
        {
            tagDict[row] = new List<Microsoft.Maui.Controls.Button>();
            tagDict[row].Add(tag);
        }
    }

    public static void ClearTags()
    {
        if (tagDict == null) { return; }
        tagDict.Clear();
        gridList.Clear();
    }

    public static int ApproxPixels
    {
        get => Preferences.Get(nameof(ApproxPixels), approxPixels);
        set => Preferences.Set(nameof(ApproxPixels), value);
    }

    public static int PrevCol
    {
        get => Preferences.Get(nameof(PrevCol), prevCol);
        set => Preferences.Set(nameof(PrevCol), value);
    }

    public static void initTags()
    {

    }
}
