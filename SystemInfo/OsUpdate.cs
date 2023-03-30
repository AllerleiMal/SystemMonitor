using System.Collections.Generic;
using WUApiLib;

namespace SystemInfo;

public class OsUpdate
{
    public string Title { get; set; }
    public bool IsInstalled { get; set; }
    public bool IsDownloaded { get; set; }

    public OsUpdate()
    {
        
    }

    public OsUpdate(string title, bool isInstalled, bool isDownloaded)
    {
        Title = title;
        IsInstalled = isInstalled;
        IsDownloaded = isDownloaded;
    }

    public static List<OsUpdate> GetUpdates()
    {
        UpdateSession session = new UpdateSession();
        IUpdateSearcher searcher = session.CreateUpdateSearcher();
        searcher.Online = false;
        List<OsUpdate> result = new List<OsUpdate>();

        ISearchResult searchResult = searcher.Search("Type='Software'");
        foreach (IUpdate update in searchResult.Updates)
        {
            result.Add(new OsUpdate(update.Title, update.IsInstalled, update.IsDownloaded));
        }

        return result;
    }
}