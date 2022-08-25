using System.Threading.Tasks;

namespace mainumbi.Lakeli.Data;

public interface ILakeliDbSchemaMigrator
{
    Task MigrateAsync();
}
