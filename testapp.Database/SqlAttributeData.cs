using testapp.Core;
using testapp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace testapp.Database
{
    public class SqlAttributeData : IAttributeData
    {

        private readonly testappDbContext db;

        public SqlAttributeData(testappDbContext db)
        {
            this.db = db;
        }

        public Core.Attribute Add(Core.Attribute newAttribute)
        {
            db.Add(newAttribute);
            return newAttribute;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Core.Attribute Delete(int id)
        {
            var attribute = GetById(id); 
            if(attribute != null)
            {
                db.Remove(attribute);
            }
            return attribute;
        }

        public IEnumerable<Core.Attribute> GetAttributesByName(string name)
        {
            var query = from a in db.Attributes
                        where a.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        select a;
            return query;
        }

        public Core.Attribute GetById(int id)
        {
            return db.Attributes.Find(id);
        }

        public Core.Attribute Update(Core.Attribute updatedAttribute)
        {
            var entity = db.Attributes.Attach(updatedAttribute);
            entity.State = EntityState.Modified;
            return updatedAttribute;
        }
    }
}
