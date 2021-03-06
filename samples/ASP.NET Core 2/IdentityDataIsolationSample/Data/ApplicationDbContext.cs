﻿using System;
using System.Collections.Generic;
using System.Text;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityDataIsolationSample.Data
{
    public class ApplicationDbContext : MultiTenantIdentityDbContext
    {
        public ApplicationDbContext(ITenantInfo tenantInfo) : base(tenantInfo)
        {
        }

        public ApplicationDbContext(ITenantInfo tenantInfo, DbContextOptions<ApplicationDbContext> options)
            : base(tenantInfo, options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(TenantInfo.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
