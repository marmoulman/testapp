using System;
using System.Collections.Generic;
using System.Text;
using testapp.Core;

namespace testapp.Database
{
    public interface IAttributeData
    {
        IEnumerable<Core.Attribute> GetAttributesByName(string name);
        Core.Attribute GetById(int id);
        Core.Attribute Update(Core.Attribute updatedAttribute);
        Core.Attribute Add(Core.Attribute newAttribute);
        Core.Attribute Delete(int id);
        int Commit();
    }
}
