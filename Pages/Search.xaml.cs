using Microsoft.Maui.Controls;
using System.Collections;
using TagSort.Code;

namespace TagSort.Pages;

public partial class Search : ContentPage
{
    Hashtable fileStorage = new Hashtable();

    public Search()
    {
        InitializeComponent();
    }

    private void SearchPressed(object sender, EventArgs e)
    {
        var search = MainSearch.Text;
    }

    private void AddTag(object sender, EventArgs e)
    {
        var enterTag = new Entry();
        enterTag.Placeholder = "Tag";
        enterTag.Completed += createTag;
        grid1.Add(enterTag);
        grid1.SetRow(enterTag, 2);
    }

    private void createTag(object sender, EventArgs e)
    {
        var text = ((Entry)sender).Text;
        var tag = new Microsoft.Maui.Controls.Button();
        tag.Text = text;
        tag.WidthRequest = text.Length * 10 + 20;

        var pixels = text.Length * 10 + 25;
        database.ApproxPixels += pixels;

        if (!database.GridList.Contains(grid1))
        {
            database.AddGrid(grid1);
        }

        if (database.ApproxPixels > 275)
        {
            database.ApproxPixels = 0;
            database.PrevCol = -1;
            var newGrid = new Grid();
            database.AddGrid(newGrid);
            pageGrid.Add(newGrid);
            pageGrid.SetRow(newGrid, database.GridList.Count);
        }

        database.PrevCol++;

        database.GridList[database.GridList.Count - 1]?.Add(tag);
        database.GridList[database.GridList.Count - 1]?.SetColumn(tag, database.PrevCol);

        grid1.Children.Remove((Microsoft.Maui.IView)sender);
    }
}
