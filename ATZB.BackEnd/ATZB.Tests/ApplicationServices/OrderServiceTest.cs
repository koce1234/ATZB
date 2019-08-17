namespace ATZB.Tests.ApplicationServices
{
    public class OrderServiceTest
    {
        public void GetAllOrdersTest()
        {

            DbContextOptions<ATZBDbContext> options = new DbContextOptionsBuilder<ATZBDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            ATZBDbContext context = new ATZBDbContext(options);

            OrderService orderService = new OrderService(context);

            SeedDbWithOrders(context);

            int expectedUserCount = context.Orders.Count();
            int actualUserCount = orderService.GetAllOrdersAsync().Result.Count;

            Assert.Equal(expectedUserCount, actualUserCount);
        }
        public void SeedDbWithOrders(ATZBDbContext context)
        {
            context.AddRange();
            context.SaveChanges();
        }

        public List<ATZBOrder> DataForSeedOrders => new List<ATZBOrder>()
            { new ATZBOrder(),new ATZBOrder(), new ATZBOrder(), new ATZBOrder() , new ATZBOrder(), new ATZBOrder() , new ATZBOrder(), new ATZBOrder() , new ATZBOrder(), new ATZBOrder() };
    }
}
