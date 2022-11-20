namespace DependencyInjectionLifetime.Services;

public class SecondaryService
{
    private readonly PrimaryService _primaryService;

    public SecondaryService(PrimaryService primaryService)
        => _primaryService = primaryService;

    public Guid Id { get; } = Guid.NewGuid();

    public Guid PrimaryServiceId => _primaryService.Id;
}