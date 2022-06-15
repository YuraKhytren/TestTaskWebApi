namespace TestTask.Services.Interface
{
    public interface ICreateValidator<T>
    {
        bool ValidateCreate(T model);
    }
}
