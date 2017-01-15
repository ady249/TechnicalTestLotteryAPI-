namespace LotteryDraw.Data.Interfaces.Factories
{
    public interface IGenericFactory<out T>
    {
        T Create();
    }
}
