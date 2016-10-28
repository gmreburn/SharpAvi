namespace NutsAndBrackets.Avi
{
    using Models;

    public interface IPoolsController
    {
        Pool GetByUuid(string uuid);

        Pool GetByName(string name);

        Pool Update(Pool pool);
    }
}