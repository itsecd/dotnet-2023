using DotNet2023.WebApi.DataBase;

namespace DotNet2023.WebApi.Repository.Queries;
public class QueriesRepository
{
    private readonly DbContextWebApi _dbContext;
    public QueriesRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;





}
