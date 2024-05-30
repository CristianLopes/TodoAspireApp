namespace TodoAspireApp.Application.UseCases.Authentication
{
    public interface IUseCaseRequest;
    public interface IUseCaseResponse;

    public interface IUseCase<Request, Response>
        where Request: IUseCaseRequest
        where Response: IUseCaseResponse
    {
        Task<Response> Execute(Request request);
    }
}
