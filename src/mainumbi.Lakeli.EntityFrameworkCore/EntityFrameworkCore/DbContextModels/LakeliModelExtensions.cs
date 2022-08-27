using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace mainumbi.Lakeli.EntityFrameworkCore;

public static class LakeliModelExtensions
{
    public static void ConfigureJob(this ModelBuilder builder)
    {
        builder.Entity<Job>(b =>
        {
            b.ToTable(LakeliConsts.DbTablePrefix + ".Job");
            b.ConfigureByConvention();
        });
    }

    public static void ConfigureLaborer(this ModelBuilder builder)
    {
        builder.Entity<Laborer>(b =>
        {
            b.ToTable(LakeliConsts.DbTablePrefix + ".Laborer");
            b.ConfigureByConvention();
        });
    }


    public static void ConfigureRating(this ModelBuilder builder)
    {
        builder.Entity<Rating>(b =>
        {
            b.ToTable(LakeliConsts.DbTablePrefix + ".Rating");
            b.ConfigureByConvention();
        });
    }
}

