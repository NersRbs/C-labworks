using Contracts;

namespace Console.Scenarios.Back;

public class BackScenario : IScenario
{
    private readonly IBackService _backService;

    public BackScenario(IBackService backService)
    {
        _backService = backService;
    }

    public string Name => "Back";
    public void Run()
    {
        _backService.Back();
    }
}