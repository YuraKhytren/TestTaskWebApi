namespace TestTask.Services.Interface
{
    public interface ICreateValidator<T>
    {
        bool CanCreate(T model);
    }
}
