using System.Collections.Generic;
using System.Linq;


namespace View_FORMS.Data
{
    class DataAccess
    {
        private static WEBEntities context;

        static DataAccess()
        {
            context = new WEBEntities();
        }

        internal static tbl_ListChange GetChanges(int id)
        {
            return context.tbl_ListChange.FirstOrDefault(x => x.Id == id);
        }

        internal static List<string> GetLastChanges(string objectType)
        {
            var query = context.tbl_ListChange.Where(x => x.ObjectType.ToLower() == objectType)
                .Select(x => new { name = x.ObjectName, timeevent = x.EventTime })
                .Distinct().ToList();

            return query.OrderByDescending(x => x.timeevent).Select(x => x.name).Distinct().Take(20).ToList();
        }

        internal static List<tbl_ListChange> GetLastChangesData(string objName)
        {
            return context.tbl_ListChange.Where(x => x.ObjectName == objName)
                .OrderByDescending(x => x.EventTime)
                .ToList();
        }
        internal static List<string> GetLastChanges(string objectType, string text)
        {
            var query = context.tbl_ListChange.Where(x => x.ObjectType.ToLower() == objectType
                && x.ObjectName.ToLower().Contains(text.ToLower().Trim()))
                .Select(x => new { name = x.ObjectName, timeevent = x.EventTime })
                .Distinct().ToList();
            return query.OrderByDescending(x => x.timeevent).Select(x => x.name).Distinct().ToList();
        }
    }
}
