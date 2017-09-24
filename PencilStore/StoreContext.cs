using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PencilStore.Entities;

namespace PencilStore
{
    public class StoreContext: DbContext
    {
        public DbSet<PencilEntity> Pencils { get; set; }

        public DbSet<BuyerEntity> Buyers { get; set; }
    }
}