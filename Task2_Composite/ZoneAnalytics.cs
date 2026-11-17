namespace Lab_12;

public static class ZoneAnalytics
{
    public static void Report(IZoneComponent node) =>
        Log.Write("Аналітика",
            $"{node.Kind} «{node.Name}»: авто {node.GetCarCount()}, виручка {node.GetRevenue():F0} грн");

    public static void PrintTree(IZoneComponent node, int level = 0)
    {
        string indent = level == 0 ? "" : new string(' ', (level - 1) * 3) + "└─ ";
        Log.Write("Дерево",
            $"{indent}{node.Kind} «{node.Name}»: авто {node.GetCarCount()}, виручка {node.GetRevenue():F0} грн");

        foreach (var child in node.Children)
            PrintTree(child, level + 1);
    }
}