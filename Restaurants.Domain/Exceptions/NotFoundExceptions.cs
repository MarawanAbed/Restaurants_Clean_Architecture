
namespace Restaurants.Domain.Exceptions
{
    public class NotFoundExceptions(string resourceType,string resourceIdentifier) : Exception(
        $"{resourceType}with id : {resourceIdentifier} doesnt exists")
    {
    }
    //this error when there is no resources found in the database
    //we might used it in delete and update
    //for example var res=await _repository.GetRestaurantById(id);
    // if(res is null)
    // {
    //     throw new NotFoundExceptions("Restaurant not found");
    //  }
    //  
    //  
    //  

}
