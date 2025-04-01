

namespace Restaurants.Application.Guide
{

    //    What is CQRS?
    //CQRS is a design pattern that separates the responsibility of reading data(queries) from writing data(commands).
    //Instead of a single model handling both reads and writes, you split them into distinct paths,
    //often with separate data stores or models optimized for each.
    //Command: Changes state(e.g., create, update, delete). Example: "Place an order."
    //Query: Retrieves state(e.g., read data). Example: "Get all orders."

    ///old Code 
    //public class OrderService
    //{
    //    private readonly OrderRepository _repository;

    //    public OrderService(OrderRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<List<Order>> GetOrders()
    //    {
    //        return await _repository.GetAllOrders();
    //    }

    //    public async Task<Order> GetOrder(int id)
    //    {
    //        var order = await _repository.GetOrderById(id);
    //        if (order == null) throw new Exception("Order not found");
    //        return order;
    //    }

    //    public async Task CreateOrder(Order order)
    //    {
    //        await _repository.CreateOrder(order);
    //    }
    //}
    //    Issues with This Approach
    //Single Model: The Order class is used for both reading and writing, which can lead to a bloated model if read and write needs diverge(e.g., reads need a flattened DTO, writes need validation).
    //Tightly Coupled: The service and repository handle both reads and writes, making it hard to optimize or scale them separately.
    //Performance: Fetching Orders with Items for every read(e.g., Include) might be overkill for simple queries, slowing down the system.
    //Complexity: As the app grows, mixing read/write logic in one service becomes messy and harder to maintain.



    ///new Code 
    // Command
    //public class PlaceOrderCommand
    //{
    //    public int Id { get; set; }
    //    public List<OrderItem> Items { get; set; }
    //}

    //public class PlaceOrderCommandHandler
    //{
    //    private readonly IOrderRepository _repository;

    //    public PlaceOrderCommandHandler(IOrderRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task Handle(PlaceOrderCommand command)
    //    {
    //        var order = new Order { Id = command.Id, Items = command.Items };
    //        await _repository.Save(order);
    //    }
    //}

    //// Query
    //public class GetOrdersQuery
    //{
    //    public DateTime? FromDate { get; set; }
    //}

    //public class GetOrdersQueryHandler
    //{
    //    private readonly IOrderReadRepository _readRepository;

    //    public GetOrdersQueryHandler(IOrderReadRepository readRepository)
    //    {
    //        _readRepository = readRepository;
    //    }

    //    public async Task<List<OrderDto>> Handle(GetOrdersQuery query)
    //    {
    //        return await _readRepository.GetOrders(query.FromDate);
    //    }
    //}


    //    Why Use CQRS?
    //CQRS emerges to address limitations in traditional CRUD-based architectures:

    //Scalability: Reads and writes have different performance needs.Queries might need fast, denormalized data, while commands need consistency.CQRS lets you optimize each separately(e.g., use a relational DB for writes, a NoSQL store for reads).

    //Complexity: In complex domains, a single model for both reads and writes becomes bloated.CQRS allows tailored models (e.g., a flat OrderDto for reads vs. a rich Order entity for writes).

    //Separation of Concerns: Commands and queries have different responsibilities—splitting them clarifies intent and reduces coupling.

    //    What Problems Does It Fix?

    //Performance Bottlenecks: In CRUD, heavy read traffic slows down writes because they share the same model and database.CQRS can use separate, optimized stores.
    //Overcomplicated Models: A single model often compromises between read and write needs, leading to inefficiency or overengineering.
    //Concurrency Issues: Writes need strict consistency, while reads can tolerate eventual consistency.CQRS separates these concerns.


    //When to Use CQRS?
    //Use it in complex systems with high read/write disparity (e.g., e-commerce with tons of browsing vs. fewer purchases).
    //Avoid it in simple CRUD apps—it adds unnecessary complexity.
}
