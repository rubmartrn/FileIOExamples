using Mediator;

namespace StudentApiForMediator.Requests
{
    public sealed record StudentAddRequest(int Id, string Name, string Email) : IRequest<StudentAddResponse>;

    public sealed record StudentAddResponse(int Id, bool Success, string? ErrorMessage = null);
}
