using Domic.Infrastructure.Implementations.Domain.Repositories;
using Xunit;

namespace Infrastructure;

public class UserRepositoryTests
{

    public UserRepositoryTests()
    {
        
    }
    
    [Fact]
    public void Should_AddedUserToDatabase_WhenCallAddAsyncMethod_OfUserCommandRepository()
    {
        //Arrange

        QueryUnitOfWork queryUnitOfWork = new QueryUnitOfWork();

        //User NewUser = new User();

        //Act
        
        //UnitOfWork.UserCommandRepository().AddAsync()

        //Assert
    }
}