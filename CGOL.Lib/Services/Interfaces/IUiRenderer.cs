namespace CGOL.Lib.Services.Interfaces;

public interface IUiRenderer
{
    public sealed void Initialize()
    {
        InitializeUserInteractions();
        InitializeUi();
    }

    protected void InitializeUi();

    protected void InitializeUserInteractions();

    public sealed void RenderUi(params string[] menuItems)
    {
        InitializeNewFrame();
        RenderMenuStructure(menuItems);
        RenderGame();
    }

    protected void InitializeNewFrame();

    protected void RenderMenuStructure(params string[] menuItems);

    protected void RenderGame();
}